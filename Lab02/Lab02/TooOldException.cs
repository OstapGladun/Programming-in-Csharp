using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    [Serializable]
    public class TooOldException : Exception
    {
        public TooOldException(DateTime birthDate)
            : base($"Birth date \"{birthDate}\" is more than 135 years in the past.") { }
    }
}
