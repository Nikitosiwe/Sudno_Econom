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

using Econom_Sudno.Models;
using Econom_Sudno.Context;
using Econom_Sudno.ViewModels;

namespace Econom_Sudno
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            string Text_Name = NameBox.Text;
            string Text_Pass = PassBox.Password;
            try
            {
                using (UserContext db = new UserContext())
                {
                    var users = db.Users;

                    //MessageBox.Show(users.ToString());
                    foreach (User u in users)
                    {
                        if (u.Name == Text_Name && u.Pass == Text_Pass)
                        {
                            this.DialogResult = true;
                            ((MainWindow_ViewModel)this.Owner.DataContext).CurrentUser = u;
                            ((MainWindow_ViewModel)this.Owner.DataContext).AllUsers_Update();
                            ((MainWindow_ViewModel)this.Owner.DataContext).AllUsersApplications_Update();
                            return;
                        }
                    }
                    MessageBox.Show("Неверный логин или пароль");
                    NameBox.Text = "";
                    PassBox.Password = "";
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    MessageBox.Show(ex.InnerException.ToString());
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            ProfileWindow profWin = new ProfileWindow(new User(), true);
            profWin.Owner = this.Owner;
            profWin.ShowDialog();
        }
    }
}
