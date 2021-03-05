using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastrador_COVID_19.Service.Exception
{
    public class IntegrityException : ApplicationException
    {

        public IntegrityException(string message) : base(message)
        {

        }
    }
}
