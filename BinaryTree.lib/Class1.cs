using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree1.lib
{
    public class BT
    {
        public class Node
        {
            public Node left { get; set; }
            public Node right { get; set; }
            public int value { get; set; }
            public Node(int value)
            {
                this.value = value;
            }

            public Node()
            {

            }

            internal bool IsPresent(Node right, int value)
            {
                throw new NotImplementedException();
            }

            public int Sum
            {
                get
                {
                    if (left == null)
                    {
                        if (right == null)
                            return 0;
                        return right.Sum + right.value;
                    }
                    else if (right == null)
                    {
                        return left.Sum + left.value;
                    }
                    else
                    {
                        return left.value + left.Sum + right.value + right.Sum;
                    }
                }
            }
            public string ToString(Node node)
            {
                string result = "";
                if (node == null)
                {
                    return "";
                }
                result += ToString(node.left);
                result += ToString(node.right);
                result += node.value.ToString();
                return result;
            }

            public int Count { get { return 1 + (left == null ? 0 : left.Count) + (right == null ? 0 : right.Count); } }

            public override string ToString()
            {
                return $"{value}";
            }
        }

        public class BinaryTree
        {
            public Node root { get; set; }

            
            public BinaryTree()
            {
                root = null;
            }

            public BinaryTree(int i)
            {
                root = new Node(i);
            }
            public void Add(int i)
            {
                Node new_node = new Node(i);
                new_node.left = null;
                new_node.right = null;
                Node current_node = root;

                if (current_node == null)
                {
                    root = new_node;
                }
                else
                {
                    while (current_node != null)
                    {
                        Node previous_node = current_node;
                        if (i < current_node.value)
                        {
                            current_node = current_node.left;
                        }
                        else
                        {
                            current_node = current_node.right;
                        }
                        if (i < previous_node.value)
                        {
                            previous_node.left = new_node;
                        }
                        else
                        {
                            previous_node.right = new_node;
                        }
                    }

                }
                

            }

            public bool IsPresent(int value)
            {
                Node current_node = root;
                if (current_node == null)
                {
                    return false;
                }
                if (value == current_node.value)
                {
                    return true;
                }
                else if (current_node.value > value)
                {
                    return current_node.left.IsPresent(current_node.left, value);
                }
                else if (current_node.value < value)
                {
                    return current_node.right.IsPresent(current_node.right, value);
                }
                return false;
            }

            public int Sum
            {
                get
                {
                    return root.value + root.Sum;
                }
            }

            public int Depth(Node root)
            {
                if (root == null)
                {
                    return 0;
                }
                if (root.left == null && root.right == null)
                {
                    return 1;
                }
                else
                {
                    int DepthLeft = Depth(root.left); //recursion to get the depth of every child//
                    int DepthRight = Depth(root.right);
                    if (DepthLeft > DepthRight) // choose the bigger one // 
                    {
                        return (DepthLeft + 1); // add one for the root depth which is not includede here //
                    }
                    else
                    {
                        return (DepthRight + 1); 
                    }
                }
                
            }

            public void Delete(int i)
            {
                Node node = new Node(i);
                Node current_node = root; // Find node to delete
                while (current_node != null && current_node != node)
                {
                    Node previous_node = current_node;
                    if ( node.value < current_node.value )
                    {
                        current_node = current_node.left;
                    }
                    else
                    {
                        current_node = current_node.right;
                    }
                    if (current_node != null)
                    {
                        if (current_node.left == null && current_node.right == null) 
                        {
                            if (previous_node.value > current_node.value)
                            {
                                previous_node.left = null;
                            }
                            else
                            {
                                previous_node.right = null;
                            }
                        }
                        return;
                    }
                    else if (current_node.right == null) 
                    {
                        if (previous_node.value > current_node.value)
                        {
                            previous_node.left = current_node.left;
                        }
                        else
                        {
                            previous_node.right = current_node.left;
                        }
                    }
                    else
                    {
                        node.right = current_node.right; 
                        if (node.right.left != null)
                        {
                            Node smallest_node = node.right;

                            while (smallest_node.left != null)
                            {
                                previous_node = smallest_node;
                                smallest_node = smallest_node.right;
                            }
                            current_node.value = smallest_node.value;
                            previous_node.left = null;
                        }
                    }
                }
            }

            public int Count
            {
                get
                {
                    return root == null ? 0 : root.Count;
                }
            }

            public override string ToString()
            {
                if (root == null)
                    return "count = 0";
                return $"Count = {root.Count}";
            }
        }
    }
}

