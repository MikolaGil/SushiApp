using System;
using System.Collections.Generic;
using System.Text;

namespace SushiApp.CustomException
{
    class NotifyException : Exception
    {
        public NotifyException(string err): base(err)
        {
        }
    }
}
