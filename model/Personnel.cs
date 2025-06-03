using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_tek86.model
{
    public class Personnel
    {
        public Personnel(int idPersonnel,
                         string nom,
                         string prenom,
                         int idService,
                         string mail,
                         string telephone)
        {
            IdPersonnel = idPersonnel;
            Nom = nom;
            Prenom = prenom;
            IdService = idService;
            Mail = mail;
            Telephone = telephone;
        }

        public int IdPersonnel { get; }
        public string Nom { get; }
        public string Prenom { get; }
        public int IdService { get; }
        public string Mail { get; }
        public string Telephone { get; }
    }
}
