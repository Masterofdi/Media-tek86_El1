using System;

namespace Media_tek86.model
{
    public class Absence
    {
        public int IdPersonnel { get; }
        public int IdMotif { get; }
        public DateTime DateDebut { get; }
        public DateTime DateFin { get; }

        // Nouveau constructeur à 4 paramètres (plus d'idAbsence)
        public Absence(int idPersonnel, int idMotif, DateTime dateDebut, DateTime dateFin)
        {
            IdPersonnel = idPersonnel;
            IdMotif = idMotif;
            DateDebut = dateDebut;
            DateFin = dateFin;
        }
    }
}