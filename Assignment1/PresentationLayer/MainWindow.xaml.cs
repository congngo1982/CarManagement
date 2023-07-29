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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CarDAO carDAO;
        private CategoryDAO cateDAO;
        private List<string> category;
        private Member member;
        public MainWindow(Member member)
        {
            InitializeComponent();
            this.member = member;
            carDAO = new CarDAO();
            cateDAO = new CategoryDAO();
            LoadForm();
            txtId.IsEnabled = false;
            comboCategory.ItemsSource = this.getCategories();
            comboCategory.SelectedIndex = 0;
            Member.Content = $"Welcome: {member.Name}";
        }
        public void LoadForm()
        {
            if(carDAO != null)
            {
                List<Car> cars = carDAO.GetAllCar();
                listCar.ItemsSource = cars;
                listCar.SelectedIndex = -1;
            }
            txtId.Text = "0";
            txtName.Text = "";
            txtBrand.Text = "";
            txtColor.Text = "";
            txtManufacture.Text = "";
            comboCategory.SelectedIndex = 0;
        }

        private void listCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car car = null;
            try
            {
                car = (Car)listCar.SelectedItem;
            } catch { }
            if(car != null)
            {
                txtId.Text = car.Id + "";
                txtName.Text = car.Name;
                txtBrand.Text = car.Brand;
                txtManufacture.Text = car.Manufacture;
                txtColor.Text = car.Color;
                int? category = car.Category;
                    comboCategory.SelectedIndex = (int)car.Category - 1;
            }
            else
            {
                this.LoadForm(); 
            }
        }
        public List<string> getCategories()
        {
            this.category = new List<string>();
            List<Category> cateList = cateDAO.GetAll();
            foreach(Category c in cateList)
            {
                this.category.Add(c.Name);
            }
            return this.category;
        }

        public int ConvertCategory(int index)
        {
            return index + 1;
        }

        public Car GetCar()
        {
           int id = Int32.Parse(txtId.Text);
            string name = txtName.Text;
            string brand = txtBrand.Text;
           string manu =  txtManufacture.Text;
            string color = txtColor.Text;
            int index = comboCategory.SelectedIndex;
            int cate = ConvertCategory(index);
            Car car = carDAO.GetCarById(id);
            car.Name = name;
            car.Brand = brand;
            car.Manufacture = manu;
            car.Color = color;
            car.Category = cate;
            return car;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            AddCar addCar = new AddCar(carDAO, this);
            addCar.Show();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            this.LoadForm();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtId.Text);
                string name = txtName.Text;
                string brand = txtBrand.Text;
                string manu = txtManufacture.Text;
                string color = txtColor.Text;
                int index = comboCategory.SelectedIndex;
                int cate = ConvertCategory(index);
                Car car = this.carDAO.GetCarById(id);
                if(car == null)
                {
                    throw new Exception("Selection is Empty !!!");
                }
                car.Name = name;
                car.Brand = brand;
                car.Color = color;
                car.Manufacture = manu;
                car.Category = cate;
                carDAO.UpdateCar(car);
                this.LoadForm();
            } catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnExist_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtId.Text);
                this.carDAO.DeleteCar(id);
                this.LoadForm();
            } catch(Exception ex) { MessageBox.Show(ex.Message);}
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login  = new Login();
            login.Show();
            this.Close();
        }
    }
}
