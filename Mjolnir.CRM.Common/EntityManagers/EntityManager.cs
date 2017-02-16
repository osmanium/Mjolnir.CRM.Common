using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mjolnir.CRM.Common.EntityManagers
{
    public class EntityManager : EntityManagerBase
    {
        public EntityManager(CRMContext context)
            : base(context, "") //TODO : Update here
        { }

        internal override string[] DefaultFields
        {
            get
            {
                return null;//TODO : Update here
            }
        }

        public void DeleteEntity()
        {

        }
    }
}
