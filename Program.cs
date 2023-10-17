// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information

using System.Security.AccessControl;

public class Calculator
{
    public double Sum(double firstNumber, double secondNumber)
    {
        return firstNumber + secondNumber;
    }

    public double Multi(double firstNumber, double secondNumber)
    {
        return firstNumber * secondNumber;
    }

    public double Sub(double firstNumber, double secondNumber)
    {
        return firstNumber - secondNumber;
    }

    public double Div(double firstNumber, double secondNumber)
    {
        if (secondNumber == 0)
        {
            Calculator cal = new Calculator();
            Simple simp = new Simple(cal);
            Console.WriteLine("error:DivideByZeroException");
            simp.Simp();
            
        }
        return firstNumber / secondNumber;
    }
}

public class Simple
{
    Calculator cal;
    public Simple(Calculator cal)
    {
        this.cal = cal;
    }

    public void Simp()
    {
        bool check = true;
        double result = 0;

        try
        {
        Console.WriteLine("Введите первое число");
        double firstNumber = Convert.ToInt64(Console.ReadLine());
        

        while (check == true)
        {
            Console.WriteLine("Введите второе число");
            double secondNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Выберите метод");
            string method = Console.ReadLine();
            
            switch (method)
            {
                case "+":
                result = cal.Sum(firstNumber, secondNumber);
                Console.WriteLine(result);
                break;

                case "*":
                result = cal.Multi(firstNumber, secondNumber);
                Console.WriteLine(result);
                break;

                case "-":
                result = cal.Sub(firstNumber, secondNumber);
                Console.WriteLine(result);
                break;

                case "/":
                try
                {
                result = cal.Div(firstNumber, secondNumber);
                Console.WriteLine(result);
                }

                catch (DivideByZeroException ex){
                    Console.WriteLine("error" + ex);
                }
                break;
                default:
                Simple simp = new Simple(cal);
                Console.WriteLine("error:InvalidValueEntered");
                simp.Simp();
                break;
            }

            firstNumber = result;

            Console.WriteLine("Продолжить?");
            string question = Console.ReadLine();

            switch (question)
            {
                case "Нет":
                Console.WriteLine("Очистить калькулятор?");
                question = Console.ReadLine();
                if (question == "Да")
                {
                    Console.WriteLine("Введите первое число");
                    firstNumber = Convert.ToInt64(Console.ReadLine());
                }
                else
                {
                    check = false;
                }
                break;
            }
        }
        }
        catch (FormatException ex)
        {
            Console.WriteLine("ERR" + ex);
            Simple simp = new Simple(cal);
            simp.Simp();
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("ERR" + ex);
            Simple simp = new Simple(cal);
            simp.Simp();
        }

    }
}

public class Program
{
    static void Main()
    {
        Calculator cal = new Calculator();
        Simple simp = new Simple(cal);
        simp.Simp();
    }
}