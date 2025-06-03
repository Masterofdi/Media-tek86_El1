using Media_tek86.BDDmanager;
using Media_tek86.model;
using System;
using System.Collections.Generic;

namespace Media_tek86.dal
{
    internal class PersonnelDal
    {
        private readonly BddManager bdd = DalContext.Manager;

        public List<Personnel> GetAll()
        {
            var rows = bdd.ReqSelect(
                "SELECT idpersonnel, nom, prenom, idservice, mail, tel FROM personnel;");
            var list = new List<Personnel>();
            foreach (var r in rows)
            {
                list.Add(new Personnel(
                    Convert.ToInt32(r[0]),
                    Convert.ToString(r[1]),
                    Convert.ToString(r[2]),
                    Convert.ToInt32(r[3]),
                    Convert.ToString(r[4]),
                    Convert.ToString(r[5])
                ));
            }
            return list;
        }

        public void Insert(Personnel p)
            => bdd.ReqUpdate(
                "INSERT INTO personnel(nom,prenom,idservice,mail,tel) " +
                "VALUES(@n,@p,@s,@m,@t)",
                new Dictionary<string, object>
                {
                    ["@n"] = p.Nom,
                    ["@p"] = p.Prenom,
                    ["@s"] = p.IdService,
                    ["@m"] = p.Mail,
                    ["@t"] = p.Telephone
                });

        public void Update(Personnel p)
            => bdd.ReqUpdate(
                "UPDATE personnel SET nom=@n,prenom=@p,idservice=@s,mail=@m,tel=@t " +
                "WHERE idpersonnel=@id",
                new Dictionary<string, object>
                {
                    ["@id"] = p.IdPersonnel,
                    ["@n"] = p.Nom,
                    ["@p"] = p.Prenom,
                    ["@s"] = p.IdService,
                    ["@m"] = p.Mail,
                    ["@t"] = p.Telephone
                });

        public void Delete(int id)
            => bdd.ReqUpdate(
                "DELETE FROM personnel WHERE idpersonnel=@id",
                new Dictionary<string, object> { { "@id", id } });
    }
}
