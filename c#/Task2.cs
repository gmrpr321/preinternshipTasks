using System;
namespace std{
class Person{
    string name;
    int age;
    public Person(string name,int age)
    {
        this.name = name;
        this.age = age;
    }
    public void introduce()
    {
        Console.WriteLine($"Hi!. I'm {name} and I'm {age} years old.");
    }
}
class Task2{
    public static void Main()
    { 
Person pradeep = new Person("Pradeep",21);
Person mark =  new Person("Mark",30);
pradeep.introduce();
mark.introduce();
    }
}
}