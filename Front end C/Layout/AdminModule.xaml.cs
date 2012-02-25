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
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace Front_end_C.Layout
{
    /// <summary>
    /// Interaction logic for AdminModule.xaml
    /// </summary>
    public partial class AdminModule : Window
    {
        public AdminModule()
        {
            InitializeComponent();
        }

        WebService.WebService ws = new WebService.WebService();
        DataSet objDataset;
        DataTable objDataTable;

        string activeTable;  

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                switch (cboTables.SelectedIndex)
                {
                    case 0:
                        objDataset = ws.auto_getDataSetAuto();
                        objDataTable = objDataset.Tables["tblAuto"];
                        Datagrid.ItemsSource = objDataset.Tables[0].DefaultView;
                        activeTable = "tblAuto";
                        break;
                    case 1:
                        objDataset = ws.klant_getDataSetKlant();
                        objDataTable = objDataset.Tables["tblKlant"];
                        Datagrid.ItemsSource = objDataset.Tables[0].DefaultView;
                        activeTable = "tblKlant";
                        break;
                    case 2:
                        objDataset = ws.verhuur_getDataSetVerhuur();
                        objDataTable = objDataset.Tables["tblVerhuurdeWagens"];
                        Datagrid.ItemsSource = objDataset.Tables[0].DefaultView;
                        activeTable = "tblVerhuurdeWagens";
                        break;
                    case 3:
                        objDataset = ws.admin_GetDataSetAdmin();
                        objDataTable = objDataset.Tables["tblAdmins"];
                        Datagrid.ItemsSource = objDataset.Tables[0].DefaultView;
                        activeTable = "tblAdmins";
                        break;
                }
            }
            catch (Exception)
            {
                //log error
            }
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult d = MessageBox.Show("Bent u zeker dat u deze rij wilt verwijderen?", "Confirmatie", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (d == MessageBoxResult.Yes)
                {
                    int ID = (int)objDataTable.Rows[Datagrid.SelectedIndex][0];
                    objDataset.Tables[0].Rows.RemoveAt(Datagrid.SelectedIndex);
                    string result = "";

                    switch (activeTable)
                    {
                        case "tblAuto":
                            result = ws.auto_remove(ID);
                            break;
                        case "tblKlant":
                            result = ws.klant_remove(ID);
                            break;
                        case "tblVerhuurdeWagens":
                            result = ws.verhuur_remove(ID);
                            break;
                        case "tblAdmins":
                            //
                            break;
                    }

                    if (result != "")
                    {
                        MessageBox.Show(result, "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Fout tijdens het verwijderen.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception)
            {
                //log error
            }
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            Array a;
            ArrayList al;
            string result = "";

            try
            {
                Datagrid.CommitEdit(DataGridEditingUnit.Row, true);

                switch (activeTable)
                {
                    case "tblAuto":
                        a = objDataset.Tables[0].Rows[Datagrid.SelectedIndex].ItemArray;
                        al = new ArrayList(a);
                        result = ws.auto_update(al.ToArray());
                        break;
                    case "tblAdmins":
                        a = objDataset.Tables[0].Rows[Datagrid.SelectedIndex].ItemArray;
                        //result = al = new ArrayList(a);
                        //
                        break;
                    case "tblVerhuurdeWagens":
                        a = objDataset.Tables[0].Rows[Datagrid.SelectedIndex].ItemArray;
                        al = new ArrayList(a);
                        result = ws.verhuur_update(al.ToArray());
                        break;
                    case "tblKlant" :
                        result = "tblKlant kan je niet bewerken !";
                        break;
                }

                if (result != "")
                {
                    MessageBox.Show(result, "succes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Fout tijdens het bewerken van de rij", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                //log error
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddNewRow_Click(object sender, RoutedEventArgs e)
        {
            string result = "";
            //Array a;
            ArrayList al = new ArrayList();

            try {

                Datagrid.CommitEdit(DataGridEditingUnit.Row, true);

                switch (activeTable)
                {
                    case "tblKlant":
                        //Probleeeeeeeeeeeeeeeeeem. Ik kan geen values uit een row in een wpf datagrid halen, wtf? :)
                        break;
                    case "tblAuto":
                        //
                        break;
                    case "tblAdmins":
                        //
                        break;
                    case "tblVerhuurdeWAgens":
                        //
                        break;
                }

                if (result != "")
                {
                    MessageBox.Show(result, "Succes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Er is iets fout gegaan","",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        
    }
}
