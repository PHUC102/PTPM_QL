// View: Program.cs (console application)

// using BasicMVC.Controllers;
using System;
using BasicMVC.Controllers;


class Program
{
    static void Main(string[] args)
    {
        // Biến số
        PersonController personController = new PersonController();

        // Gán giá trị cho biến số
        personController.SetPersonData("Đăng Phúc", 18);

        // Hiển thị giá trị của biến số lên màn hình
        Person person = personController.GetPersonData();
        DisplayPersonData(person);
        // Hằng số
        ConstantController constantController = new ConstantController();
        constantController.DisplayConstants();
        
        /*// Toán tử số học
        ArithmeticController arithmeticController = new ArithmeticController();
        arithmeticController.PerformArithmeticOperations();*/
  
    }

    static void DisplayPersonData(Person person)
    {
        Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
    }
}
