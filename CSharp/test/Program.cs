using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLinkedList<int> list = new MyLinkedList<int>();
            list.AddLast(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddLast(4);


            Console.WriteLine(list.Last.Value);
            Console.WriteLine(list.Last.Prev.Value);

        }
    }

    internal class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Prev;

        public Node(T value)
        {
            Value = value;
        }
    }



    internal class MyLinkedList<T>
    {
        //public Node<T> First
        //{
        //    get
        //    {
        //        return _first;
        //    }
        //}
        public Node<T> First => _first;
        public Node<T> Last => _last;

        private Node<T> _first, _last, _tmp1, _tmp2;

        public int Count
        {
            get
            {
                int count = 0;
                _tmp1 = _first;
                while (_tmp1 != null)
                {
                    count++;
                    _tmp1 = _tmp1.Next;
                }
                return count;
            }
        }

        //삽입 알고리즘
        // O(1)
        public void AddFirst(T value)
        {
            _tmp1 = new Node<T>(value);

            //노드가 현재 하나이상 존재한다면
            if (_first != null)
            {
                _tmp1.Next = _first;
                _first.Prev = _tmp1;
            }
            // 노드가 하나도 없다면
            if (_last == null)
            {
                _last = _tmp1;
            }
            _first = _tmp1;
        }

        public void AddLast(T value)
        {
            _tmp1 = new Node<T>(value);
            //노드가 현재 하나이상 존재한다면
            if (_last != null)
            {
                _last.Next = _tmp1;
                _tmp1.Prev = _last;
            }
            //노드가 하나도 없다면
            if (_first == null)
            {
                _first = _tmp1;
            }
            _last = _tmp1;


        }

        public void AddBefore(Node<T> node, T value)
        {
            _tmp1 = new Node<T>(value);

            if(node.Prev!=null)
            {
                node.Prev.Next = _tmp1;
                _tmp1.Prev = node.Prev;
            }
            else
            {
                _first = _tmp1;
            }

            _tmp1.Next = node;
            node.Prev = _tmp1;

        }

        public void AddAfter(Node<T> node, T value)
        {
            _tmp1 = new Node<T>(value);

            if (node.Next != null)
            {
                node.Next.Prev = _tmp1;
                _tmp1.Next = node.Next;
            }
            else
            {
                _last = _tmp1;
            }

            node.Next = _tmp1;
            _tmp1.Prev = node;

        }

        public Node<T> Find(T value)
        {
            _tmp1 = new Node<T>(_first.Value);

            while (_tmp1 != null)
            {
                //노드가 하나 이상 존재 한다면
                if (_first != null)
                {
                    if (Comparer<T>.Default.Compare(_tmp1.Value, value) == 0)
                    {
                        Console.WriteLine("값을 찾았습니다.");
                        return _tmp1;
                    }
                    //다음 노드가 있다면
                    else if (_first.Next != null)
                    {
                        _tmp1 = new Node<T>(_first.Next.Value);
                    }
                    else
                    {
                        Console.WriteLine("찾으려고 하는 값이 없습니다.");
                        return null;
                    }
                }
            }

            return null;
        }

        public Node<T> FindLast(T value)
        {
            _tmp1 = new Node<T>(_last.Value);

            while (_tmp1 != null)
            {
                //노드가 하나 이상 존재 한다면
                if (Comparer<T>.Default.Compare(_tmp1.Value, value) == 0)
                {
                    Console.WriteLine("값을 찾았습니다.");
                    return _tmp1;
                }
                //이전 노드가 있다면
                else if (_last.Prev != null)
                {
                    _tmp1 = new Node<T>(_last.Prev.Value);
                }
                else
                {
                    Console.WriteLine("찾으려고 하는 값이 없습니다.");
                    return null;
                }
            }

            return null;
        }

        public bool Remove(T value)
        {
            _tmp1 = Find(value);
            //삭제할 값을 찾았다면
            if(_tmp1 != null)
            {
                _tmp1.Prev.Next = _tmp1.Next;
                _tmp1.Next.Prev = _tmp1.Prev;
                Console.WriteLine("삭제를 완료하였습니다.");
                _tmp1 = null;
            }
            else
            {
                Console.WriteLine("삭제할 값을 찾지 못했습니다.");
            }
            return false;
        }

        public bool RemoveLast(T value)
        {
            _tmp1 = FindLast(value);
            if (_tmp1 != null)
            {
                _tmp1.Prev.Next = _tmp1.Next;
                _tmp1.Next.Prev = _tmp1.Prev;
                Console.WriteLine("삭제를 완료하였습니다.");
                _tmp1 = null;
            }
            else
            {
                Console.WriteLine("삭제할 값을 찾지 못했습니다.");
            }
            return false;
        }
    }




}
