using System;
using System.Collections;

namespace CSharpStudy.CSharp1_2
{
    
    public class ForEachIDisposable
    {

        public static void ExecuteExample()
        {
            var customizedCollection = new MyCustomizedCollection();

            foreach (var item in customizedCollection)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    class MyCustomizedCollection {
        ArrayList items = new ArrayList();

        public MyCustomizedCollection()
        {
            items.Add("First item");
            items.Add("Second item");
            items.Add("Third item");
            items.Add("Fourth item");
        }

        public int GetCount() {
            return items.Count;
        }

        public string GetItem(int index) {
            return items[index].ToString();
        }

        public IEnumerator GetEnumerator() {
            return new CustomizedEnumerator(this);
        }
    }

    class CustomizedEnumerator : IEnumerator, IDisposable
    {
        private MyCustomizedCollection _collection;
        private int _index = -1;

        public CustomizedEnumerator(MyCustomizedCollection collection) {
            _collection = collection;
        }

        public void Dispose()
        {
            Console.WriteLine($"Disposed was called by {nameof(CustomizedEnumerator)}.");
        }

        public object Current
        {
          get { 
              return _collection.GetItem(_index); 
            }
        }

        public bool MoveNext()
        {
            return ++_index < _collection.GetCount();
        }

        public void Reset()
        {
             _index = -1;
        }
    }
}