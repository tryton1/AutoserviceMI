using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AutoserviceMI
{
    public partial class AdaugareProgramare : Window
    {
        public List<Programari1> ProgramariList { get; set; }

        public AdaugareProgramare(List<Programari1> programariList)
        {
            InitializeComponent();
            ProgramariList = programariList;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime oraData = (DateTime)OraDataDatePicker.SelectedDate;
            string nume = NumeTextBox.Text;
            string numarTelefon = NumarTelefonTextBox.Text;
            string modelAutomobil = ModelAutomobilTextBox.Text;
            int anFabricare = int.Parse(AnFabricareTextBox.Text);

            Programari1 programare = new Programari1(oraData, nume, numarTelefon, modelAutomobil, anFabricare);

            ProgramariList.Add(programare);
            this.Close();
        }
    }
}
