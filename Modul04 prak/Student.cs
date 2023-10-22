using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul04_prak
{
    public struct Student
    {
        public string FullName;
        public string Group;
        public int[] Grades;
        public double AverageGrade { get
            {
                try
                {
                    return Grades.Average();
                }
                catch
                {
                    return 0;
                }
            } }
        public bool HasOnlyHighGrades { get
            {
                try { 
                return Grades.All(grade => grade == 4 || grade == 5);
                }
                catch { return false; }
            } 
        } 
    }
}
