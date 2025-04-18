using System;
using System.Collections.Generic;
using System.Linq;

public interface IEntity
{
    int Id { get; set; }
}


public interface IRepository<T> where T : IEntity
{
    void Add(T item);           
    T Get(int id);              
    IEnumerable<T> GetAll();
    void Update(T item);        
    void Delete(int id);        
}
public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly List<T> _items = new List<T>();
    private int _nextId = 1;

    public void Add(T item)
    {
        item.Id = _nextId++;
        _items.Add(item);
    }

    public T Get(int id)
    {
        return _items.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    public void Update(T item)
    {
        var index = _items.FindIndex(x => x.Id == item.Id);
        if (index != -1)
            _items[index] = item;
    }

    public void Delete(int id)
    {
        var item = Get(id);
        if (item != null)
            _items.Remove(item);
    }
}


public class Student : IEntity
{
    public int Id { get; set; }  
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
    
        IRepository<Student> studentRepo = new InMemoryRepository<Student>();

        while (true)
        {
            Console.WriteLine("\n--- Student Repository ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View All Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Choose: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
            
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    int age = int.Parse(Console.ReadLine());
                    studentRepo.Add(new Student { Name = name, Age = age });
                    Console.WriteLine("Student added.");
                    break;

                case "2":
                  
                    foreach (var s in studentRepo.GetAll())
                    {
                        Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Age: {s.Age}");
                    }
                    break;

                case "3":
              
                    Console.Write("Enter ID to update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    var studentToUpdate = studentRepo.Get(updateId);
                    if (studentToUpdate != null)
                    {
                        Console.Write("New Name: ");
                        studentToUpdate.Name = Console.ReadLine();
                        Console.Write("New Age: ");
                        studentToUpdate.Age = int.Parse(Console.ReadLine());
                        studentRepo.Update(studentToUpdate);
                        Console.WriteLine("Student updated.");
                    }
                    else Console.WriteLine("Student not found.");
                    break;

                case "4":
                 
                    Console.Write("Enter ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    studentRepo.Delete(deleteId);
                    Console.WriteLine("Student deleted.");
                    break;

                case "5":
                
                    return;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
