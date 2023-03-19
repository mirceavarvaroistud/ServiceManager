using System;

namespace ModelLib
{
    class Client
    {
        //constante
        private const char FILE_SEPARATOR = ';';

        private const int ID = 0;
        private const int NAME = 1;
        private const int SURNAME = 2;

        private int idClient; //identificator unic student
        private string name;
        private string surname;

        //contructor implicit
        public Client()
        {
            name = surname = string.Empty;
        }

        //constructor cu parametri
        public Client(int idClient, string name, string surname)
        {
            this.idClient = idClient;
            this.name = name;
            this.surname = surname;
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

        public string ConversieLaSir_PentruFisier()
        {
            string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                FILE_SEPARATOR,
                idClient.ToString(),
                (name ?? " N/A "),
                (surname ?? " N/A "));

            return obiectStudentPentruFisier;
        }

        public int GetIdClient()
        {
            return idClient;
        }

        public string GetName()
        {
            return name;
        }

        public string GetSurname()
        {
            return surname;
        }
    }
}
