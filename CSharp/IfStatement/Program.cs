using System;

namespace IfStatement
{
    
    internal class Program
    {
        static bool condition1 = false;
        static bool condition2 = false;
        static bool condition3 = false;

        static void Main(string[] args)
        {
            /*if (조건1)
            {
                조건 1이 참일 때 실행할 내용
            }
            else if (조건 2)
            {
                조건 1이 거짓이고 조건2가 참일 때 실행할 내용
            }
            else
            {
                위 조건(들) 이 모두 거짓일 때 실행할 내용
            }*/

            if (condition1)
            {
                Console.WriteLine("조건 1이 참이다");
            }
            else if (condition2)
            {
                Console.WriteLine("조건 1이 거짓이고 조건 2가 참이다");
            }
            else
            {
                Console.WriteLine("조건 1,2 모두 거짓이다.");
            }
            

        }
    }
}
