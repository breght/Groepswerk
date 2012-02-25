using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Front_end_C.Layout
{
    /// <summary>
    /// Interaction logic for Registratie.xaml
    /// </summary>
    public partial class Registratie : Window
    {
        public Registratie()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click event van de button btnSubmit, waarin een nieuwe klant word aangemaakt.
        /// Methode create word beschreven in de klasse Klant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string voornaam = txtVoornaam.Text;
                string achternaam = txtAchternaam.Text;
                string adres = txtAdres.Text;
                int postcode = int.Parse(txtPostcode.Text);
                string emailadres = txtEmailadres.Text;
                string rijksregisternummer = txtRijksregisternummer.Text;
                string telefoonnummer = txtTelefoonnummer.Text;
                string gsm = txtGSMnummer.Text;
                DateTime geboortedatum = DateTime.Parse(dtpGeboortedatum.Text);
                string wachtwoord = txtWachtwoord.Password;

                bool succes;

                succes = Klant.Create(voornaam, achternaam, adres, postcode, emailadres, rijksregisternummer, telefoonnummer, gsm, geboortedatum, wachtwoord);
                if (succes)
                {
                    MessageBox.Show("Registratie geslaagd", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);

                    var l = new Login();
                    this.Visibility = System.Windows.Visibility.Collapsed;
                    l.Show();
                }
                else
                {
                    MessageBox.Show("Registratie niet geslaagd", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Classes.InputException ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("Er is een fout opgetreden", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Click event van de button btnClose.
        /// Het scherm word gesloten.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

            var l = new Login();
            this.Close();
            l.Show();
        }
    }
}
