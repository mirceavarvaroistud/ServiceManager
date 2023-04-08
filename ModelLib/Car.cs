using System;

namespace ModelLib
{
    public class Car
    {
        //constante
        private const char FILE_SEPARATOR = ';';

        private const int ID = 0;
        private const int MARK = 1;
        private const int MODEL = 2;
        private const int ODO = 3;

        public int idCar { get; set; }
        public string mark { get; set; }
        public string model { get; set; }
        public int[] lastodometer { get; set; }

        //contructor implicit
        public Car()
        {
            mark = model = string.Empty;
        }

        //constructor cu parametri
        public Car(int localidCar, string localMark, string localModel, string localOdostr)
        {
            idCar = localidCar;
            mark = localMark;
            model = localModel;
            string[] lastodometerstr = localOdostr.Split(' ');
            lastodometer = Array.ConvertAll<string, int>(lastodometerstr, int.Parse);
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Car(string fileLine)
        {
            var dateFisier = fileLine.Split(FILE_SEPARATOR);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idCar = Convert.ToInt32(dateFisier[ID]);
            mark = dateFisier[MARK];
            model = dateFisier[MODEL];
            string fileodometer = dateFisier[ODO];
            string[] fileodometerstrtb = fileodometer.Split(' ');
            this.lastodometer = Array.ConvertAll<string, int>(fileodometerstrtb, int.Parse);
        }

        public string Info()
        {
            string info = string.Format("Id:{0} Mark:{1} Model: {2} ",
                idCar.ToString(),
                (mark ?? " N/A "),
                (model ?? " N/A "));

            return info;
        }

        public string ConvertStringForFile()
        {
            string[] odostr = Array.ConvertAll<int, string>(lastodometer, ele => ele.ToString());
            string obiectStudentPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}",
                FILE_SEPARATOR,
                idCar.ToString(),
                (mark ?? " N/A "),
                (model ?? " N/A "),
                (string.Join(" ", odostr) ?? " N/A "));

            return obiectStudentPentruFisier;
        }

        public void SetLastOdoValue(string lastodovaluestr)
        {
            string[] fileodometerstrtb = lastodovaluestr.Split(' ');
            lastodometer = Array.ConvertAll<string, int>(fileodometerstrtb, int.Parse);
        }
    }
}
