using System.IO;
using ModelLib;

namespace DataAccessCar
{
    public class AdminCar
    {
        private const int MAX_CAR_NB = 50;
        private string carFileileName;
        public AdminCar(string fileName)
        {
            this.carFileileName = fileName;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamTextFile = File.Open(fileName, FileMode.OpenOrCreate);
            streamTextFile.Close();
        }

        public void AddCar(Car car)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamTextFile = new StreamWriter(carFileileName, true))
            {
                streamTextFile.WriteLine(car.ConvertStringForFile());
            }
        }

        public Car[] GetCars(out int carNb)
        {
            Car[] cars = new Car[MAX_CAR_NB];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(carFileileName))
            {
                string fileLine;
                carNb = 0;

                // citeste cate o linie si creaza un obiect de tip Student
                // pe baza datelor din linia citita
                while ((fileLine = streamReader.ReadLine()) != null)
                {
                    cars[carNb++] = new Car(fileLine);
                }
            }

            return cars;
        }

        public Car GetCar(string mark, string model, int idcar)
        {
            int carclientsnb = 0;
            Car[] cars = this.GetCars(out carclientsnb);
            int i = 0;

            for (i = 0; i < carclientsnb; i++)
            {
                if (!string.IsNullOrEmpty(mark))
                {
                    if (string.Equals(mark, cars[i].GetMark()))
                    {
                        return cars[i];
                    }
                }
                else if (!string.IsNullOrEmpty(model))
                {
                    if (string.Equals(model, cars[i].GetModel()))
                    {
                        return cars[i];
                    }
                }
                else if (idcar != 0)
                {
                    if (idcar == cars[i].GetIdCar())
                    {
                        return cars[i];
                    }
                }
            }

            return cars[i];
        }
    }
}
