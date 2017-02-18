using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common
{
    public class CrmBusinessException : Exception
    {
        public CrmBusinessException()
        {
        }

        public CrmBusinessException(string message)
            :base(message)
        {
        }

        public CrmBusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
