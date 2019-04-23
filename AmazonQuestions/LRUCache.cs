using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AmazonQuestions
{
    public class LRUCache
    {

        private int _capacity;
        private Dictionary<int, DoubleLinkedNode> _nodes;
        private DoubleLinkedNode _head;
        private DoubleLinkedNode _tail;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _nodes = new Dictionary<int, DoubleLinkedNode>();
            _head = new DoubleLinkedNode(0, 0);
            _tail = _head;

        }

        public int Get(int key)
        {

            if (_nodes.ContainsKey(key))
            {
                DoubleLinkedNode node = _nodes[key];
                RemoveNode(node);
                AddToTail(node);
                return node.value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {

            if (!_nodes.ContainsKey(key))
            {
                if (IsFull())
                {
                    RemoveHead();
                }
                DoubleLinkedNode node = new DoubleLinkedNode(value, key);
                _nodes.Add(key, node);
                AddToTail(node);
            }
            else
            {
                _nodes[key].value = value;
                AddToTail(_nodes[key]);
            }
        }

        private void AddToTail(DoubleLinkedNode node)
        {
            _tail.next = node;
            node.previous = _tail;
            _tail = node;
            _tail.next = null;
            _nodes.Add(node.key, node);
        }

        private void RemoveHead()
        {
            if (!IsEmpty())
            {
                RemoveNode(_head.next);
            }
        }

        private void RemoveNode(DoubleLinkedNode node)
        {
            if (_tail == node)
            {
                _tail = node.previous;
                _tail.next = null;
                node.previous = null;
                node.next = null;

            }
            else
            {
                node.previous.next = node.next;
                node.next.previous = node.previous;
                node.previous = null;
                node.next = null;
            }
            _nodes.Remove(node.key);
        }

        private bool IsFull()
        {
            return (_nodes.Count == _capacity);
        }

        private bool IsEmpty()
        {
            return (_head == _tail);
        }
    }


    [TestFixture]
    public class TestLRUCache
    {
        [Test]
        public void Test()
        {
            LRUCache l = new LRUCache(2);

            l.Put(1,1);
            l.Put(2,2);
            l.Get(1);
            l.Put(3,3);
            l.Get(2);
        }
    }



    public class DoubleLinkedNode
    {
        public int value;
        public int key;
        public DoubleLinkedNode previous;
        public DoubleLinkedNode next;


        public DoubleLinkedNode(int v, int k)
        {
            key = k;
            value = v;
            previous = null;
            next = null;
        }
    }


    

    /**
     * Your LRUCache object will be instantiated and called as such:
     * LRUCache obj = new LRUCache(capacity);
     * int param_1 = obj.Get(key);
     * obj.Put(key,value);
     */
}
