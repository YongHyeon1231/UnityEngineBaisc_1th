using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArray
{
    internal class MyDynamicArray
    {        
        // const 키워드 
        // 상수 키워드. const 키워드가 붙은 변수는 
        // 초기화만 가능하며, 상수처럼 사용된다.
        private const int DEFAULT_SIZE = 1;
        private int[] _data = new int[DEFAULT_SIZE];
        public int Count;
        public int Capacity
        {
            get
            {
                return _data.Length;
            }
        }
        public int this[int index]
        {
            get
            {
                return _data[index];
            }
            set
            {
                _data[index] = value;                
            }
        }

        // 삽입 알고리즘
        // 일반적으로 O(1)
        // 단, Capacity가 모자랄때는 O(N)
        public void Add(int item)
        {
            if (Count >= Capacity)
            {
                int[] tmp = new int[(int)Math.Ceiling(Math.Log10(Capacity)) + 1];
                for (int i = 0; i < Count; i++)
                {
                    tmp[i] = _data[i];
                }
                _data = tmp;
            }

            _data[Count++] = item;
        }

        // 탐색 알고리즘
        // O(N)
        public bool Contains(int target)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_data[i] == target)
                    return true;
            }

            return false;
        }

        public int Find(Predicate<int> match)
        {
            for (int i = 0; i < Count; i++)
            {
                if (match(_data[i]))
                    return _data[i];
            }

            // default 키워드
            // 해당 타입의 고정값을 반환하는 키워드
            return default(int);
        }

        // 삭제 알고리즘
        // O(N)
        public bool Remove(int item)
        {
            int index = -1;
            for (int i = 0; i < Count; i++)
            {
                if (_data[i] == item)
                {
                    index = i;
                    break;
                }
            }

            for (int i = index; i < Count; i++)
            {
                _data[i] = _data[i + 1];
            }

            Count--;
            return index >= 0;
        }

        // 인덱스 삭제 알고리즘
        // O(N)
        public bool RemoveAt(int index)
        {
            if (index > Count - 1)
                return false;

            for (int i = index; i < Count; i++)
            {
                _data[i] = _data[i + 1];
            }
            Count--;
            return true;
        }

        public void Clear()
        {
            //_data = new int[DEFAULT_SIZE];

            for (int i = 0; i < Capacity; i++)
            {
                _data[i] = default(int);
            }
        }
    }
}
