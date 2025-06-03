using Media_tek86.BDDmanager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_tek86.dal
{
    internal static class DalContext
    {
        // 1) Ta chaîne de connexion
        private const string ConnStr =
            "server=localhost;database=media-tek86;uid=root;pwd='';";

        // 2) Propriété unique et non-nullable
        public static BddManager Manager =>
            BddManager.GetInstance(ConnStr);
    }
}


