using ConsoleApp36;

List<Student> students = new();

string? option;
do {
    ShowMenu();
    do {
        Console.WriteLine("Enter option: ");
        option = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(option));

    switch (option) {
        case "1":
            AddStudent(students);
            break;
        case "2":
            AddExamToStudent(students);
            break;
        case "3":
            ShowStudentExamResult(students);
            break;
        case "4":
            ShowStudentExams(students);
            break;
        case "5":
            ShowStudentAvg(students);
            break;
        case "6":
            RemoveExam(students);
            break;
        case "0":
            Console.WriteLine("Goodbye!");
            break;
        default:
            Console.WriteLine("Invalid option");
            break;
    }

} while (option != "0");
void RemoveExam(List<Student> students) {
    byte studentNo;
    do {
        Console.WriteLine("Enter student no: ");
    } while (!byte.TryParse(Console.ReadLine(), out studentNo) && (studentNo < 1 || studentNo > students.Count));

    string? examName;
    do {
        Console.WriteLine("Enter exam name: ");
        examName = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(examName));

    foreach (var student in students) {
        if (student.No == studentNo) {
            if (student.Exams.ContainsKey(examName)) {
                student.Exams.Remove(examName);
            }
            break;
        }
    }
}

void ShowStudentAvg(List<Student> students) {
    byte studentNo;
    do {
        Console.WriteLine("Enter student no: ");
    } while (!byte.TryParse(Console.ReadLine(), out studentNo) && (studentNo < 1 || studentNo > students.Count));

    foreach (var student in students) {
        if (student.No == studentNo) {
            Console.WriteLine(student.GetExamAvg());
            break;
        }
    }
}

void ShowStudentExams(List<Student> students) {
    byte studentNo;
    do {
        Console.WriteLine("Enter student no: ");
    } while (!byte.TryParse(Console.ReadLine(), out studentNo) && (studentNo < 1 || studentNo > students.Count));

    foreach (var student in students) {
        if (student.No == studentNo) {
            Console.WriteLine($"Name: {student.Exams.Keys} - Point: {student.Exams.Values}");
        }
    }
}

void ShowStudentExamResult(List<Student> students) {
    byte studentNo;
    do {
        Console.WriteLine("Enter student no: ");
    } while (!byte.TryParse(Console.ReadLine(), out studentNo) && (studentNo < 1 || studentNo > students.Count));

    string? examName;
    do {
        Console.WriteLine("Enter exam name: ");
        examName = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(examName));

    foreach (var student in students) {
        if (student.No == studentNo) {
            Console.WriteLine(student.GetExamResult(examName));
            break;
        }
    }
}

void AddExamToStudent(List<Student> students) {
    byte studentNo;
    do {
        Console.WriteLine("Enter student no: ");
    } while (!byte.TryParse(Console.ReadLine(), out studentNo) && (studentNo < 1 || studentNo > students.Count));

    string? examName;
    do {
        Console.WriteLine("Enter exam name: ");
        examName = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(examName));

    byte examGrade;
    do {
        Console.WriteLine("Enter exam grade: ");
    } while (!byte.TryParse(Console.ReadLine(), out examGrade) && (examGrade < 0 || examGrade > 100));

    foreach (var student in students) {
        if (student.No == studentNo) {
            student.Exams.Add(examName, examGrade);
            break;
        }
    }
}

void AddStudent(List<Student> students) {
    string? fullname;
    do {
        Console.WriteLine("Enter student's fullname: ");
        fullname = Console.ReadLine();
    } while (String.IsNullOrWhiteSpace(fullname));
    students.Add(new Student(fullname, new Dictionary<string, byte>()));
}

static void ShowMenu() {
    Console.WriteLine();
    Console.WriteLine("1. Add student");
    Console.WriteLine("2. Add exam to student");
    Console.WriteLine("3. Show student's exam result");
    Console.WriteLine("4. Show student's all exams");
    Console.WriteLine("5. Show student's average");
    Console.WriteLine("6. Remove exam");
    Console.WriteLine("0. Exit");
    Console.WriteLine();
}