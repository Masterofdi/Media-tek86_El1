using Media_tek86.BDDmanager;
using Media_tek86.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms; // Pour MessageBox

namespace Media_tek86.dal
{
    internal class AbsenceDal
    {
        private readonly BddManager bdd;

        public AbsenceDal()
        {
            bdd = DalContext.Manager;
        }

        public List<Absence> GetAll()
        {
            var list = new List<Absence>();

            try
            {
                // On ne sélectionne que les 4 colonnes restantes : idPersonnel, idMotif, dateDebut, dateFin
                const string sql = @"
                    SELECT 
                        idPersonnel, 
                        idMotif, 
                        dateDebut, 
                        dateFin 
                      FROM absence";

                var rows = bdd.ReqSelect(sql);
                if (rows == null)
                    return list;

                foreach (var r in rows)
                {
                    // r[0]=idPersonnel (int)
                    // r[1]=idMotif     (int)
                    // r[2]=dateDebut   (DateTime)
                    // r[3]=dateFin     (DateTime)
                    list.Add(new Absence(
                        Convert.ToInt32(r[0]),
                        Convert.ToInt32(r[1]),
                        Convert.ToDateTime(r[2]),
                        Convert.ToDateTime(r[3])
                    ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur GetAll(absence) : " + ex.Message, "Erreur");
            }

            return list;
        }

        public void Insert(Absence a)
        {
            const string query = @"
                INSERT INTO absence (idPersonnel, idMotif, dateDebut, dateFin)
                VALUES (@idPersonnel, @idMotif, @dateDebut, @dateFin)";

            var parameters = new Dictionary<string, object>
            {
                ["@idPersonnel"] = a.IdPersonnel,
                ["@idMotif"] = a.IdMotif,
                ["@dateDebut"] = a.DateDebut,
                ["@dateFin"] = a.DateFin
            };
            bdd.ReqUpdate(query, parameters);
        }

        // Si vous avez besoin de mettre à jour une absence, il faut fournir
        // l'id en paramètre : on ne garde plus a.IdAbsence dans le modèle.
        public void Update(int idAbsenceToUpdate, Absence a)
        {
            const string query = @"
                UPDATE absence
                   SET idPersonnel = @idPersonnel,
                       idMotif     = @idMotif,
                       dateDebut   = @dateDebut,
                       dateFin     = @dateFin
                 WHERE idAbsence = @idAbsence";

            var parameters = new Dictionary<string, object>
            {
                ["@idAbsence"] = idAbsenceToUpdate,
                ["@idPersonnel"] = a.IdPersonnel,
                ["@idMotif"] = a.IdMotif,
                ["@dateDebut"] = a.DateDebut,
                ["@dateFin"] = a.DateFin
            };
            bdd.ReqUpdate(query, parameters);
        }

        // Pour supprimer, on fournit l'id de l'absence directement :
        public void Delete(int idAbsenceToDelete)
        {
            const string query = "DELETE FROM absence WHERE idAbsence = @idAbsence";
            bdd.ReqUpdate(query, new Dictionary<string, object>
            {
                ["@idAbsence"] = idAbsenceToDelete
            });
        }
    }
}