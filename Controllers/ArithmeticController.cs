using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BasicMVC.Models;
namespace BasicMVC.Controllers;
// Controller: ArithmeticController.cs
public class ArithmeticController
{
    public void PerformArithmeticOperations()
    {
        int number1, number2;

        Console.WriteLine("Nhập vào số thứ nhất:");
        while (!int.TryParse(Console.ReadLine(), out number1))
        {
            Console.WriteLine("Vui lòng nhập vào một số nguyên hợp lệ:");
        }

        Console.WriteLine("Nhập vào số thứ hai:");
        while (!int.TryParse(Console.ReadLine(), out number2))
        {
            Console.WriteLine("Vui lòng nhập vào một số nguyên hợp lệ:");
        }

        // Tính và hiển thị hiệu của 2 số
        int difference = number1 - number2;
        Console.WriteLine($"Hiệu của {number1} và {number2} là: {difference}");

        // Tính và hiển thị tích của 2 số
        int product = number1 * number2;
        Console.WriteLine($"Tích của {number1} và {number2} là: {product}");

        // Tính và hiển thị kết quả của phép chia lấy nguyên và phép chia lấy dư
        if (number2 != 0)
        {
            int quotient = number1 / number2;
            int remainder = number1 % number2;
            Console.WriteLine($"Phép chia lấy nguyên của {number1} và {number2} là: {quotient}");
            Console.WriteLine($"Phép chia lấy dư của {number1} và {number2} là: {remainder}");
        }
        else
        {
            Console.WriteLine("Không thể chia cho số 0.");
        }
    }
}