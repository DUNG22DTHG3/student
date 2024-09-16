# student
using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class Program
{
    public static void Main()
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "An", Age = 16 },
            new Student { Id = 2, Name = "Binh", Age = 17 },
            new Student { Id = 3, Name = "Cuong", Age = 15 },
            new Student { Id = 4, Name = "Dung", Age = 18 },
            new Student { Id = 5, Name = "Anh", Age = 16 },
            new Student { Id = 6, Name = "Hien", Age = 20 }
        };

        // a. In danh sach toan bo danh sach hoc sinh
        Console.WriteLine("Danh sach hoc sinh:");
        students.ForEach(s => Console.WriteLine($"Id: {s.Id}, Name: {s.Name}, Age: {s.Age}"));

        // b. Tim va in ra danh sach cac hoc sinh co tuoi tu 15 den 18
        var age15to18 = students.Where(s => s.Age >= 15 && s.Age <= 18);
        Console.WriteLine("\nHoc sinh co tuoi tu 15 den 18:");
        foreach (var student in age15to18)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
        }

        // c. Tìm và in ra hoc sinh có tên bắt đầu bằng chữ "A"
        var nameStartsWithA = students.Where(s => s.Name.StartsWith("A"));
        Console.WriteLine("\nHoc sinh co ten bat dau bang chu 'A':");
        foreach (var student in nameStartsWithA)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
        }

        // d. Tính tổng tuổi của tất cả học sinh trong danh sách
        int totalAge = students.Sum(s => s.Age);
        Console.WriteLine($"\nTong tuoi cua tat ca hoc sinh: {totalAge}");

        // e. Tìm và in ra học sinh có tuổi lớn nhất
        var oldestStudent = students.OrderByDescending(s => s.Age).FirstOrDefault();
        Console.WriteLine($"\nHoc sinh co tuoi lon nhat: Id: {oldestStudent.Id}, Name: {oldestStudent.Name}, Age: {oldestStudent.Age}");

        // f. Sắp xếp danh sách học sinh theo tuổi tăng dần và in ra danh sách sau khi sắp xếp
        var sortedStudents = students.OrderBy(s => s.Age);
        Console.WriteLine("\nDanh sach hoc sinh theo tuoi tang dan:");
        foreach (var student in sortedStudents)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
        }
    }
}
