using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_tek86.model
{
    internal class Service
    {
        public int IdService { get; }
        public string Nom { get; }

        public Service(int idService, string nom)
        {
            IdService = idService;
            Nom = nom;
        }
    }
}
