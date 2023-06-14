using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using ModelLib;
using DataAccessCar;
using DataAccessClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace UIServiceManager
{
    public partial class Form1 : Form
    {
        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 150;
        Label[] lblIds;
        Label[] lblNames;
        Label[] lblSurnames;
        Label[] lblMarks;
        Label[] lblModels;
        Label tempLblIds;
        Label tempLblName;
        Label tempLblSurname;
        Label tempLblMark;
        Label tempLblModel;

        public Form1()
        {
            InitializeComponent();

            //setare proprietati
            this.Size = new Size(330, 700);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(400, 400);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Info Clients";

            this.FormH();
        }

        private void FormH()
        {
            Label lblId;
            Label lblName;
            Label lblSurname;
            Label lblMark;
            Label lblModel;

            lblId = new Label();
            lblId.Width = LATIME_CONTROL;
            lblId.Text = "Id";
            lblId.Left = 3 * DIMENSIUNE_PAS_X;
            lblId.BackColor = Color.LightYellow;
            this.Controls.Add(lblId);


            lblName = new Label();
            lblName.Width = LATIME_CONTROL;
            lblName.Text = "Name";
            lblName.Left = 4 * DIMENSIUNE_PAS_X;
            lblName.BackColor = Color.LightYellow;
            this.Controls.Add(lblName);

            lblSurname = new Label();
            lblSurname.Width = LATIME_CONTROL;
            lblSurname.Text = "Surname";
            lblSurname.Left = 5 * DIMENSIUNE_PAS_X;
            lblSurname.BackColor = Color.LightYellow;
            this.Controls.Add(lblSurname);

            lblMark = new Label();
            lblMark.Width = LATIME_CONTROL;
            lblMark.Text = "Car Mark";
            lblMark.Left = 6 * DIMENSIUNE_PAS_X;
            lblMark.BackColor = Color.LightYellow;
            this.Controls.Add(lblMark);

            lblModel = new Label();
            lblModel.Width = LATIME_CONTROL;
            lblModel.Text = "Car Model";
            lblModel.Left = 7 * DIMENSIUNE_PAS_X;
            lblModel.BackColor = Color.LightYellow;
            this.Controls.Add(lblModel);
        }

        private void FormGetAndShowInfo(Client[] clients, Car[] cars, int nb)
        {
            lblIds = new Label[nb];
            lblNames = new Label[nb];
            lblSurnames = new Label[nb];
            lblMarks = new Label[nb];
            lblModels = new Label[nb];

            for (int i = 0; i < nb; i++)
            {
                lblIds[i] = new Label();
                lblIds[i].Width = LATIME_CONTROL;
                lblIds[i].Text = clients[i].idClient.ToString();
                lblIds[i].Left = 3 * DIMENSIUNE_PAS_X;
                lblIds[i].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                lblIds[i].BackColor = Color.WhiteSmoke;
                this.Controls.Add(lblIds[i]);

                lblNames[i] = new Label();
                lblNames[i].Width = LATIME_CONTROL;
                lblNames[i].Text = clients[i].name;
                lblNames[i].Left = 4 * DIMENSIUNE_PAS_X;
                lblNames[i].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                lblNames[i].BackColor = Color.WhiteSmoke;
                this.Controls.Add(lblNames[i]);

                lblSurnames[i] = new Label();
                lblSurnames[i].Width = LATIME_CONTROL;
                lblSurnames[i].Text = clients[i].surname;
                lblSurnames[i].Left = 5 * DIMENSIUNE_PAS_X;
                lblSurnames[i].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                lblSurnames[i].BackColor = Color.WhiteSmoke;
                this.Controls.Add(lblSurnames[i]);

                lblMarks[i] = new Label();
                lblMarks[i].Width = LATIME_CONTROL;
                lblMarks[i].Text = cars[i].mark;
                lblMarks[i].Left = 6 * DIMENSIUNE_PAS_X;
                lblMarks[i].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                lblMarks[i].BackColor = Color.WhiteSmoke;
                this.Controls.Add(lblMarks[i]);

                lblModels[i] = new Label();
                lblModels[i].Width = LATIME_CONTROL;
                lblModels[i].Text = cars[i].model;
                lblModels[i].Left = 7 * DIMENSIUNE_PAS_X;
                lblModels[i].Top = (i + 2) * DIMENSIUNE_PAS_Y;
                lblModels[i].BackColor = Color.WhiteSmoke;
                this.Controls.Add(lblModels[i]);
            }
        }

        private void FormShowSingleInfo(Client client, Car car, int nb)
        {
            tempLblIds = new Label();
            tempLblIds.Width = LATIME_CONTROL;
            tempLblIds.Text = client.idClient.ToString();
            tempLblIds.Left = 3 * DIMENSIUNE_PAS_X;
            tempLblIds.Top = 2 * DIMENSIUNE_PAS_Y;
            tempLblIds.BackColor = Color.WhiteSmoke;
            this.Controls.Add(tempLblIds);

            tempLblName = new Label();
            tempLblName.Width = LATIME_CONTROL;
            tempLblName.Text = client.name;
            tempLblName.Left = 4 * DIMENSIUNE_PAS_X;
            tempLblName.Top = 2 * DIMENSIUNE_PAS_Y;
            tempLblName.BackColor = Color.WhiteSmoke;
            this.Controls.Add(tempLblName);

            tempLblSurname = new Label();
            tempLblSurname.Width = LATIME_CONTROL;
            tempLblSurname.Text = client.surname;
            tempLblSurname.Left = 5 * DIMENSIUNE_PAS_X;
            tempLblSurname.Top = 2 * DIMENSIUNE_PAS_Y;
            tempLblSurname.BackColor = Color.WhiteSmoke;
            this.Controls.Add(tempLblSurname);

            tempLblMark = new Label();
            tempLblMark.Width = LATIME_CONTROL;
            tempLblMark.Text = car.mark;
            tempLblMark.Left = 6 * DIMENSIUNE_PAS_X;
            tempLblMark.Top = 2 * DIMENSIUNE_PAS_Y;
            tempLblMark.BackColor = Color.WhiteSmoke;
            this.Controls.Add(tempLblMark);

            tempLblModel = new Label();
            tempLblModel.Width = LATIME_CONTROL;
            tempLblModel.Text = car.model;
            tempLblModel.Left = 7 * DIMENSIUNE_PAS_X;
            tempLblModel.Top = 2 * DIMENSIUNE_PAS_Y;
            tempLblModel.BackColor = Color.WhiteSmoke;
            this.Controls.Add(tempLblModel);
        }

        private void removeCarClientInfo(int nb)
        {
            for (int i = 0; i < nb; i++)
            {
                if (lblIds[i] != null)
                {
                    this.Controls.Remove(lblIds[i]);
                }

                if (lblNames[i] != null)
                {
                    this.Controls.Remove(lblNames[i]);
                }

                if (lblSurnames[i] != null)
                {
                    this.Controls.Remove(lblSurnames[i]);
                }

                if (lblMarks[i] != null)
                {
                    this.Controls.Remove(lblMarks[i]);
                }

                if (lblModels[i] != null)
                {
                    this.Controls.Remove(lblModels[i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string carFileName = ConfigurationManager.AppSettings["CarFile"];
            string clientFileName = ConfigurationManager.AppSettings["ClientFile"];
            string localSolutionFile = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string clientFileFullPath = localSolutionFile + "\\" + clientFileName;
            string carFileFullPath = localSolutionFile + "\\" + carFileName;
            AdminClient adminClient = new AdminClient(clientFileFullPath);
            AdminCar adminCar = new AdminCar(carFileFullPath);
            Car car = new Car();
            Client client = new Client();
            int entryNb = 0;
            adminCar.GetCars(out entryNb);
            int Id = entryNb + 1;

            car = new Car(Id, carMarkInput.Text, carModelInput.Text, OdometerInput.Text);
            client = new Client(Id, nameInput.Text, surnameInput.Text);

            entryNb++;
            adminCar.AddCar(car);
            adminClient.AddClient(client);

            carMarkInput.Text = string.Empty;
            carModelInput.Text = string.Empty;
            surnameInput.Text = string.Empty;
            nameInput.Text = string.Empty;
            OdometerInput.Text = string.Empty;

            removeCarClientInfo(entryNb);

            Client[] clients = adminClient.GetClients(out entryNb);
            Car[] cars = adminCar.GetCars(out entryNb);
            FormGetAndShowInfo(clients, cars, entryNb);
            this.Width = 1200;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string carFileName = ConfigurationManager.AppSettings["CarFile"];
            string clientFileName = ConfigurationManager.AppSettings["ClientFile"];
            string localSolutionFile = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string clientFileFullPath = localSolutionFile + "\\" + clientFileName;
            string carFileFullPath = localSolutionFile + "\\" + carFileName;
            AdminClient adminClient = new AdminClient(clientFileFullPath);
            AdminCar adminCar = new AdminCar(carFileFullPath);
            int entryNb = 0;
            Client[] clients = adminClient.GetClients(out entryNb);
            Car[] cars = adminCar.GetCars(out entryNb);

            FormGetAndShowInfo(clients, cars, entryNb);
            this.Width = 1200;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Id3 = 0;
            string searchItem = textBox5.Text;
            string searchSelector = searchSelect.Text;
            string mark3 = string.Empty;
            string model3 = string.Empty;
            string name3 = string.Empty;
            string surname3 = string.Empty;
            Client client3 = new Client(Id3, name3, surname3);
            Car car3 = new Car();
            bool entryFound = false;
            string carFileName = ConfigurationManager.AppSettings["CarFile"];
            string clientFileName = ConfigurationManager.AppSettings["ClientFile"];
            string localSolutionFile = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string clientFileFullPath = localSolutionFile + "\\" + clientFileName;
            string carFileFullPath = localSolutionFile + "\\" + carFileName;
            AdminClient adminClient = new AdminClient(clientFileFullPath);
            AdminCar adminCar = new AdminCar(carFileFullPath);
            int entryNb = 0;
            adminCar.GetCars(out entryNb);
            int Id = entryNb + 1;

            removeCarClientInfo(entryNb);

            Int32.TryParse(Console.ReadLine(), out Id3);
            if (Id3 == 0)
            {
                if (!string.Equals(searchSelect.Text, "Mark") || string.IsNullOrEmpty(searchItem))
                {
                    if (!string.Equals(searchSelect.Text, "Model") || string.IsNullOrEmpty(searchItem))
                    {
                        if (!string.Equals(searchSelect.Text, "Name") || string.IsNullOrEmpty(searchItem))
                        {
                            if (!string.Equals(searchSelect.Text, "Surname") || string.IsNullOrEmpty(searchItem))
                            {
                                
                            }
                            else
                            {
                                client3 = adminClient.GetClient(name3, searchItem, Id3);
                                if (string.Equals(searchItem, client3.surname))
                                {
                                    car3 = adminCar.GetCar(mark3, model3, client3.idClient);
                                    entryFound = true;
                                }
                            }
                        }
                        else
                        {
                            client3 = adminClient.GetClient(searchItem, surname3, Id3);
                            if (string.Equals(searchItem, client3.name))
                            {
                                car3 = adminCar.GetCar(mark3, model3, client3.idClient);
                                entryFound = true;
                            }
                        }
                    }
                    else
                    {
                        car3 = adminCar.GetCar(mark3, searchItem, Id3);
                        if (string.Equals(searchItem, car3.model))
                        {
                            client3 = adminClient.GetClient(name3, surname3, Id3);
                            entryFound = true;
                        }
                    }
                }
                else
                {
                    car3 = adminCar.GetCar(searchItem, model3, Id3);
                    if (string.Equals(searchItem, car3.mark))
                    {
                        client3 = adminClient.GetClient(name3, surname3, Id3);
                        entryFound = true;
                    }
                }
            }
            else
            {
                car3 = adminCar.GetCar(mark3, model3, Id3);
                if (Id3 == car3.idCar)
                {
                    client3 = adminClient.GetClient(name3, surname3, Id3);
                    entryFound = true;
                }
            }

            if (entryFound == true)
            {
                string[] odostr = Array.ConvertAll<int, string>(car3.lastodometer, ele => ele.ToString());
                string customerInfo = string.Format("Client with Id #{0} is: {1} {2} and has the car {3} {4} and has had checks at {5}",
                    client3.idClient,
                    client3.name ?? " N/A ",
                    client3.surname ?? " N/A ",
                    car3.mark ?? " N/A ",
                    car3.model ?? " N/A ",
                    (string.Join(" ", odostr) ?? " N/A "));

                FormShowSingleInfo(client3, car3, entryNb);
            }
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
