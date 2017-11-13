using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVLTree
{
    class AVLTreeNode<TNode> : IComparable<TNode> where TNode : IComparable
    {
        AVLTree<TNode> tree;

        AVLTreeNode<TNode> left;
        AVLTreeNode<TNode> right;


        //Tree указатель на текущее дерево
        public AVLTreeNode(TNode value, AVLTreeNode<TNode> parent, AVLTree<TNode> tree)
        {
            Parent = parent;
            this.tree = tree;
            Value = value;
        }

        internal void Balance()
        {
            if(State == TreeState.LeftHeavy)
            {
                if(Right != null && Right.BalanceFactor < 0)
                {
                    RightLeftRotation();
                }
                else
                {
                    LeftRotation();   
                }
            }
            else if(State == TreeState.RightHeavy)
            {
                if(Left != null && Left.BalanceFactor > 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    RightRotation(); 
                }

            }
        }

        void LeftRotation()
        {
            AVLTreeNode<TNode> newroot = Right;
            Replace(newroot);

            Right = newroot.Left;
            newroot.Left = this;
        }

        void RightRotation()
        {
            AVLTreeNode<TNode> newroot = Left;
            Replace(newroot);

            this.Left = newroot.Right;
            newroot.Right = this;
        }

        void RightLeftRotation()
        {
            Right.RightRotation();
            LeftRotation();
        }
        void LeftRightRotation()
        {
            Left.LeftRotation();
            RightRotation();
        }

        void Replace(AVLTreeNode<TNode> newroot)
        {
           if(this.Parent != null)
            {
                if(this == Parent.Left)
                {
                    Parent.Left = newroot;
                }
                if(this == Parent.Right)
                {
                    Parent.Right = newroot;
                }
            }
            else
            {
                tree.Head = newroot;
            }
            newroot.Parent = this.Parent;
            this.Parent = newroot;

        }

        int BalanceFactor
        {
            get => RightHeight - LeftHeight;
        }

        TreeState State
        {
            get
            {
                if((LeftHeight - RightHeight) > 1)
                {
                    return TreeState.LeftHeavy;
                    
                }

                if((RightHeight - LeftHeight) > 1)
                {
                    return TreeState.RightHeavy;
                }
                return TreeState.Balanced;
            }
        }

        int LeftHeight
        {
            get => MaxChildHeight(Left);
        }

        int RightHeight
        {
            get => MaxChildHeight(Right);
        }

        public int MaxChildHeight(AVLTreeNode<TNode> node)
        {
            if(node != null)
            {
                return 1 + Math.Max(MaxChildHeight(node.Left), MaxChildHeight(node.Right));
            }
            return 0;
        }

        public AVLTreeNode<TNode> Right
        {
            get => right;
            internal set
            {
                right = value;
                if(right != null)
                {
                    right.Parent = this;
                }
            }

        }

        public AVLTreeNode<TNode> Left
        {
            get => left;
            set
            {
                left = value;
                if(left != null)
                {
                    left.Parent = this;
                }
            }

        }


        public AVLTreeNode<TNode> Parent
        {
            get;
            internal set;
        }

        public TNode Value
        {
            get;
            internal set;
        }

        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
    }
}
