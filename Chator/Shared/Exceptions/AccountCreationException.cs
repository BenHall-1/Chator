using System;
using System.Collections.Generic;

namespace Chator.Shared.Exceptions
{
    public class AccountCreationException : Exception
    {
        public AccountCreationException(string reason)
        {
            Error.Add(reason);
        }

        public AccountCreationException(List<string> reasons)
        {
            Error = reasons;
        }

        public List<string> Error { get; set; } = new List<string>();
    }
}
