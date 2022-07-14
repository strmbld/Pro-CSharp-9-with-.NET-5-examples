using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    public class CarIsDeadException : ApplicationException
    { 
        public DateTime ErrorTimeStamp { get; init; }
        public string CauseOfError { get; init; }

        public CarIsDeadException(string causeOfError, string message = "", System.Exception inner = null) : base(message, inner)
        {
            CauseOfError = causeOfError;
            // this.message = message;
            ErrorTimeStamp = DateTime.Now; 
        }
        // public override string Message => $"Car Error Message: {message}";
    }


    [Serializable]
    public class MyException : Exception
    {
        public MyException() { }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }
        protected MyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
