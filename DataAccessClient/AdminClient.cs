using System.IO;
using ModelLib;

namespace DataAccessClient
{
    public class AdminClient
    {
        private const int MAX_CLIENT_NB = 50;
        private string clientFileName;
        public AdminClient(string clientFileName)
        {
            this.clientFileName = clientFileName;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamTextFile = File.Open(clientFileName, FileMode.OpenOrCreate);
            streamTextFile.Close();
        }

        public void AddClient(Client client)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamTextFile = new StreamWriter(clientFileName, true))
            {
                streamTextFile.WriteLine(client.ConvertStringForFile());
            }
        }

        public Client[] GetClients(out int clientNb)
        {
            Client[] clients = new Client[MAX_CLIENT_NB];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(clientFileName))
            {
                string fileLine;
                clientNb = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((fileLine = streamReader.ReadLine()) != null)
                {
                    clients[clientNb++] = new Client(fileLine);
                }
            }

            return clients;
        }

        public Client GetClient(string name, string surname, int idclient)
        {
            int carclientsnb = 0;
            Client[] clients = this.GetClients(out carclientsnb);
            int i = 0;

            for (i = 0; i < carclientsnb; i++)
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if(string.Equals(name, clients[i].name))
                    {
                        return clients[i];
                    }
                }
                else if(!string.IsNullOrEmpty(surname))
                {
                    if (string.Equals(surname, clients[i].surname))
                    {
                        return clients[i];
                    }
                }
                else if(idclient!=0)
                {
                    if(idclient == clients[i].idClient)
                    {
                        return clients[i];
                    }
                }
            }

            return clients[i-1];
        }
    }
}
