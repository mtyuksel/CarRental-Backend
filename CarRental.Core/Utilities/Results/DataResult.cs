using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, string message, bool success) : base(success, message)
        {
            this.Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            this.Data = data;
        }

        public T Data { get; }
    }
}
