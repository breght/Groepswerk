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
using Front_end_C.Classes;
using System.Collections;

namespace Front_end_C
{
	/// <summary>
	/// Interaction logic for Huren.xaml
	/// </summary>
	public partial class Huren : Window
	{
		public Huren()
		{
			this.InitializeComponent();
            MouseDown += delegate { DragMove(); };
		}

        /// <summary>
        /// Click event van de knop btnHuren
        /// Deze methode word gebruikt om een auto te huren.
        /// De gebruiker word verwacht twee data mee te gegeven, indien dit niet gebeurt word er een exception opgeworpen.
        /// Via de klasse Gehuurde_auto word de methode Huur aangeroepen, die instaat voor het verwerken van de opdracht.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnHuren_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (dtpVan.SelectedDate == null || dtpTot.SelectedDate == null)
                {
                    throw new Classes.InputException("Gelieve twee data te kiezen.");
                }

                if (Classes.Gehuurde_Auto.Huur(Klant.Klant_ID,Gehuurde_Auto.AutoID,DateTime.Parse(dtpVan.SelectedDate.ToString()),DateTime.Parse(dtpTot.SelectedDate.ToString())))
                {
                    MessageBox.Show("U hebt de " + Gehuurde_Auto.Merk + " " + Gehuurde_Auto.Model + " gehuurd.", "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    throw new Exception();
                }

                this.Close();
            }
            catch(Classes.InputException ex)
            {
                MessageBox.Show(ex.Message,"Fout",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("Er is een fout opgetreden","",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Scherm word gesloten.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCancel_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// lblAutoDetails krijgt het merk en het model van de geselecteerde auto als waarde.
        /// lblPrijs krijgt de prijs van de geselecteerde auto als waarde.
        /// Beide datum controls worden ingesteld zodat er geen datum voor de huidige dag kan geselecteerd worden.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblAutoDetails.Content = Gehuurde_Auto.Merk + " " + Gehuurde_Auto.Model;
            lblPrijs.Content = "€ " + Gehuurde_Auto.Prijs;
            dtpVan.DisplayDateStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            dtpTot.DisplayDateStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }
	}
}