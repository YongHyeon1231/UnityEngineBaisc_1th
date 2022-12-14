using System;

namespace ClassExample_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Human human1 = new Human(100, 200.0f, '남');
            Human human2 = new Human(50, 150.0f, '여');
            human1.printHumanAge();
            human2.printHumanAge();

        }
    }

    class Human
    {
        Human() { }
        ~Human() { }

        public Human(int age, float height, char gender)
        {
            this.age = age;
            this.height = height;
            this.gender = gender;
        }
        

        int age;
        float height;
        char gender;
            
        public void printHumanAge()
        {
            Console.WriteLine($"Human Age : {this.age}");
        }

    }
}
