using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class AVLTree<T> : IEnumerable<T> where T : IComparable
    {
        public AVLTreeNode<T> Head
        {
            get;
            internal set;
        }

        public int Count
        {
            get;
            private set;
        }

        public IEnumerator<T> InOrderTraversal()
        {
            if (Head != null)
            {
                Stack<AVLTreeNode<T>> stack = new Stack<AVLTreeNode<T>>();
                AVLTreeNode<T> current = Head;

                stack.Push(current);
                bool goToLeft = true;

                while (stack.Count > 0)
                {
                    if (goToLeft)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goToLeft = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goToLeft = false;
                    }
                }
            }
        }

        public void Add(T value)
        {
            if(Head == null)
            {
                Head = new AVLTreeNode<T>(value, null, this);
            }
            else
            {
                AddTo(value, Head);
            }
        }

        private void AddTo(T value, AVLTreeNode<T> node)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if(node.Left == null)
                {
                    node.Left = new AVLTreeNode<T>(value, node, this);
                }
                else
                {
                    AddTo(value, node.Left);
                }
            }
            else
            {
                if(node.Right == null)
                {
                    node.Right = new AVLTreeNode<T>(value, node, this);
                }
                else
                {
                    AddTo(value, node.Left);
                }
            }

        }

        public bool Contain(T value)
        {
            return Find(value) != null;  
        }

        public bool Remove(T value)
        {
            AVLTreeNode<T> current = Find(value);

            if(current == null)
            {
                return false;
            }

            AVLTreeNode<T> treeToBalance = current.Parent;
            Count--; //уменьшение количества узлов

            //если удаляемый узел не имеет правого потомка
            if (current.Right == null)
            {
                //если удаляемый узел является корневым
                if (current == Head)
                {
                    Head = current.Left;

                    //удаляем ссылку на родителя
                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = Head.Value.CompareTo(current.Value);

                    if (result > 0)
                    {
                        current.Parent.Left = current.Left;
                    }
                    else if (result < 0)
                    {
                        current.Parent.Right = current.Left;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                //если удаляемый узел является корневым
                if (current == Head)
                {
                    Head = current.Right;

                    //удаляем ссылку на родителя
                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = Head.Value.CompareTo(current.Value);

                    if (result > 0)
                    {
                        current.Parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        current.Parent.Right = current.Right;
                    }

                }
            }
            else
            {
                AVLTreeNode<T> mostLeft = current.Right.Left;
                //нахождение самого левого потомка
                while (mostLeft.Left != null)
                {
                    mostLeft = mostLeft.Left;
                }

                mostLeft.Parent.Left = mostLeft.Right;

                mostLeft.Left = current.Left;
                mostLeft.Right = current.Right;

                if (Head == current)
                {
                    Head = mostLeft;
                    if (Head != null)
                    {
                        Head.Parent = null;
                    }
                }
                else
                {
                    int result = Head.Value.CompareTo(current.Value);
                    //если родительский узел больше
                    if (result > 0)
                    {
                        current.Parent.Left = mostLeft;
                    }
                    //если родительский узел меньше
                    else if (result < 0)
                    {
                        current.Parent.Right = mostLeft;
                    }
                }
            }
                if(treeToBalance != null)
                {
                    treeToBalance.Balance();
                }
                else
                {
                    if (Head != null)
                    {
                        Head.Balance();
                    }
                 }
            return true;
        }

        AVLTreeNode<T> Find(T value)
        {
            AVLTreeNode<T> current = Head;
            while (current != null)
            {
                int result = value.CompareTo(current.Value);

                if (result < 0)
                {
                    current = current.Left;
                }
                else if (result > 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }
            return current;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InOrderTraversal();
        }
    }
}
