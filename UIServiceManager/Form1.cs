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
            Label[] lblIds = new Label[nb];
            Label[] lblNames = new Label[nb];
            Label[] lblSurnames = new Label[nb];
            Label[] lblMarks = new Label[nb];
            Label[] lblModels = new Label[nb];

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

            car = new Car(Id, textBox4.Text, textBox2.Text, textBox9.Text);
            client = new Client(Id, textBox1.Text, textBox3.Text);

            entryNb++;
            adminCar.AddCar(car);
            adminClient.AddClient(client);

            textBox4.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox1.Text = string.Empty;
            textBox9.Text = string.Empty;

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
            string mark3 = textBox6.Text;
            string model3 = textBox8.Text;
            string name3 = textBox5.Text;
            string surname3 = textBox7.Text;
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

            Int32.TryParse(Console.ReadLine(), out Id3);
            if (Id3 == 0)
            {
                if (string.IsNullOrEmpty(mark3))
                {
                    if (string.IsNullOrEmpty(model3))
                    {
                        if (string.IsNullOrEmpty(name3))
                        {
                            if (string.IsNullOrEmpty(surname3))
                            {
                                label6.BackColor = Color.Red;
                                label8.BackColor = Color.Red;
                                label7.BackColor = Color.Red;
                                label9.BackColor = Color.Red;
                            }
                            else
                            {
                                client3 = adminClient.GetClient(name3, surname3, Id3);
                                if (string.Equals(surname3, client3.surname))
                                {
                                    car3 = adminCar.GetCar(mark3, model3, client3.idClient);
                                    entryFound = true;
                                }
                            }
                        }
                        else
                        {
                            client3 = adminClient.GetClient(name3, surname3, Id3);
                            if (string.Equals(name3, client3.name))
                            {
                                car3 = adminCar.GetCar(mark3, model3, client3.idClient);
                                entryFound = true;
                            }
                        }
                    }
                    else
                    {
                        car3 = adminCar.GetCar(mark3, model3, Id3);
                        if (string.Equals(model3, car3.model))
                        {
                            client3 = adminClient.GetClient(name3, surname3, Id3);
                            entryFound = true;
                        }
                    }
                }
                else
                {
                    car3 = adminCar.GetCar(mark3, model3, Id3);
                    if (string.Equals(mark3, car3.mark))
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

                label6.BackColor = Color.PaleGreen;
                label8.BackColor = Color.PaleGreen;
                label7.BackColor = Color.PaleGreen;
                label9.BackColor = Color.PaleGreen;
            }
        }
    }
}
