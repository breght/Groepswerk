using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using Front_end_C.Classes;

namespace Front_end_C
{
	/// <summary>
	/// Interaction logic for Probeersel.xaml
	/// </summary>
	public partial class Probeersel : Window
	{
		public Probeersel()
		{
			this.InitializeComponent();
            MouseDown += delegate { DragMove(); }; //Laat de gebruiker toe het scherm te verslepen, dit gaat normaal niet zonder windowborders.
		}

        WebService.WebService ws = new WebService.WebService();
        DataSet objDataSet;
        DataTable objDataTable;
        int RowPosition;

        /// <summary>
        /// Eerste rij in de dataset word geselecteerd en getoond.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnEerste_Click(object sender, RoutedEventArgs e)
        {
            RowPosition = 0;
            auto_fillFields();
        }

        /// <summary>
        /// Vorige rij in de dataset word geselecteerd en getoond.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnVorige_Click(object sender, RoutedEventArgs e)
        {
            if (RowPosition != 0)
            {
                RowPosition -= 1;
                auto_fillFields();
            }
        }

        /// <summary>
        /// Volgende rij in de dataset word geselecteerd en getoond.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnVolgende_Click(object sender, RoutedEventArgs e)
        {
            if (RowPosition != objDataTable.Rows.Count - 1)
            {
                RowPosition += 1;
                auto_fillFields();
            }
        }

        /// <summary>
        /// Laatste rij in de dataset word geselecteerd en getoond.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnLaatste_Click(object sender, RoutedEventArgs e)
        {
            RowPosition = objDataTable.Rows.Count - 1;
            auto_fillFields();
        }

        /// <summary>
        /// Het scherm Huren word getoond.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnHuren_Click(object sender, RoutedEventArgs e)
        {
            var Huren = new Huren();
            Huren.Show();
        }

        /// <summary>
        /// Het scherm Account word getoond.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            var Account = new Account();
            Account.Show();
        }

        /// <summary>
        /// Gebruiker logged uit, dit scherm word gesloten en word terug naar het login scherm gegaan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnLogOff_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            var login = new Login();
            login.Show();
        }

        /// <summary>
        /// Window Load event. In het label lblHello word de naam van de klant weergeven, en de dataset word opgehaald vanuit de webservice.
        /// Rowposition word op 0 gezet, en de methode auto_fillFields word aangeroepen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                lblHello.Content = "Hallo, " + Klant.Voornaam;
                //
                objDataSet = ws.auto_getDataSetAuto();
                objDataTable = objDataSet.Tables["tblAuto"];
                RowPosition = 0;
                auto_fillFields();
            }
            catch (Exception)
            {
                //
            }
        }

        /// <summary>
        /// Opvullen van de overeenkomstige textvakken met de data uit de dataset.
        /// Als een auto niet beschikaar is, word de knop btnHuren disabled.
        /// Foto van de auto word in het image control geplaatst.
        /// Als er geen foto voor de auto beschikbaar is, word de foto AutoNietBeschikbaar.jpg gebruikt.
        /// Gegevens van de huidig geselecteerde auto worden bewaard in de klasse Gehuurde_Auto voor later gebruikt te kunnen worden.
        /// </summary>

        private void auto_fillFields()
        {

            ImageSourceConverter imsc = new ImageSourceConverter();
            String path;
            ImageSource s;

            DataRow row = objDataTable.Rows[RowPosition];

            lblAutoMerkModel.Content = row[1].ToString() + " " + row[2].ToString();

            txtMerk.Text = row[1].ToString();
            txtModel.Text = row[2].ToString();
            txtBrandstof.Text = row[3].ToString();
            txtTransmissie.Text = row[4].ToString();
            txtVermogen.Text = row[5].ToString();
            txtZitplaatsen.Text = row[6].ToString();
            txtCarrosserietype.Text = row[7].ToString();
            txtKilometerstand.Text = row[8].ToString();
            txtBouwjaar.Text = row[9].ToString();
            txtKleur.Text = row[10].ToString();
            txtPrijs.Text = row[11].ToString();

            if (row[12].ToString() == "N")
            {
                btnHuren.Content = "Auto niet beschikaar";
                btnHuren.IsEnabled = false;
            }
            else
            {
                btnHuren.Content = "Deze auto huren !";
                btnHuren.IsEnabled = true;
            }

            if (row[13].ToString() == "/")
            {

                path = "pack://application:,,/Layout/AutoImages/FotoNietBeschikbaar.jpg";
                s = (ImageSource)imsc.ConvertFromString(path);
                AutoImage.Source = s;
            }
            else
            {
                path = "pack://application:,,/Layout/AutoImages/" + row[13].ToString();
                s = (ImageSource)imsc.ConvertFromString(path);
                AutoImage.Source = s;
            }

            Gehuurde_Auto.AutoID = (int)row[0];
            Gehuurde_Auto.Merk = row[1].ToString();
            Gehuurde_Auto.Model = row[2].ToString();
            Gehuurde_Auto.Prijs = double.Parse(row[11].ToString());

        }
	}
}