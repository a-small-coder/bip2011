using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeServer
{

    public class Node
    {
        public byte[] Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Parent { get; set; }
        public bool IsRed { get; set; }
        public long Offset { get; set; }
        public string Name { get; set; }
    }


    public class RBTree
    {
        private Node _root;



        public void Add(byte[] value, long offset, string name)
        {
            var newNode = new Node() { Value = value, IsRed = true, Offset = offset, Name = name };
            if (_root == null)
            {
                _root = newNode;
            }
            else
            {
                var node = _root;
                while (node != null)
                {
                    if (CompareByteArrays(value, node.Value) < 0)
                    {
                        if (node.Left == null)
                        {
                            node.Left = newNode;
                            newNode.Parent = node;

                            FixTreeAfterInsert(newNode);

                            return;
                        }
                        node = node.Left;
                    }
                    else
                    {
                        if (node.Right == null)
                        {
                            node.Right = newNode;
                            newNode.Parent = node;

                            FixTreeAfterInsert(newNode);

                            return;
                        }
                        node = node.Right;
                    }
                }
            }
            FixTreeAfterInsert(newNode);
        }

        public void Remove(byte[] value)
        {
            var node = FindNode(value);
            if (node == null)
                return;

            if (node.Left != null && node.Right != null)
            {
                var successor = GetSuccessor(node);
                node.Value = successor.Value;
                node = successor;
            }

            var replacement = node.Left ?? node.Right;

            if (replacement != null)
            {
                replacement.Parent = node.Parent;
                if (node.Parent == null)
                    _root = replacement;
                else if (node == node.Parent.Left)
                    node.Parent.Left = replacement;
                else
                    node.Parent.Right = replacement;

                node.Left = node.Right = node.Parent = null;

                if (!node.IsRed)
                    FixTreeAfterRemove(replacement);
            }
            else if (node.Parent == null)
            {
                _root = null;
            }
            else
            {
                if (!node.IsRed)
                    FixTreeAfterRemove(node);

                if (node.Parent != null)
                {
                    if (node == node.Parent.Left)
                        node.Parent.Left = null;
                    else if (node == node.Parent.Right)
                        node.Parent.Right = null;
                    node.Parent = null;
                }
            }
        }


        public bool Contains(byte[] value)
        {
            var node = FindNode(value);
            return (node != null);
        }

        public Node FindNode(byte[] value)
        {
            var node = _root;
            var of = node.Offset;
            while (node != null)
            {
                byte[] file_signature = new byte[node.Value.Length];

                if (value.Length > node.Offset + node.Value.Length)
                {
                    if (node.Offset == 1)
                    {
                        of = value.Length - node.Value.Length;
                    }

                    Array.Copy(value, of, file_signature, 0, node.Value.Length);

                    int compare = CompareByteArrays(file_signature, node.Value);
                    if (compare == 0)
                        return node;
                    if (compare < 0)
                        node = node.Left;
                    else
                        node = node.Right;
                }
                else return null;

            }
            return null;
        }

        private void FixTreeAfterInsert(Node node)
        {
            while (node.Parent != null && node.Parent.IsRed)
            {
                if (node.Parent == node.Parent.Parent.Left)
                {
                    var uncle = node.Parent.Parent.Right;
                    if (uncle != null && uncle.IsRed)
                    {
                        node.Parent.IsRed = false;
                        uncle.IsRed = false;
                        node.Parent.Parent.IsRed = true;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Right)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }
                        node.Parent.IsRed = false;
                        node.Parent.Parent.IsRed = true;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    var uncle = node.Parent.Parent.Left;
                    if (uncle != null && uncle.IsRed)
                    {
                        node.Parent.IsRed = false;
                        uncle.IsRed = false;
                        node.Parent.Parent.IsRed = true;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.Left)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }
                        node.Parent.IsRed = false;
                        node.Parent.Parent.IsRed = true;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }
            _root.IsRed = false;
        }

        private void FixTreeAfterRemove(Node node)
        {
            while (node != _root && !node.IsRed)
            {
                if (node == node.Parent.Left)
                {
                    var sibling = node.Parent.Right;
                    if (sibling.IsRed)
                    {
                        sibling.IsRed = false;
                        node.Parent.IsRed = true;
                        RotateLeft(node.Parent);
                        sibling = node.Parent.Right;
                    }
                    if ((sibling.Left == null || !sibling.Left.IsRed) && (sibling.Right == null || !sibling.Right.IsRed))
                    {
                        sibling.IsRed = true;
                        node = node.Parent;
                    }
                    else
                    {
                        if (sibling.Right == null || !sibling.Right.IsRed)
                        {
                            sibling.Left.IsRed = false;
                            sibling.IsRed = true;
                            RotateRight(sibling);
                            sibling = node.Parent.Right;
                        }
                        sibling.IsRed = node.Parent.IsRed;
                        node.Parent.IsRed = false;
                        sibling.Right.IsRed = false;
                        RotateLeft(node.Parent);
                        node = _root;
                    }
                }
                else
                {
                    var sibling = node.Parent.Left;
                    if (sibling.IsRed)
                    {
                        sibling.IsRed = false;
                        node.Parent.IsRed = true;
                        RotateRight(node.Parent);
                        sibling = node.Parent.Left;
                    }
                    if ((sibling.Left == null || !sibling.Left.IsRed) && (sibling.Right == null || !sibling.Right.IsRed))
                    {
                        sibling.IsRed = true;
                        node = node.Parent;
                    }
                    else
                    {
                        if (sibling.Left == null || !sibling.Left.IsRed)
                        {
                            sibling.Right.IsRed = false;
                            sibling.IsRed = true;
                            RotateLeft(sibling);
                            sibling = node.Parent.Left;
                        }
                        sibling.IsRed = node.Parent.IsRed;
                        node.Parent.IsRed = false;
                        sibling.Left.IsRed = false;
                        RotateRight(node.Parent);
                        node = _root;
                    }
                }
            }
            node.IsRed = false;
        }

        private void RotateLeft(Node node)
        {
            var pivot = node.Right;
            node.Right = pivot.Left;
            if (pivot.Left != null)
                pivot.Left.Parent = node;
            pivot.Parent = node.Parent;
            if (node.Parent == null)
                _root = pivot;
            else if (node == node.Parent.Left)
                node.Parent.Left = pivot;
            else
                node.Parent.Right = pivot;
            pivot.Left = node;
            node.Parent = pivot;
        }

        private void RotateRight(Node node)
        {
            var pivot = node.Left;
            node.Left = pivot.Right;
            if (pivot.Right != null)
                pivot.Right.Parent = node;
            pivot.Parent = node.Parent;
            if (node.Parent == null)
                _root = pivot;
            else if (node == node.Parent.Right)
                node.Parent.Right = pivot;
            else
                node.Parent.Left = pivot;
            pivot.Right = node;
            node.Parent = pivot;
        }

        private Node GetSuccessor(Node node)
        {
            if (node.Right != null)
            {
                var successor = node.Right;
                while (successor.Left != null)
                {
                    successor = successor.Left;
                }
                return successor;
            }
            else
            {
                var parent = node.Parent;
                while (parent != null && node == parent.Right)
                {
                    node = parent;
                    parent = parent.Parent;
                }
                return parent;
            }
        }

        private int CompareByteArrays(byte[] first, byte[] second)
        {
            int minLength = first.Length < second.Length ? first.Length : second.Length;
            for (int i = 0; i < minLength; ++i)
            {
                if (first[i] < second[i]) return -1;
                if (first[i] > second[i]) return 1;
            }
            if (first.Length == second.Length) return 0;
            if (first.Length < second.Length) return -1;
            return 1;
        }
    }




}
