using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ModelLib;

namespace DataAccessCar
{
    public class AdminCar
    {
        private const int NR_MAX_STUDENTI = 50;
        private string fileName;
        public AdminCar(string fileName)
        {
            this.fileName = fileName;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(fileName, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddCar(Car car)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(fileName, true))
            {
                streamWriterFisierText.WriteLine(car.ConvertStringForFile());
            }
        }
    }
}
