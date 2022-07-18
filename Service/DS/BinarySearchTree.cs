using System;
using System.Collections;
using System.Collections.Generic;

namespace Service.DS
{
    internal class BinarySearchTree<TKey, TValue> : IEnumerable<TValue> where TKey : IComparable<TKey>
    {
        private Node root;

        private class Node : IEnumerable<TValue>
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }

            public IEnumerator<TValue> GetEnumerator()
            {
                if (Left != null)
                {
                    foreach (var node in Left) yield return node;
                }
                yield return Value;
                if (Right != null)
                {
                    foreach (var node in Right) yield return node;
                }
            }
            IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
        }

        public void Add(TKey key, TValue value)
        {
            if (root == null)
            {
                root = new Node(key, value);
                return;
            }

            Node prev = null;
            Node curr = root;
            while (curr != null)
            {
                prev = curr;
                if (key.CompareTo(curr.Key) < 0) curr = curr.Left;
                else curr = curr.Right;
            }
            if (key.CompareTo(prev.Key) < 0) prev.Left = new Node(key, value);
            else prev.Right = new Node(key, value);
        }

        public bool Search(TKey key, out TValue item)
        {
            item = default;
            Node tmp = root;
            while (tmp != null)
            {
                if (key.CompareTo(tmp.Key) < 0) tmp = tmp.Left;
                else if (key.CompareTo(tmp.Key) > 0) tmp = tmp.Right;
                else
                {
                    item = tmp.Value;
                    return true;
                }
            }
            return false;
        }

        public bool DeleteItem(TKey key)
        {
            Node curr = root, prev = null;

            //finding the node
            while (curr != null && curr.Key.CompareTo(key) != 0)
            {
                prev = curr;
                if (key.CompareTo(curr.Key) < 0) curr = curr.Left;
                else curr = curr.Right;
            }
            if (curr == null) return false;

            if (curr.Left == null || curr.Right == null)
            {
                Node newCurr;

                if (curr.Left == null) newCurr = curr.Right;
                else newCurr = curr.Left;

                if (prev == null) root = newCurr;
                else
                {
                    if (curr == prev.Left) prev.Left = newCurr;
                    else prev.Right = newCurr;
                }
            }
            else
            {
                Node tmp = curr.Right, tmpPrev = null;

                //find closest value equal or above
                while (tmp.Left != null)
                {
                    tmpPrev = tmp;
                    tmp = tmp.Left;
                }

                if (tmpPrev != null) tmpPrev.Left = tmp.Right;
                else curr.Right = tmp.Right;
                curr.Key = tmp.Key;
            }
            return true;
        }

        public IEnumerator<TValue> GetEnumerator() => root?.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    }
}
