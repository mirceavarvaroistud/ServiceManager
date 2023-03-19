using System;
using System.Configuration;
using ModelLib;
using DataAccessCar;
using DataAccessClient;

namespace ServiceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            Client client = new Client();
            string carFileName = ConfigurationManager.AppSettings["CarFile"];
            string clientFileName = ConfigurationManager.AppSettings["ClientFile"];
            AdminCar adminCar = new AdminCar(carFileName);
            AdminClient adminClient = new AdminClient(clientFileName);
            int carclientsnb = 0;

            string action;

            do
            {
                Console.WriteLine("A. Add new car and client info");
                Console.WriteLine("P. Print cars and clients from file");
                Console.WriteLine("X. Close program");
                Console.WriteLine("Pick an action");

                action = Console.ReadLine();

                switch (action.ToUpper())
                {
                    case "A":
                        int Id = carclientsnb + 1;

                        Console.WriteLine("Introduce car mark {0} : ", Id);
                        string mark = Console.ReadLine();
                        Console.WriteLine("Introduce car model {0} : ", Id);
                        string model = Console.ReadLine();
                        Console.WriteLine("Introduce client name {0} : ", Id);
                        string name = Console.ReadLine();
                        Console.WriteLine("Introduce client surname {0} : ", Id);
                        string surname = Console.ReadLine();

                        car = new Car(Id, mark, model);
                        client = new Client(Id, name, surname);

                        carclientsnb++;
                        adminCar.AddCar(car);
                        adminClient.AddClient(client);

                        break;

                    case "F":
                        Car[] cars = adminCar.GetCars(out carclientsnb);
                        ShowCars(cars, carclientsnb);

                        Client[] clients = adminClient.GetClients(out carclientsnb);
                        ShowClients(clients, carclientsnb);
                        break;

                    case "X":

                        return;
                    default:
                        Console.WriteLine("Optiune inexistenta");

                        break;
                }

            } while (action.ToUpper() != "X");

            Console.ReadKey();
        }

        public static void ShowCars(Car[] cars, int carsnb)
        {
            Console.WriteLine("Cars are: ");
            for (int i = 0; i < carsnb; i++)
            {
                string infoStudent = string.Format("Car with id #{0} is: {1} {2}",
                   cars[i].GetIdCar(),
                   cars[i].GetMark() ?? " N/A ",
                   cars[i].GetModel() ?? " N/A ");

                Console.WriteLine(infoStudent);
            }
        }

        public static void ShowClients(Client[] clients, int clientsnb)
        {
            Console.WriteLine("Clients are:");
            for (int i = 0; i < clientsnb; i++)
            {
                string infoStudent = string.Format("Client with id #{0} is: {1} {2}",
                   clients[i].GetIdClient(),
                   clients[i].GetName() ?? " N/A ",
                   clients[i].GetSurname() ?? " N/A ");

                Console.WriteLine(infoStudent);
            }
        }
    }
}
