using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, message, false)
        {

        }

        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(string message) : base(default, message, false)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
