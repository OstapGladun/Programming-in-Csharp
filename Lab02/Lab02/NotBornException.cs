using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    [Serializable]
    public class NotBornException : Exception
    {
        public NotBornException(DateTime birthDate)
            : base($"Birth date \"{birthDate}\" is in the future.") { }
    }
}
