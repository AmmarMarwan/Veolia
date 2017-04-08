using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veolia.DataModel
{
    public class OperationGroupAccess
    {
        public List<GroupAccess> FindGroupAccess()
        {
            using (VeoliaContext db = new VeoliaContext())
            {
                return (db.Groups.ToList());
            }
        }
  
    }
}
