using BusinessObject.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AddCar.xaml
    /// </summary>
    public partial class AddCar : Window
    {
       private CarDAO carDAO;
        private MainWindow mainWindow;
        public AddCar(CarDAO carDAO, MainWindow mainWindow)
        {
            InitializeComponent();
            this.carDAO = carDAO;
            this.mainWindow = mainWindow;
            comboCategory.ItemsSource = mainWindow.getCategories();
            comboCategory.SelectedIndex = 0;
            txtId.IsEnabled = false;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = txtName.Text;
                if (name.Trim().Length == 0)
                {
                    throw new Exception("Name is Empty");
                }
                string brand = txtBrand.Text;
                string manu = txtManufacture.Text;
                string color = txtColor.Text;
                int cate = mainWindow.ConvertCategory(comboCategory.SelectedIndex);
                Car car = new Car(name, brand, color, manu, cate);
                carDAO.AddCar(car);
                mainWindow.LoadForm();
                this.Close();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
