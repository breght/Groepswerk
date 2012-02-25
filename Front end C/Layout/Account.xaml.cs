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

namespace Front_end_C
{
	/// <summary>
	/// Interaction logic for Account.xaml
	/// </summary>
	public partial class Account : Window
	{
		public Account()
		{
			this.InitializeComponent();
            MouseDown += delegate { DragMove(); };
		}

        /// <summary>
        /// Clicke event van de button BtnOpslaan.
        /// Deze methode word gebruikt voor het opslaan van de wijzigingen in de gegevens van de huidig aangemelde klant.
        /// De interactie met de webservice word afgehandeld door de klasse Klant, dmv de methode Update.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnOpslaan_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Wilt u deze wijzigingen aan uw account opslaan ?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            string voornaam = txtVoornaam.Text;
            string achternaam = txtAchternaam.Text;
            string adres = txtAdres.Text;
            int postcode = int.Parse(txtPostcode.Text);
            string rijksregisternummer = txtRijksregisternummer.Text;
            string telefoonnummer = txtTelefoonnummer.Text;
            string gsm = txtGSM.Text;
            DateTime geboortedatum = DateTime.Parse(dtpGeboortedatum.Text);
            string wachtwoord = txtWachtwoord.Password;

            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    if (Klant.Update(voornaam, achternaam, adres, postcode,rijksregisternummer, telefoonnummer, gsm, geboortedatum, wachtwoord))
                    {
                        MessageBox.Show("Uw wijzigingen werden succesvol opgeslagen", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Er is een fout opgetreden", "", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();    
            }
        }

        /// <summary>
        /// De wijzigingen worden niet opgeslaan, het scherm word afgesloten.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnVerwerpen_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Wilt u dit scherm verlaten zonder wijzigingen te bewaren?", "", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// De account van de huidig aangemelde klant word verwijderd.
        /// Interactie met de webservice word afgehandeld door de klasse Klant, dmv de methode Delete
        /// De applicatie word afgesloten.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Bent u zeker dat u uw account wilt verwijderen ?", "Bevestiging", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    if (Klant.Delete())
                    {
                        MessageBox.Show("Uw account werd succesvol verwijderd. Bedankt om deze service te gebruiken.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Er is een fout opgetreden","",MessageBoxButton.OK,MessageBoxImage.Error);
                this.Close();
            }
        }

        /// <summary>
        /// Gegevens van de klant worden ingevuld in de respectievelijke textvelden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtVoornaam.Text = Klant.Voornaam;
            txtAchternaam.Text = Klant.Achternaam;
            txtAdres.Text = Klant.Adres;
            txtPostcode.Text = Klant.Postcode.ToString();
            txtRijksregisternummer.Text = Klant.Rijksregisternummer;
            txtTelefoonnummer.Text = Klant.Telefoonnummer;
            txtGSM.Text = Klant.GSMNummer;
            dtpGeboortedatum.SelectedDate = Klant.Geboortedatum;
            txtEmailadres.Text = Klant.Emailadres;
            txtWachtwoord.Password = Klant.Wachtwoord;

            txtEmailadres.IsReadOnly = true;
        }
	}
}