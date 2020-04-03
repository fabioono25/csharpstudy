using CSharpStudy.CSharp1;
using CSharpStudy.CSharp1_2;
using CSharpStudy.Generics;
using CSharpStudy.Polymorphism.Runtime;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CSharpStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            #region C# 1.0

            //value types, reference types, boxing vs unboxing
            // ValueTypesExample.ExecuteExample();
            // ReferenceTypesExample.ExecuteExample();
            // BoxingUnboxing.ExecuteExample();

            //classes
            //TestPerson.ExecuteExample();

            //interfaces
            //InterfaceExample.ExecuteExample();

            //events
            //EventExample.ExecuteExample();
            //EventExample2.ExecuteExample();

            //delegates
            //DelegateExample.ExecuteExample();

            //atributes
            //AttributeExample.ExecuteExample();
            #endregion

            #region C# 1.2
            //ForEachIDisposable.ExecuteExample();
            //ReflectionTest.ExecuteExample();
            //UnsafeTest.ExecuteExample();
            //CheckUncheck.ExecuteExample();
            //ConstructorsDestructors.ExecuteExample();
            UsingTest.ExecuteExample();
            
            #endregion

            #region C# Basic
            //Console.WriteLine("Hello World!");

            #region Section 3 - Primitive Types and Extensions

            //const float Pi = 3.14F;

            // Byte b = 1;
            // byte b = 2;

            //overflowing
            //byte number = byte.MaxValue;
            ////number = number++;
            //number = ++number; //0
            //number = ++number; //1
            //Console.WriteLine(number); //1

            //byte number = 255;

            //number += 2;

            //Console.WriteLine(number);

            //checked
            //{
            //    //number = number + 1; //exception
            //}


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

            //scope:
            //{
            //    byte a = 1;
            //    {
            //        byte b = 2;
            //    }
            //}
            //Console.WriteLine(a); //not accessible in tis context

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

            //short s = short.MaxValue;
            //byte b = (byte)s; //255

            //float f = 1.0f;
            //int i = (int)f; //1

            // string x = "1";
            // int i = Convert.ToInt32(x);
            // int j = int.Parse(x);

            //non-compatible types
            //string x = "1";
            //int i = Convert.ToInt32(x);
            //int z = int.Parse(x);



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

            //var x = new int[3] { 1, 2, 3 };

            //string x = "abc";
            //string z = x;
            //z = "cde";
            //Console.WriteLine($"x: {x} - z: {z}");

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
            //Console.WriteLine(ShippingMethod.Express); //Express

            //System.Console.WriteLine((int)ShippingMethod.Express); //3

            //var methodId = 3;
            //System.Console.WriteLine((ShippingMethod)methodId); //Express

            //System.Console.WriteLine(ShippingMethod.Express.ToString()); //Express

            //var methodName = "Express";
            //var shipping = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName); 

            //Console.WriteLine(shipping); //Express

            //Reference Types and Value Types
            // var a = 10;
            // var b = a;
            // b++;

            // var arr = new int[3] {1, 2, 3};
            // var arr2 = arr;
            // arr2[2] = 0;

            // System.Console.WriteLine(arr[2]);
            // System.Console.WriteLine(arr2[2]);

            // byte number = byte.MaxValue;

            // number = number++;
            // number = number++;
            // number = ++number;
            // number = ++number;

            // Console.WriteLine(number);

            //Console.WriteLine(TaxCalculator.Calculate());

            #endregion

            #region Section 5 - Control Flow

            //var role = "as";
            //switch (role)
            //{
            //    case "a":
            //    case "b":
            //        System.Console.WriteLine("as");
            //        break;
            //    default:
            //        System.Console.WriteLine("Default");
            //        break;
            //}

            // System.Console.WriteLine("type your name: ");
            // var input = Console.ReadLine();
            // System.Console.WriteLine(input);

            //var random = new Random();
            //random.Next(-1,2);

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

            //var customer = new Customer(1);
            //Console.WriteLine(customer.Id);
            //Console.WriteLine(customer.Name);

            // var order = new Order();
            // customer.Orders.Add(order);
            // var point = new Point(10, 20);
            // point.Move(new Point(40,20));
            // System.Console.WriteLine(point.X);

            //var calculator = new Calculator();
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
            //var customer = new Customer();
            //var car = new Car("123123123");  

            //upcasting
            // var text = new Text(10,"asd");
            // Shape shape = text;

            // text.Width = 200;
            // shape.Width = 100;

            // System.Console.WriteLine(text.Width);

            // StreamReader reader = new StreamReader(new MemoryStream());
            // StreamReader reader = new StreamReader(new FileStream());

            //downcasting
            // Shape shape = new Text(12, "adasd"); //shape has limited vision
            // Text text = (Text) shape;

            //boxing
            // var list = new ArrayList();
            // list.Add(1); //boxing will happen, get back unboxing
            // list.Add("asdas"); //not boxing
            // list.Add(DateTime.Today); //will boxing

            // var number = (int)list[1]; //InvalidCastException

            // var anotherList = new List<int>();
            // anotherList.Add(1); //type safety with no boxing

            // var names = new List<string>();
            // names.Add("");//no boxing

            #endregion

            #region Section 5 - Polymorphism
            // var x = new Circle();
            // x.Draw();

            // var shapes = new List<Shape>();
            // shapes.Add(new Circle());

            #endregion

            #region Section 6 - Interfaces

            #endregion

            #endregion

            #region C# Advanced

            //Generics:
            //var numbers = new GenericList<int>();
            //numbers.Add(10);

            // var books = new GenericList<Book>();
            // books.Add(new Book());

            // var dictionary = new GenericDictionary<string, Book>();
            // dictionary.Add("123", new Book());

            // var number = new Nullable<int>();
            // System.Console.WriteLine("HasValue? " + number.HasValue);
            // System.Console.WriteLine("Actual value: " + number.GetValueOrDefault());

            ////Delegates:
            //var processor = new PhotoProcessor();
            //var filters = new PhotoFilters();
            ////PhotoProcessor.PhotoFilterHandler filterHandler = filters.Resize;
            //Action<Photo> filterHandler = filters.Resize;
            //filterHandler += filters.ApplyContrast;
            //filterHandler += RemoveRedEye;

            //processor.Process("photo.jpg", filterHandler);

            //Lambda Expressions:
            // System.Console.WriteLine(Square(4));
            // Func<int, int> square = number => number * number;
            // System.Console.WriteLine(square(5));

            // const int factor = 5;
            // Func<int, int> multiplier = n => n * factor;
            // System.Console.WriteLine(multiplier(3));

            // var books = new BookRepository().GetBooks();
            // var cheapBooks = books.FindAll(IsCheaperThan10Dollars);
            // var cheapBooksLambda = books.FindAll(b => b.Price < 10);

            // foreach (var book in cheapBooks)
            // {
            //     System.Console.WriteLine(book.Title);
            // }

            //Events and Delegates:
            //var video = new Video() { Title = "Video 1" };
            //var videoEncoder = new VideoEncoder(); //publisher
            //var mailService = new MailService(); //subscriber
            //var messageService = new MessageService(); //subscriber

            //videoEncoder.VideoEncoded += mailService.OnVideoEncoded; //subscription   
            //videoEncoder.VideoEncoded += messageService.OnVideoEncoded;

            //videoEncoder.Encode(video);

            //Extension Methods:
            //var post = "this is a big string, that it is very long and we need ssss";
            //var shortenedPost = post.Shorten(5);
            //System.Console.WriteLine(shortenedPost);

            //LINQ:
            //var books = new BookRepository().GetBooks();

            //LINQ Query Operators:
            // var cheapBooks1 = 
            //     from b in books
            //     where b.Price < 50
            //     orderby b.Title descending
            //     select b.Title;

            //LINQ Extension Methods
            // var cheapBooks = books.Where(b => b.Price < 50)
            //         .OrderByDescending(b => b.Price)
            //         .Select(b => b.Title);

            // foreach (var book in cheapBooks)
            // {
            //     //System.Console.WriteLine(book.Title + " - " + book.Price);
            //     System.Console.WriteLine(book);
            // }

            // var pagedBooks = books.Skip(2).Take(30);

            // foreach (var book in pagedBooks)
            // {
            //     System.Console.WriteLine(book.Title);
            // }

            // System.Console.WriteLine(book);

            //Nullable Types:

            // Nullable<DateTime> date = null;

            //DateTime? date2 = null;
            //DateTime dataX = date2;
            // DateTime dataX = date2 ?? DateTime.Today;//date2.GetValueOrDefault();
            // DateTime? date3 = date2;

            //Dynamic:
            //object obj = "mosh";
            //obj.GetHashCode()

            //reflexion
            // var methodInfo = obj.GetType().GetMethod("GetHashCode");
            // methodInfo.Invoke(null, null);

            //using dynamic
            // dynamic obj2 = "mosh";
            // obj2 = 1;
            // System.Console.WriteLine(obj2);
            // obj2.Optimize();

            // int i = 5;
            // dynamic d = i;
            // long l = d;

            //Exception Handling:
            // try
            // {
            // using (StreamReader r = new StreamReader(@"asdasd"))
            // {

            // }                
            //     var calc = new Calculator();
            //     calc.Divide(1, 0); 


            // }
            // catch (DivideByZeroException ex){

            // }
            // catch (ArithmeticException ex){

            // }
            // catch (Exception ex)
            // {
            //     System.Console.WriteLine("error");

            //     throw new CustomizedException("Customized", ex);
            // }


            //Asynchronous Programming with Async/Await
            //DownloadHtmlAsync("http://www.google.com");
            //DownloadAsync("http://www.google.com");
            //var t = GetHtmlAsync("http://www.google.com");

            //Parallel
            //ParallelVsForEach.ExecuteExample();

            #endregion

            #region C# 2.0

            #endregion

            #region C# 7.0

            //TUPLAS
            //Tuplas.ExecuteExample();

            //REF RETURNS
            //RefReturns.ExecuteExample();

            //PATTERN MATCHING
            //PatternMatching.ExecuteExample();

            //PATTERN MATCHING 2:
            //PatternMatching2.ExecuteExample();

            //LOCAL FUNCTIONS
            //LocalFunctions.ExecuteExample();

            //DIGIT SEPARATORS
            //DigitSeparator.ExecuteExample();

            //OUT VARIABLES
            //OutVariables.ExecuteExample("12");

            //EXPRESSION BODIED
            //var exp = new ExpressioBodied("descricao");
            //exp.Label = "descricao modificada";
            //Console.WriteLine(exp.Label);

            //VALUE TASKS:
            //ValueTasks2.ExecuteExample();

            //PATTERN MATCHING
            //PatternMatching.ExecuteExample();

            #endregion

            #region Functional Programming

            #endregion

            #region Searching Techniques

            //linear search: consider every single item on a one by one basis
            // int[] numbers = {1,32,5,12,53,65,7,234};
            // var index = LinearSearch.returnIndex(numbers, 53);
            // Console.WriteLine($"Value search: 53. Index found is {index}, in array [{string.Join(",",numbers)}].");

            //binary search: the target value is compared with de middle element of a sorted array.            
            // int[] numbers = {1,20,25,32,45,50,70,80};
            // var index = BinarySearch.returnIndex(numbers, 0, numbers.Length, 50);
            // Console.WriteLine($"Value search: 50. Index found is {index}, in array [{string.Join(",",numbers)}].");            

            //

            #endregion

            #region Best Practices for Developers

            #endregion

            #region Other
            //RuntimePolymorphismExample.Execute();
            //structs
            //StructSample.ExecuteExample();

            //Properties
            // var prop = new PropertiesExample();
            // Console.WriteLine(prop.FirstName);

            // var prop2 = new PropertiesExample("asdasdasd");
            // Console.WriteLine(prop2.FirstName);

            // prop2.ChangePropert = "ddddddddddddd";
            // Console.WriteLine(prop2.FirstName);

            //expressions: is a sequence of one or more operands and zero or more operators that can be evaluated to a single value, object, method, or namespace
            //((x < 10) && ( x > 5)) || ((x > 20) && (x < 25));
            //System.Convert.ToInt32("35");  

            //statements: the action that a program takes (assign, declaration)

            //yield: A type of statement
            //attributes: Attributes add metadata to your program
            //YieldExample.ExecuteExample();

            //literals: constants refer to fixed values that the program may not alter during its execution - fixed values
            //ex: \n \t floating-point: 3.14159 string: @"asdasd" const

            //value types:
            //ValueTypesExample.ExecuteExample();

            //reference types:
            //ReferenceTypesExample.ExecuteExample();
            #endregion
        }

        #region Other Tests
        public static System.Collections.Generic.IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }
        #endregion

        #region C# Advanced

        public static async Task<string> GetHtmlAsync(string url)
        {
            var webClient = new WebClient();

            return await webClient.DownloadStringTaskAsync(url);
        }
        public static string GetHtml(string url)
        {
            var webClient = new WebClient();

            return webClient.DownloadString(url);
        }

        public static async Task DownloadHtmlAsync(string url)
        {
            var webClient = new WebClient();
            var html = await webClient.DownloadStringTaskAsync(url);

            using (var streamWriter = new StreamWriter(@"result.html"))
            {
                await streamWriter.WriteAsync(html);
            }
        }

        public static void DownloadHtml(string url)
        {
            var webClient = new WebClient();
            var html = webClient.DownloadString(url);

            using (var streamWriter = new StreamWriter(@"result.html"))
            {
                streamWriter.Write(html);
            }
        }

        static bool IsCheaperThan10Dollars(Book book)
        {
            return book.Price < 10;
        }

        static int Square(int number) => number * number;

        static void RemoveRedEye(Photo photo)
        {
            System.Console.WriteLine("remove red eye");
        }

        public void Add(Book book)
        {

        }

        public Book this[int index]
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }

    #region C# Intermediate

    public class GoldCustomer : Customer
    {
        public void OfferVoucher()
        {
            //this.
        }
    }
    public class Calculator
    {
        //adding more than one parameter
        public int Add(params int[] numbers)
        {

            var sum = 0;

            foreach (var number in numbers)
            {
                sum += number;
            }

            return sum;
        }

        public int Divide(int v1, int v2)
        {
            return v1 / v2;
        }
    }

    #endregion
    #region C# Advanced

    
    public class TaxCalculator
    {
        public static float Calculate()
        {
            return 1f;
        }
    }
    #endregion
}
