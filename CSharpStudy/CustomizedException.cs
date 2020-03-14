using System;
//using CSharpStudy.Extensions;

namespace CSharpStudy
{
    public class CustomizedException : Exception
    {

        public CustomizedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }


}
