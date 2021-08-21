using System;
using System.Collections.Generic;
using System.Text;

namespace ELearning.Common.Exceptions
{
    public class DuplicationException : Exception
    {
        public DuplicationException()
            : base()
        {
        }

        //public DuplicationException(string message)
        //    : base(message)
        //{
        //}

        public DuplicationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public DuplicationException(string name)
            : base($"{name} already exists.")
        {
        }
    }
}
