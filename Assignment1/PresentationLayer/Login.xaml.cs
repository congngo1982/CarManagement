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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MemberDAO memberDAO;
        public Login()
        {
            InitializeComponent();
            if(memberDAO == null)
            {
                memberDAO = new MemberDAO();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            try
            {
                Member mem = memberDAO.CheckMember(username, password);
                if (mem != null)
                {
                    MainWindow mainWindow = new MainWindow(mem);
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password is Incorrect !!!");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
