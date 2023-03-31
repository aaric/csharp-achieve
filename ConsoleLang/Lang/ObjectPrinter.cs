using System;
using System.Collections.Generic;

namespace ConsoleLang.Lang
{
    public class Exam
    {
        public string Subject { get; set; }
        public int Grade { get; set; }
        public DateTime time { get; set; }

        public Exam(string subject, int grade)
        {
            this.Subject = subject;
            this.Grade = grade;
            this.time = DateTime.Now;
        }
    }

    public class Student
    {
        private long Id { get; }
        private string Name { get; }
        private int Age { get; set; }

        private List<Exam> Exams { get; set; }

        private int Score
        {
            get
            {
                int result = 0;
                if (null != this.Exams)
                {
                    foreach (var exam in Exams)
                    {
                        result += exam.Grade;
                    }
                }

                return result;
            }
        }

        private static long _total = 0;

        public Student(long id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.Exams = new List<Exam>();
            _total++;
        }

        public void addExam(Exam exam)
        {
            this.Exams.Add(exam);
        }

        public override string ToString()
        {
            return $"{this.GetType()}(Id={this.Id}, Name={this.Name}, Age={this.Age}, Score={this.Score})";
        }
    }

    public class ObjectPrinter
    {
        public static void print()
        {
            var s1 = new Student(10000L, "Aaric");
            s1.addExam(new Exam("Chinese", 80));
            s1.addExam(new Exam("Math", 80));
            s1.addExam(new Exam("English", 80));
            Console.WriteLine(s1.ToString());
        }
    }
}