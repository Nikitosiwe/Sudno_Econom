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

using Econom_Sudno.ViewModels;
using Econom_Sudno.Context;
using Econom_Sudno.Models;

namespace Econom_Sudno
{
    /// <summary>
    /// Логика взаимодействия для SetNewShipTemplateName.xaml
    /// </summary>
    public partial class SetNewShipTemplateName : Window
    {
        public SetNewShipTemplateName()
        {
            InitializeComponent();
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (NewShipTemplateName.Text == "")
            {
                this.Message.Text = "Введите название шаблона";
                this.Message.Foreground = Brushes.Red;
                this.Message.Visibility = Visibility.Visible;
                return;
            }
            using (UserContext db = new UserContext())
            {
                foreach (ShipTemplate ST in db.ShipTemplates)
                {
                    if (NewShipTemplateName.Text == ST.Name)
                    {
                        this.Message.Text = "Шаблон с таким названием уже есть";
                        this.Message.Foreground = Brushes.Red;
                        this.Message.Visibility = Visibility.Visible;
                        return;
                    }
                }
            }
            ((MainWindow_ViewModel)this.Owner.DataContext).CurrentShipTemplate.Name = NewShipTemplateName.Text;
            this.DialogResult = true;
        }
    }
}
