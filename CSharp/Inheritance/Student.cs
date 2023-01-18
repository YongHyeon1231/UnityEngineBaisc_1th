using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Student : Person , IAttackable
    {
        public int StudentNum { get; set; }
        public char AverageMark { get; set; }
        public bool IsEligibleToEnroll
        {
            get
            {
                return AverageMark == 'A';
            }
        }

        private string[] _seminarsTaken = new string[5];
        private int _seminarsTakenCount;
        public bool TakenSeminar
        {
            get
            {
                return _seminarsTaken != null && _seminarsTaken.Length > 0;
            }
        }

        public Student(string name, int phoneNumber, string emailAddress) 
            : base(name, phoneNumber, emailAddress)
        {
        }
        public void TakeSeminars(string seminars)
        {
            _seminarsTaken[_seminarsTakenCount++]= seminars;
        }

        public void Attack()
        {
            Console.WriteLine($"사람 {Name} 가 공격했다.");
        }
    }
}
