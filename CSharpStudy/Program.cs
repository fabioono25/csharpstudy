using System;
using System.Collections.Generic;
using CSharpStudy.Math;
using System.Linq;
using System.Text;

namespace CSharpStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            #region C# Basic
            //Console.WriteLine("Hello World!");

            #region Section 3 - Primitive Types and Extensions
            
            //const float Pi = 3.14F;
            
            // Byte b = 1;
            // byte b = 2;

            //overflowing
            // try
            // {
            //     unchecked {
            //         Int32 x = Int32.MaxValue;

            //         x = x + 1;

            //         System.Console.WriteLine(x);
            //     }
            // }
            // catch (System.Exception ex)
            // {
            //     System.Console.WriteLine("erro " + ex.Message);
            //     //throw;
            // }

            //Console.WriteLine()            

            // var number = 2;
            // var letterA = 'A';
            // var totalPrice = 12.02;
            // float x = 12.23f;
            // const float y = 12.34f;

            //System.Console.WriteLine("{0} {1}", byte.MinValue, byte.MaxValue);

            //implicit type conversion
            // byte b = 1;
            // int i = b;

            //explicit type conversion
            // int i = 1;
            // byte b = (byte) i;

            // string x = "1";
            // int i = Convert.ToInt32(x);
            // int j = int.Parse(x);

            // string str1="9009";
            // string str2=null;
            // string str3="9009.9090800";
            // string str4="90909809099090909900900909090909"; 
            // int finalResult;
            // finalResult = int.Parse(str1); //success
            // finalResult = int.Parse(str2); // ArgumentNullException
            // finalResult = int.Parse(str3); //FormatException
            // finalResult = int.Parse(str4); //OverflowException 

            // finalResult = Convert.ToInt32(str1); // 9009
            // finalResult = Convert.ToInt32(str2); // 0
            // finalResult = Convert.ToInt32(str3); //FormatException
            // finalResult = Convert.ToInt32(str4); //OverflowException 

            // bool output;
            // output = int.TryParse(str1,out finalResult); // 9009
            // output = int.TryParse(str2,out finalResult); // 0
            // output = int.TryParse(str3,out finalResult); // 0
            // output = int.TryParse(str4, out finalResult); // 0 

            // Console.WriteLine((float) 10 / (float) 3);

                // byte number = 255;
                // number += 2;
                // System.Console.WriteLine(byte.MaxValue);
            
            #endregion

            #region Section 4 - Non-Primitive Types

            // var john = new Person();
            // john.FirstName = "John";
            // john.LastName = "Smith";
            // john.Introduce();

            // var calc = new Calculator();
            // System.Console.WriteLine(calc.Add(1,2));
            
            //arrays
            // var numbers = new int[3] {1, 2, 3};
            // System.Console.WriteLine(string.Join(",", numbers));

            //var x = "asdasdasd";
            // System.Console.WriteLine((int)ShippingMethod.Express);
            
            // var methodId = 3;
            // System.Console.WriteLine((ShippingMethod)methodId);

            // System.Console.WriteLine(ShippingMethod.Express.ToString());

            // var methodName = "Express";
            // var shipping = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);

            //Reference Types and Value Types
            // var a = 10;
            // var b = a;
            // b++;

            // var arr = new int[3] {1, 2, 3};
            // var arr2 = arr;
            // arr2[2] = 0;

            // System.Console.WriteLine(arr[2]);
            // System.Console.WriteLine(arr2[2]);

            #endregion
        
            #region Section 5 - Control Flow

            // var role = "as";
            // switch (role){
            //     case "a":
            //     case "b":
            //         System.Console.WriteLine("as");
            //         break;
            //     default:
            //         System.Console.WriteLine("Default");
            //         break;
            // }

            // System.Console.WriteLine("type your name: ");
            // var input = Console.ReadLine();
            // System.Console.WriteLine(input);

            // var random = new Random();
            // random.Next(-1,2);

            // System.Console.WriteLine((int)'a');
            // System.Console.WriteLine((char)100);

            #endregion
        
            #region Secion 6 - Arrays

//            var numbers = new int[4] {1, 2, 3, 3}; //single-dimensional

            //multi dimension arrays:

            //rectangular 2D array
            // var matrix = new int[3,5]{
            //     {1,2,3,4,5},
            //     {1,2,3,4,5},
            //     {1,2,3,4,5}
            // };

            // var el = matrix[1,2];

            // //jagged array
            // var arr = new int[3][];
            // arr[0] = new int[3];
            // arr[1] = new int[3];
            // arr[2] = new int[3];

            // var el = arr[0][2];

            // var numbers = new [] {3, 2, 4,5, 3, 5 , 12};

            // System.Console.WriteLine(numbers.Length);
            // System.Console.WriteLine(Array.IndexOf(numbers, 4));
            // Array.Clear(numbers,0,2);
            
            // var anotherArray = new int[2];
            // Array.Copy(numbers, anotherArray, 2);

            // System.Console.WriteLine("numb");

            // Array.Sort(numbers);
            // Array.Reverse(numbers);
            // foreach (var item in numbers)
            // {   
            //     System.Console.WriteLine(item);
            // }

            
            //working with lists
            // var numbers = new List<int>() {1, 2, 3};
            // numbers.AddRange(new int[]{3, 4,5,6,1, 1,1});
            
            // foreach (var number in numbers)
            // {
            //     System.Console.WriteLine(number);
            // }

            // System.Console.WriteLine("Index of 3: " + numbers.IndexOf(3)); 
            // System.Console.WriteLine("Index of 3: " + numbers.LastIndexOf(3));

            // System.Console.WriteLine("Count: " + numbers.Count);
            // //numbers.Remove(1);
            // numbers.RemoveAll(_ => _.Equals(1));

            // foreach (var number in numbers)
            // {
            //     System.Console.WriteLine(number);
            // }
            

            #endregion

            #region Section 7 - Dates and Times

            // System.Console.WriteLine(DateTime.Today);
            // System.Console.WriteLine(DateTime.Now);
            // System.Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy hh:mi:ss"));
            // System.Console.WriteLine(DateTime.Now.ToLongDateString());
            // System.Console.WriteLine(DateTime.Now.ToShortDateString());
            // System.Console.WriteLine(DateTime.Now.ToLongTimeString());
            // System.Console.WriteLine(DateTime.Now.ToShortTimeString());                                                

            // var timeSpan = new TimeSpan(1,2,3);
            // var timeSpan2 = new TimeSpan(1,0,0);
            // var timeSpan3 = TimeSpan.FromHours(1);

            // System.Console.WriteLine(timeSpan.Minutes);
            // System.Console.WriteLine(timeSpan.TotalMinutes);

            // System.Console.WriteLine(timeSpan);
            // System.Console.WriteLine(timeSpan.Add(TimeSpan.FromMinutes(8)));

            // System.Console.WriteLine(TimeSpan.Parse("01:12:23"));

            #endregion

            #region Section 8 - Text

            // var fullName = " ";
            // System.Console.WriteLine(String.IsNullOrWhiteSpace(fullName));

            // var price = 12.12F;
            // System.Console.WriteLine(price.ToString("C3"));

            // var sb = new StringBuilder("tittle");
            // sb.Append('-', 10)
            //   .AppendLine()
            //   .Append("asasdasd")
            //   .Insert(0, new string('a', 20));
            
            //var x = sb.ToString().IndexOf('t');

            //System.Console.WriteLine(sb);


            #endregion
        
            #region Section 9 - Files and Directories
            //File, FileInfo, Directory, DirectoryInfo, Path
            #endregion        

            #endregion
        
            #region C# Intermediate

            #region Section 2 - Classes
            //var p = Person2.Parse("john");

            // var customer = new Customer(1);
            // Console.WriteLine(customer.Id);
            // Console.WriteLine(customer.Name);

            // var order = new Order();
            // customer.Orders.Add(order);
            // var point = new Point(10, 20);
            // point.Move(new Point(40,20));
            // System.Console.WriteLine(point.X);

            // var calculator = new Calculator();
            // System.Console.WriteLine(calculator.Add(1,2,3));
            // System.Console.WriteLine(calculator.Add(new int[]{1,23,4,5}));

            // try
            // {
            //     var x = int.Parse("asbc");                
            // }
            // catch (System.Exception)
            // {
            //     System.Console.WriteLine("Conversion vailed");
            // }

            // int number;
            // var result = int.TryParse("123", out number);

            // var cookie = new HttpCookie();
            // cookie["name"] = "mosh";
            // System.Console.WriteLine(cookie["name"]);

            #endregion

            #region Section 3 - Association between classes
            // var text = new Text();
            // text.Width = 100;
            // text.Copy();

            // var dbMigrator = new DbMigrator(new Logger());

            // var logger = new Logger();
            // var installer = new Installer(logger);

            // dbMigrator.Migrate();
            // installer.Install();


            #endregion

            #region Section 4 - Inheritance
            var customer = new Customer();
            
            #endregion

            #endregion
        }
    }


public class GoldCustomer : Customer{
    public void OfferVoucher(){
        //this.
    }
}

#region C# Intermediate
public class Calculator{
    public int Add(params int[] numbers){

        var sum = 0;

        foreach (var number in numbers)
        {
            sum += number;
        }

        return sum;
    }
}

public class Text: PresentationObject{
    public int FontSize { get; set; }
    public string FontName { get; set; }

    public void AddHyperlink(string url){
        System.Console.WriteLine("add link to {0}", url);
    }
}


#endregion    
}
