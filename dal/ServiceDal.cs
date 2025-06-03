using Media_tek86.BDDmanager;
using Media_tek86.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_tek86.dal
{
    internal class ServiceDal
    {
        private readonly BddManager _bdd = DalContext.Manager;

        /// <summary>
        /// Récupère tous les services (idservice, nom)
        /// </summary>
        public List<Service> GetAll()
        {
            const string sql = "SELECT idservice, nom FROM service;";
            var rows = _bdd.ReqSelect(sql);
            var list = new List<Service>();
            foreach (var r in rows)
            {
                int id = Convert.ToInt32(r[0]);
                string nm = r[1]?.ToString() ?? string.Empty;
                list.Add(new Service(id, nm));
            }
            return list;
        }
    }
}
