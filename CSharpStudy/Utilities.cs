using System;

namespace CSharpStudy
{
    //where T : IComparable
    //where T : Product
    //where T : struct
    //where T : class
    //where T : new()
    public class Utilities<T> where T : IComparable, new()
    {

        public int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public T Max(T a, T b)
        {
            //return a > b ? a : b;
            return a.CompareTo(b) > 0 ? a : b;
        }

        public void DoSomething(T value)
        {
            var obj = new T();
        }
    }

    public class DiscountCalculator<TProduct> where TProduct : Product
    {

        public decimal CalculateDiscount(TProduct product)
        {
            return product.Price;
        }

    }

    public class Product
    {
        public string Isbn { get; set; }
        public decimal Price { get; set; }
    }

    public class Nullable<T> where T : struct
    {

        private object _value;

        public Nullable()
        {
        }

        public Nullable(T value)
        {
            _value = value;
        }

        public bool HasValue
        {
            get { return _value != null; }
        }

        public T GetValueOrDefault()
        {
            if (HasValue)
                return (T)_value; //boxing

            return default(T);
        }

    }
}
