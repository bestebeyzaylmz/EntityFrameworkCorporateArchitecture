using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, true, message)
        {
            //data, mesaj ve işlem sonucunu verir
        }

        public ErrorDataResult(T data) : base(data, false)
        {
            //data ve işlem sonucunu verir, mesaj vermez
        }

        public ErrorDataResult(string message) : base(default, false, message)
        {
            //mesaj ve işlem sonucunu döner
        }

        public ErrorDataResult() : base(default, false)
        {
            //işlem sonucu verir
        }
    }
}
