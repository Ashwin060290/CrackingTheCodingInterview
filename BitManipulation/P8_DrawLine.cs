using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BitManipulation
{
    public class P8_DrawLine
    {
        /* Draw Line: A monochrome screen is stored as a single array of bytes, allowing eight consecutive
            pixels to be stored in one byte. The screen has width w, where w is divisible by 8 (that is, no byte will
            be split across rows). The height of the screen, of course, can be derived from the length of the array
            and the width. Implement a function that draws a horizontal line from ( xl, y) to ( x2, y).  */


        public byte[] Draw(byte[] screen, int width, int x1, int x2, int y)
        {
            int firstFilledByte = x1 / 8;
            int firstOffset = x1 % 8;
            if (firstOffset != 0)
                firstFilledByte++;

            int lastFilledByte = x2 / 8;
            int lastOffset = x2 % 8;
            if (lastOffset != 7)
                lastFilledByte--;

            for (int i = firstFilledByte; i <= lastFilledByte; i++)
            {
                screen[((width/ 8)*y) + i] = 255;
            }

            byte firstMask = (byte) (255 >> firstOffset);
            byte lastMask = (byte) ~(255 >> lastOffset + 1);

            if ((x1 / 8) == (x2 / 8))
            {
                byte mask = (byte) (firstMask & lastMask);
                screen[((width / 8) * y) + (x1 / 8)] |= mask;
            }
            else
            {
                if (firstOffset != 0)
                {
                    int byteNumber = ((width / 8) * y) + firstFilledByte - 1;
                    screen[byteNumber] |= firstMask;
                }

                if (lastOffset != 7)
                {
                    int byteNumber = ((width / 8) * y) + lastFilledByte + 1;
                    screen[byteNumber] |= lastMask;
                }
            }
            return screen;
        }

        public void Display(byte[] screen, int width)
        {
            string display = "";

            int count = 0;
            foreach (byte b in screen)
            {
                count++;
                display += Convert.ToString(b, 2).PadLeft(8, '0');

                if ((count * 8) % width == 0)
                {
                    Console.WriteLine(display);
                    display = "";
                }
            }

            Console.ReadLine();
        }
    }

    [TestFixture]
    public class TestDrawLine
    {
        
        public void Display()
        {
            byte[] screen = new byte[10]{0, 255, 255,255,0,0,0,0,0,0 };
            int width = 5;

            P8_DrawLine drawLine = new P8_DrawLine();

            drawLine.Display(screen, width);
        }

        [Test]
        public void Draw_WithInputScreen_ShouldReturnCorrectByteArray()
        {
            byte[] screen = new byte[10];
            int width = 5;
            int x1 = 10;
            int x2 = 30;
            int y = 0;
            byte[] expected = new byte[10]{0,63,255,254,0,0,0,0,0,0};
            P8_DrawLine drawLine = new P8_DrawLine();

            byte[] actual = drawLine.Draw(screen, width, x1, x2, y);

            drawLine.Display(actual,width);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Draw_WithLineStartAtSTartBitOfByteAndEndAtAnotherBytesLastBit_ShouldReturnCorrectByteArray()
        {
            byte[] screen = new byte[10];
            int width = 5;
            int x1 = 8;
            int x2 = 31;
            int y = 0;
            byte[] expected = new byte[10] { 0, 255, 255, 255, 0, 0, 0, 0, 0, 0 };
            P8_DrawLine drawLine = new P8_DrawLine();

            byte[] actual = drawLine.Draw(screen, width, x1, x2, y);

            drawLine.Display(actual, width);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Draw_WithLineStartAndEndInSameByte_ShouldReturnCorrectByteArray()
        {
            byte[] screen = new byte[10];
            int width = 5;
            int x1 = 10;
            int x2 = 13;
            int y = 0;
            byte[] expected = new byte[10] { 0, 60, 0, 0, 0, 0, 0, 0, 0, 0 };
            P8_DrawLine drawLine = new P8_DrawLine();

            byte[] actual = drawLine.Draw(screen, width, x1, x2, y);

            drawLine.Display(actual, width);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}