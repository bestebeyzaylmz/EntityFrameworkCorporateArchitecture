using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message): base(data, true, message)
        {
            //data, mesaj ve işlem sonucunu verir
        }

        public SuccessDataResult(T data):base(data, true)
        {
            //data ve işlem sonucunu verir, mesaj vermez
        }

        public SuccessDataResult(string message) :base(default,true, message)
        {
            //mesaj ve işlem sonucunu döner
        }

        public SuccessDataResult():base(default,true)
        {
            //işlem sonucu verir
        }
    }
}
