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
            string carFileName = string.Empty;
            if (args.Length == 0)
            {
                carFileName = ConfigurationManager.AppSettings["CarFile"];
            }
            else
            {
                carFileName = args[0];
            }
            string clientFileName = ConfigurationManager.AppSettings["ClientFile"];
            AdminCar adminCar = new AdminCar(carFileName);
            AdminClient adminClient = new AdminClient(clientFileName);
            int carclientsnb = 0;

            string action;

            do
            {
                Console.WriteLine("1. Add new car and client info");
                Console.WriteLine("2. Print cars and clients from file");
                Console.WriteLine("3. Print car and client info from file");
                Console.WriteLine("4. Close program");
                Console.WriteLine("Pick an action");

                action = Console.ReadLine();

                switch (action.ToUpper())
                {
                    case "1":
                        adminCar.GetCars(out carclientsnb);
                        int Id = carclientsnb + 1;

                        Console.WriteLine("Introduce car mark {0} : ", Id);
                        string mark1 = Console.ReadLine();
                        Console.WriteLine("Introduce car model {0} : ", Id);
                        string model1 = Console.ReadLine();
                        Console.WriteLine("Introduce client name {0} : ", Id);
                        string name1 = Console.ReadLine();
                        Console.WriteLine("Introduce client surname {0} : ", Id);
                        string surname1 = Console.ReadLine();
                        Console.WriteLine("Introduce car odo values separated by space {0} : ", Id);
                        string odostr1 = Console.ReadLine();

                        car = new Car(Id, mark1, model1, odostr1);
                        client = new Client(Id, name1, surname1);

                        carclientsnb++;
                        adminCar.AddCar(car);
                        adminClient.AddClient(client);

                        break;

                    case "2":
                        Car[] cars = adminCar.GetCars(out carclientsnb);
                        ShowCars(cars, carclientsnb);

                        Client[] clients = adminClient.GetClients(out carclientsnb);
                        ShowClients(clients, carclientsnb);
                        break;

                    case "3":
                        int Id3 = 0;
                        string mark3 = string.Empty;
                        string model3 = string.Empty;
                        string name3 = string.Empty;
                        string surname3 = string.Empty;
                        Client client3 = new Client(Id3, name3, surname3);
                        Car car3 = new Car();
                        bool entryFound = false;

                        Console.WriteLine("Introduce Client/Car ID if known: ");
                        Int32.TryParse(Console.ReadLine(), out Id3);
                        if (Id3 == 0)
                        {
                            Console.WriteLine("Introduce car mark if known: ");
                            mark3 = Console.ReadLine();
                            if (string.IsNullOrEmpty(mark3))
                            {
                                Console.WriteLine("Introduce car model if known: ");
                                model3 = Console.ReadLine();
                                if (string.IsNullOrEmpty(model3))
                                {
                                    Console.WriteLine("Introduce client name if known: ");
                                    name3 = Console.ReadLine();
                                    if (string.IsNullOrEmpty(name3))
                                    {
                                        Console.WriteLine("Introduce client surname if known");
                                        surname3 = Console.ReadLine();
                                        if (string.IsNullOrEmpty(surname3))
                                        {
                                            Console.WriteLine("No valid search element entered");
                                        }
                                        else
                                        {
                                            client3 = adminClient.GetClient(name3, surname3, Id3);
                                            if (string.Equals(surname3, client3.GetSurname()))
                                            {
                                                car3 = adminCar.GetCar(mark3, model3, client3.GetIdClient());
                                                entryFound = true;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        client3 = adminClient.GetClient(name3, surname3, Id3);
                                        if (string.Equals(name3, client3.GetName()))
                                        {
                                            car3 = adminCar.GetCar(mark3, model3, client3.GetIdClient());
                                            entryFound = true;
                                        }
                                    }
                                }
                                else
                                {
                                    car3 = adminCar.GetCar(mark3, model3, Id3);
                                    if (string.Equals(model3, car3.GetModel()))
                                    {
                                        client3 = adminClient.GetClient(name3, surname3, Id3);
                                        entryFound = true;
                                    }
                                }
                            }
                            else
                            {
                                car3 = adminCar.GetCar(mark3, model3, Id3);
                                if (string.Equals(mark3, car3.GetMark()))
                                {
                                    client3 = adminClient.GetClient(name3, surname3, Id3);
                                    entryFound = true;
                                }
                            }
                        }
                        else
                        {
                            car3 = adminCar.GetCar(mark3, model3, Id3);
                            if (Id3 == car3.GetIdCar())
                            {
                                client3 = adminClient.GetClient(name3, surname3, Id3);
                                entryFound = true;
                            }
                        }

                        if (entryFound == true)
                        {
                            string[] odostr = Array.ConvertAll<int, string>(car3.GetLastOdoValue(), ele => ele.ToString());
                            string customerInfo = string.Format("Client with Id #{0} is: {1} {2} and has the car {3} {4} and has had checks at {5}",
                                client3.GetIdClient(),
                                client3.GetName() ?? " N/A ",
                                client3.GetSurname() ?? " N/A ",
                                car3.GetMark() ?? " N/A ",
                                car3.GetModel() ?? " N/A ",
                                (string.Join(" ", odostr) ?? " N/A "));

                            Console.WriteLine(customerInfo);
                        }
                        else
                        {
                            Console.WriteLine("Entry not found");
                        }


                        break;
                    case "4":

                        return;
                    default:
                        Console.WriteLine("Option doesn't exist");

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
                string[] odostr = Array.ConvertAll<int, string>(cars[i].GetLastOdoValue(), ele => ele.ToString());
                string infoCar = string.Format("Car with id #{0} is: {1} {2} and has had checks at: {3}",
                   cars[i].GetIdCar(),
                   cars[i].GetMark() ?? " N/A ",
                   cars[i].GetModel() ?? " N/A ",
                   (string.Join(" ", odostr) ?? " N/A "));

                Console.WriteLine(infoCar);
            }
        }

        public static void ShowClients(Client[] clients, int clientsnb)
        {
            Console.WriteLine("Clients are:");
            for (int i = 0; i < clientsnb; i++)
            {
                string infoClient = string.Format("Client with id #{0} is: {1} {2}",
                   clients[i].GetIdClient(),
                   clients[i].GetName() ?? " N/A ",
                   clients[i].GetSurname() ?? " N/A ");

                Console.WriteLine(infoClient);
            }
        }
    }
}
