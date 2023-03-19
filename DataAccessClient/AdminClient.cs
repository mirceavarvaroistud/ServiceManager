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
    }
}
