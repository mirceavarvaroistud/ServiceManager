using System;

namespace ModelLib
{
    public class Client
    {
        //constante
        private const char FILE_SEPARATOR = ';';

        private const int ID = 0;
        private const int NAME = 1;
        private const int SURNAME = 2;

        public int idClient { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

        //contructor implicit
        public Client()
        {
            name = surname = string.Empty;
        }

        //constructor cu parametri
        public Client(int localidClient, string localname, string localsurname)
        {
            idClient = localidClient;
            name = localname;
            surname = localsurname;
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Client(string linieFisier)
        {
            var dateFisier = linieFisier.Split(FILE_SEPARATOR);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idClient = Convert.ToInt32(dateFisier[ID]);
            name = dateFisier[NAME];
            surname = dateFisier[SURNAME];
        }

        public string Info()
        {
            string info = string.Format("Id:{0} Nume:{1} Prenume: {2}",
                idClient.ToString(),
                (name ?? " N/A "),
                (surname ?? " N/A "));

            return info;
        }

        public string ConvertStringForFile()
        {
            string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                FILE_SEPARATOR,
                idClient.ToString(),
                (name ?? " N/A "),
                (surname ?? " N/A "));

            return obiectStudentPentruFisier;
        }
    }
}
