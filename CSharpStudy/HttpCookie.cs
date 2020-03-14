using System.Collections.Generic;

namespace CSharpStudy
{
    public class HttpCookie
    {

        private readonly Dictionary<string, string> _dictionary;

        public HttpCookie()
        {
            _dictionary = new Dictionary<string, string>();
        }

        //working with indexers
        public string this[string key]
        {
            get
            {
                return _dictionary[key];
            }
            set
            {
                _dictionary[key] = value;
            }
        }

    }
}
