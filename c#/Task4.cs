using System;
using System.Collections.Generic;
using System.Linq;
namespace std{
    class Student{
        public string Name;
        public int Age;
        public char Grade;
       
        public Student(string name,int age,char grade){
            Name = name;
            Age = age;
            Grade = grade;
        }
    }
    class Task4{
        static void Main()
        {
            List<Student> students = new List<Student>{
                new Student("pradeep",21,'A'),
                new Student("guy",23,'B'),
                new Student("another guy",22,'C'),
                new Student("another another guy",26,'E'),
                new Student("random guy",35,'D')
            };
        string input;
        Console.WriteLine("Enter a threshold");
        input= Console.ReadLine();
        while(!char.IsLetter(input[0]))
        {
        Console.WriteLine("Enter a threshold");        
        input= Console.ReadLine();
        }
        char threshold = char.Parse(input);
        var filteredStudents = students.Where(s => s.Grade < threshold).OrderBy(s=>s.Name);
        foreach(Student student in filteredStudents)
        {
            Console.WriteLine($"Name : {student.Name} Age : {student.Age} Grade:{student.Grade}");
        }
    }
    }

}