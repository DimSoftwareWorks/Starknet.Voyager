using System;

namespace Starknet.Voyager.Explorer.Models
{
    public class Result<T>
    {
        public T Value { get; set; }

        public bool IsSuccess => Value != null;

        public string ErrorMessage { get; set; }

        public Exception Exception { get; set; }
    }
}
