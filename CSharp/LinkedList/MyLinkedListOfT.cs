using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinkedList
{

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

            //이전 노드가 존재한다면
            if (node.Prev != null)
            {
                node.Prev.Next = _tmp1;
                _tmp1.Prev = node.Prev;
            }
            else //이전 노드가 존재하지 않는다면 만들어주기.
            {
                _first = _tmp1;
            }

            node.Prev = _tmp1;
            _tmp1.Next = node;


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
            _tmp1 = _first;

            while (_tmp1 != null)
            {
                if (Comparer<T>.Default.Compare(_tmp1.Value, value) == 0)
                {
                    return _tmp1;
                }

                _tmp1 = _tmp1.Next;
            }

            return null;
        }

        public Node<T> FindLast(T value)
        {
            _tmp1 = _last;
            while (_tmp1 != null)
            {
                if (Comparer<T>.Default.Compare(_tmp1.Value, value) == 0)
                {
                    return _tmp1;
                }
                _tmp1 = _tmp1.Prev;
            }

            return null;
        }

        public bool Remove(Node<T> node)
        {
            if (node == null)
            {
                Console.WriteLine("삭제할 값을 찾지 못했습니다.");
                return false;
            }
            else
            {
                if (node.Prev != null)
                {
                    node.Prev.Next = node.Next;
                }
                else //이전 노드가 아예 없다면 삭제할 다음 노드는 첫번째 노드가 되어야한다.
                {
                    _first = node.Next;
                }

                if (node.Next != null)
                {
                    node.Next.Prev = node.Prev;
                }
                else // 삭제할 노드의 다음 노드가 없다면 삭제할 전의 노드가 마지막 노드가 되어야한다.
                {
                    _last = node.Prev;
                }


                Console.WriteLine("삭제를 완료하였습니다.");
                return true;
            }
        }

        public bool Remove(T value)
        {
            //_tmp1 = Find(value);

            //if (_tmp1 == null)
            //{
            //    Console.WriteLine("삭제할 값을 찾지 못했습니다.");
            //    return false;
            //}
            //else
            //{
            //    if(_tmp1.Prev !=null)
            //    {
            //        _tmp1.Prev.Next = _tmp1.Next;
            //    }
            //    if(_tmp1.Next != null)
            //    {
            //        _tmp1.Next.Prev = _tmp1.Prev;
            //    }

            //    _tmp1.Next = null;
            //    _tmp1.Prev = null;
            //    _tmp1 = null;

            //    Console.WriteLine("삭제를 완료하였습니다.");
            //    return true;
            //}

            return Remove(Find(value));

        }

        public bool RemoveLast(T value)
        {
            return Remove(FindLast(value));
        }

        public MyLinkedListEnum<T> GetEnumator()
        {
            return new MyLinkedListEnum<T>(_first);
        }

        public struct MyLinkedListEnum<K>
        {
            public K Current
            {
                get
                {
                    return _CurrentNode.Value;
                }
            }
            private Node<K> _CurrentNode;
            private Node<K> _first;
            private bool _firstFlag;
            private bool FirstFlag
            {
                get
                {
                    return _firstFlag;
                }
                set
                {
                    if (value)
                        _CurrentNode = _first;

                    _firstFlag = value;
                }
            }
            public MyLinkedListEnum(Node<K> first)
            {
                _first = first;
                _CurrentNode = null;
                _firstFlag = false;
            }

            public bool MoveNext()
            {
                if(_firstFlag == false)
                    FirstFlag= true;
                else
                _CurrentNode = _CurrentNode.Next;

                return _CurrentNode != null;
            }

            public void Reset()
            {
                _CurrentNode = null;
                FirstFlag = false;
            }

        }


    }  
}
