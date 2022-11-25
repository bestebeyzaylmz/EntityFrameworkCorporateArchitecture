using System;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //getter readonlydir sadece constructer da set edilebilir.
        public Result(bool success, string message):this(success)
            // tek parametreli olan bu classı calıstır
        {
            Message = message;
        }  
        
        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
