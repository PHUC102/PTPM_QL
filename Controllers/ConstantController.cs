// Controller: ConstantController.cs
using System;

public class ConstantController
{
    public void DisplayConstants()
    {
        // Khai báo và gán giá trị cho các hằng số
        const int NumberConstant = 10;
        const double Pi = 3.14;
        const string Message = "Hello, Đăng Phúc!";

        // Hiển thị giá trị của các hằng số lên màn hình
        Console.WriteLine($"Giá trị của hằng số số nguyên là: {NumberConstant}");
        Console.WriteLine($"Giá trị của hằng số số thực là: {Pi}");
        Console.WriteLine($"Giá trị của hằng số chuỗi là: {Message}");
    }
}
