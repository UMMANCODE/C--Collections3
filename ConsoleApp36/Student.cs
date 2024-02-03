using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36 {
    internal class Student {
        public readonly byte No;
        private readonly byte _staticNo;
        public string? Fullname;
        public Dictionary<string, byte> Exams;

        public Student(string? fullname, Dictionary<string, byte> exams) {
            No = ++_staticNo;
            Fullname = fullname;
            Exams = exams;
        }

        public void AddExam() {
            string? examName;
            do {
                Console.WriteLine("Enter exam name: ");
                examName = Console.ReadLine();
            } while (String.IsNullOrWhiteSpace(examName));
            byte examGrade;
            do {
                Console.WriteLine("Enter exam grade: ");
            } while (!byte.TryParse(Console.ReadLine(), out examGrade) && (examGrade < 0 || examGrade > 100));
            Exams.Add(examName, examGrade);
        }

        public byte GetExamResult(string examName) {
            if (String.IsNullOrWhiteSpace(examName)) return 0;
            if (Exams.ContainsKey(examName)) {
                return Exams[examName];
            }
            return 0;
        }

        public double GetExamAvg() {
            byte result = 0;
            foreach (var exam in Exams) {
                result += exam.Value;
            }
            return (double)(result / Exams.Count);
        }

    }
}
