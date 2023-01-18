using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Cat : Animal
    {
        // override
        // 재정의 키워드
        // 추상화 함수를 재정의 할 때 사용한다.
        public override void Breath()
        {
            Console.WriteLine("숨 조낸 쉬는중");
        }

        public override void Attack()
        {
            //base 키워드
            // 상위타입 (부모)
            //base.Attack();
            Console.WriteLine($"고양이가 추가로 전기공격을 했다");
        }
    }
}
