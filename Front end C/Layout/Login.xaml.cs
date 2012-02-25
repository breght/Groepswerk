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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Front_end_C.Layout;

namespace Front_end_C
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            MouseDown += delegate { DragMove(); };
        }

        /// <summary>
        /// Click event van de knop btnLogin.
        /// Methode die gebruikt word om klanten en admins in te loggen.
        /// Allereerst word er geprobeerd een klant in te loggen. Indien de methode Login de waarde FALSE teruggeeft, word er geprobeerd een admin in te loggen.
        /// Indien dit ook mislukt word er een loginException opgeworpen (zoals beschreven in LoginException.cs).
        /// Indien gebruikers foute gegevens ingeven, worden via de respectievelijke classes input controles gedaan, en exceptions opgeworpen die hier worden opgevangen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user_email = txtEmail.Text;
            string user_password = txtWachtwoord.Password;

            try
            {
                if (Klant.Login(user_email, user_password)) //Probeer Klant in te loggen.
                {
                    var p = new Probeersel();
                    this.Visibility = System.Windows.Visibility.Collapsed;
                    p.Show(); //Klanten scherm laten zien.
                }
                else //Geen klant gevonden met deze logingegevens. Mss is het een admin?
                {
                    if (Admin.Login(user_email, user_password)) //Probeer Admin in te loggen.
                    {
                        var adm = new AdminModule();
                        this.Visibility = System.Windows.Visibility.Collapsed;
                        adm.Show(); //Admin scherm laten zien.
                    }
                    else //Geen gebruiker of admin gevonden, throw exception.
                    {
                        throw new Classes.LoginException();
                    }
                }
            }
            catch (Classes.LoginException ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Classes.InputException ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception)
            {
                MessageBox.Show("Er is een fout opgetreden");
            }
        }

        /// <summary>
        /// Applicatie word gesloten.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// txtEmail krijgt de focus bij het opstarten van het programma.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtEmail.Focus();
        }

        /// <summary>
        /// Registratie scherm word geopend.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            var reg = new Registratie();
            this.Visibility = System.Windows.Visibility.Hidden;
            reg.Show();
        }
    }
}
