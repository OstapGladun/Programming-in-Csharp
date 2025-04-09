using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    [Serializable]
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email)
            : base($"Email \"{email}\" is in wrong format.") { }
    }
}
