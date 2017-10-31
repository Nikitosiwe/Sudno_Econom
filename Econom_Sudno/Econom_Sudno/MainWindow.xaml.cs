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

using Econom_Sudno.ViewModels;
using Econom_Sudno.Models;

namespace Econom_Sudno
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindow_ViewModel(this);
        }

        private List<Button> City_list = new List<Button>();
        private List<Button> SelectedCity_list = new List<Button>();
        public ArrowLine2 selectedArrow = new ArrowLine2();


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoginWindow loginW = new LoginWindow();
            loginW.Owner = this;
            if (loginW.ShowDialog() != true) this.Close();
        }

        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            LoginWindow loginW = new LoginWindow();
            loginW.Owner = this;
            loginW.ShowDialog();
        }

        private void OpenUserProfile(object sender, RoutedEventArgs e)
        {
            ProfileWindow profWin = new ProfileWindow(((MainWindow_ViewModel)DataContext).CurrentUser,false);
            profWin.Owner = this;
            profWin.ShowDialog();
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SaveNewShipTemplate(object sender, RoutedEventArgs e)
        {
            ((MainWindow_ViewModel)this.DataContext).SaveNewShipTemplate();
        }

        private void DeleteCurrentShipTemplate(object sender, RoutedEventArgs e)
        {
            ((MainWindow_ViewModel)this.DataContext).DeleteCurrentShipTemplate();
        }

        private void ChangeCurrentShipTemplate(object sender, RoutedEventArgs e)
        {
            ((MainWindow_ViewModel)this.DataContext).ChangeCurrentShipTemplate();
        }

        private void ShipTemplate_Click(object sender, MouseButtonEventArgs e)
        {
            TextBlock TB = (TextBlock)sender;
            //((MainWindow_ViewModel)this.DataContext).CurrentShipTemplate=(ShipTemplate)(TB.GetBindingExpression(System.Windows.Controls.TextBlock.TextProperty).DataItem);
            ((MainWindow_ViewModel)this.DataContext).ChangeShipTemplate(((ShipTemplate)(TB.GetBindingExpression(System.Windows.Controls.TextBlock.TextProperty).DataItem)).Id);
        }

        private void MapControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Grid grid = sender as Grid;
            foreach (object o in ((Grid)sender).Children)
            {
                Button but = o as Button;
                if (but != null)
                {
                    //but.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(ButtonMouseDown), true);
                    //but.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(ButtonMouseUp), true);
                    //but.AddHandler(UIElement.MouseMoveEvent, new MouseEventHandler(ButtonMouseMove), true);
                    but.AddHandler(Button.ClickEvent, new RoutedEventHandler(Button_Click), true);

                    but.Style = (Style)this.Resources["EllipseButton"];
                    City_list.Add(but);
                    continue;
                }
                //ArrowLine2 arrow = o as ArrowLine2;
                //if (arrow != null)
                //{
                //    arrow.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(ArrowMouseDown), true);
                //    arrow.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(ArrowMouseUp), true);
                //    arrow.AddHandler(UIElement.MouseMoveEvent, new MouseEventHandler(ArrowMouseMove), true);
                //    continue;
                //}
            }
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (((Button)sender).Style == (Style)this.Resources["EllipseButton"])
            //{
            //    if (SelectedCity_list.Count == 0)
            //    {
            //        ((Button)sender).Style = (Style)this.Resources["EllipseButton_select"];
            //        SelectedCity_list.Add((Button)sender);
            //        ((CheckBox)(((StackPanel)this.FindName("CheckBox_" + ((Button)sender).Name)).Children[0])).IsChecked=true;
            //    }
            //    else
            //    {
            //        string current_city_name = ((Button)sender).Name;
            //        List<string> cities = new List<string>();
            //        //MessageBox.Show(SelectedCity_list[SelectedCity_list.Count - 1].Name);
            //        bool flag = false;
            //        foreach(ArrowLine2 arrow in ((Grid)this.FindName("Routs_" + SelectedCity_list[SelectedCity_list.Count-1].Name)).Children)
            //        {
            //            //cities.Add(arrow.Name.Split('_')[2]);
            //            if (arrow.Name.Split('_')[2] == current_city_name) { flag = true; break; }
            //        }
            //        if (flag)
            //        {
            //            foreach(ArrowLine2 arrow in ((Grid)this.FindName("Routs_" + SelectedCity_list[SelectedCity_list.Count-1].Name)).Children)
            //            {
            //            arrow.Visibility = Visibility.Visible;
            //                if (arrow.Name.Split('_')[2] == current_city_name) { arrow.StrokeThickness = 2; arrow.Stroke = Brushes.Blue; } else { arrow.Visibility = Visibility.Hidden; }
            //            }
            //            ((Button)sender).Style = (Style)this.Resources["EllipseButton_select"];
            //            SelectedCity_list.Add((Button)sender);
            //            ((CheckBox)(((StackPanel)this.FindName("CheckBox_" + ((Button)sender).Name)).Children[0])).IsChecked = true;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Нет маршрута в этот город");
            //        }
            //    }
            //}
            //else
            //{
            //    foreach (Button but in SelectedCity_list)
            //    {
            //        if (but == ((Button)sender)) return;
            //    }

            //    ((Button)sender).Style = (Style)this.Resources["EllipseButton"];
            //    SelectedCity_list.Remove((Button)sender);
            //    ((CheckBox)(((StackPanel)this.FindName("CheckBox_" + ((Button)sender).Name)).Children[0])).IsChecked = false;
            //    foreach (ArrowLine2 arrow in ((Grid)this.FindName("Routs_" + ((Button)sender).Name)).Children)
            //    {
            //        arrow.Visibility = Visibility.Visible;
            //        arrow.Stroke = Brushes.Gray;
            //        arrow.StrokeThickness = 1;
            //    }
            //    if (SelectedCity_list.Count > 0)
            //    {
            //        foreach (ArrowLine2 arrow in ((Grid)this.FindName("Routs_" + SelectedCity_list[SelectedCity_list.Count-1].Name)).Children)
            //        {
            //            arrow.Visibility = Visibility.Visible;
            //            arrow.Stroke = Brushes.Gray;
            //            arrow.StrokeThickness = 1;
            //        }
            //    }
            //}

            Button clicked_but = ((Button)sender);
            if (SelectedCity_list.Count == 0)
            {
                SelectedCity_list.Add(clicked_but);
            }
            else
            {
                if ((SelectedCity_list[SelectedCity_list.Count - 1] != clicked_but)&&((ArrowLine2)this.FindName("Route_" + ((Button)SelectedCity_list[SelectedCity_list.Count - 1]).Name + "_" + clicked_but.Name)) == null)
                {
                    MessageBox.Show("Нет прямого маршрута к выбранному порту"); 
                    return; 
                }
                if (SelectedCity_list[SelectedCity_list.Count - 1] == clicked_but) 
                {
                    int index = SelectedCity_list.LastIndexOf(clicked_but);
                    SelectedCity_list.RemoveAt(index);
                    //MessageBox.Show(clicked_but.Name);
                    //MessageBox.Show(((Grid)this.FindName("Routs_" + clicked_but.Name)).Name);
                    //foreach (ArrowLine2 arrow in ((Grid)this.FindName("Routs_" + clicked_but.Name)).Children)
                    //{
                    //    arrow.Visibility = Visibility.Hidden;
                    //}
                    //if (!(bool)((CheckBox)((StackPanel)this.FindName("CheckBox_" + clicked_but.Name)).Children[0]).IsChecked)
                    //{
                        
                    //}
                }
                else
                {
                    SelectedCity_list.Add(clicked_but);
                }
            }

            Routs_Update();

            DrawSelectedCitys();
            DrawRouts();
        }

        public void Routs_Update()
        {
            ((MainWindow_ViewModel)this.DataContext).SelectedRout_list_Update(SelectedCity_list);
        }


        public void DrawSelectedCitys()
        {
            foreach (Button but in City_list)
            {
                but.Style = (Style)this.Resources["EllipseButton"];
            }
            foreach (Button but in SelectedCity_list)
            {
                //MessageBox.Show(but.Name);
                but.Style = (Style)this.Resources["EllipseButton_select"];
            }
            if (SelectedCity_list.Count>0)
                SelectedCity_list.Last().Style = (Style)this.Resources["EllipseButton_current"];
        }

        public void DrawRouts()
        {
            List<ArrowLine2> arrow_list = new List<ArrowLine2>();
            foreach (Button but in City_list)
            {
                foreach (ArrowLine2 arrow in ((Grid)this.FindName("Routs_" + but.Name)).Children)
                {
                    arrow_list.Add(arrow);
                    arrow.StrokeThickness = 1;
                    arrow.Stroke = Brushes.Gray;
                    if(!(bool)((CheckBox)(((StackPanel)this.FindName("CheckBox_" + but.Name)).Children[0])).IsChecked)
                        arrow.Visibility = Visibility.Hidden;
                }
            }

            for (int i = 1; i < SelectedCity_list.Count; i++)
            {
                ArrowLine2 arrow = ((ArrowLine2)this.FindName("Route_" + ((Button)SelectedCity_list[i - 1]).Name + "_" + ((Button)SelectedCity_list[i]).Name));
                //if (arrow == null) { MessageBox.Show("Нет прямого маршрута к выбранному порту"); return; }
                arrow.Stroke = Brushes.Blue;
                arrow.StrokeThickness = 2;
                arrow.Visibility = Visibility.Visible;
                //MessageBox.Show(((Button)SelectedCity_list[i - 1]).Name + "->" + ((Button)SelectedCity_list[i]).Name);
            }
            

            //foreach (ArrowLine2 arrow in arrow_list)
            //{
            //    if (((Grid)arrow.Parent).Name.Split('_')[1] == currentButton.Name)
            //    {
            //        ((Grid)arrow.Parent).Visibility = Visibility.Visible;
            //        arrow.Visibility = Visibility.Visible;
            //    }
            //}
            if (SelectedCity_list.Count>0)
                foreach (ArrowLine2 arrow in ((Grid)this.FindName("Routs_" + SelectedCity_list.Last().Name)).Children)
                {
                    //((Grid)arrow.Parent).Visibility = Visibility.Visible;
                    arrow.Visibility = Visibility.Visible;
                }
            if(selectedArrow!=null)
            {
                selectedArrow.Stroke = Brushes.Green;
                selectedArrow.StrokeThickness = 2;
            }
        }

        
        private void Arrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Grid grid_City = ((Grid)((ArrowLine2)sender).Parent);
            //Grid grid = ((Grid)grid_City.Parent);
            
            ////foreach(object o in grid.Children)
            ////{
            ////    Grid grid_tmp = o as Grid;
                
            ////    if (grid_tmp != null)
            ////    {
            ////        Panel.SetZIndex(grid_tmp, 0);
            ////        foreach (object ob in grid_tmp.Children)
            ////        {
            ////            ArrowLine2 arrow = ob as ArrowLine2;
            ////            if (arrow != null && (arrow.Name != ((ArrowLine2)sender).Name))
            ////            {
            ////                Panel.SetZIndex(arrow, 0);
            ////                arrow.Stroke = Brushes.Gray;
            ////                arrow.StrokeThickness = 1;
            ////            }
            ////        }
            ////    }
            ////}
            //Panel.SetZIndex(((Grid)this.FindName(grid_City.Name)), 1);
            ////MessageBox.Show(grid_City.Name);
            //((ArrowLine2)sender).Stroke = Brushes.Green;
            //((ArrowLine2)sender).StrokeThickness = 2;
            //Panel.SetZIndex(((ArrowLine2)sender), 1);
            //if (selectedArrow == ((ArrowLine2)sender))
            //    selectedArrow = null;
            //else
            //    selectedArrow = ((ArrowLine2)sender);
            //////DrawSelectedCitys();
            //DrawRouts();
        }

        private void CheckBox_City_Click(object sender, MouseButtonEventArgs e)
        {
            StackPanel panel = (StackPanel)sender;
            string city = panel.Name.Split('_')[1].ToString();
            CheckBox chB = (CheckBox)panel.Children[0];
            string Grid_name = "Routs_"+city;
            if (chB.IsChecked == false)
            {
                chB.IsChecked = true;
                ((Grid)this.FindName(Grid_name)).Visibility = Visibility.Visible;
            } 
            else 
            {
                chB.IsChecked = false;
                ((Grid)this.FindName(Grid_name)).Visibility = Visibility.Hidden;
            }
           
            
        }
        private void CheckBox_City_Checked(object sender, RoutedEventArgs e)
        {
            string city = ((StackPanel)((CheckBox)sender).Parent).Name.Split('_')[1].ToString();
            foreach (ArrowLine2 arrow in ((Grid)this.FindName("Routs_" + city)).Children)
            {
                arrow.Visibility = Visibility.Visible;
            }
        }

        private void CheckBox_City_Unchecked(object sender, RoutedEventArgs e)
        {
            string city = ((StackPanel)((CheckBox)sender).Parent).Name.Split('_')[1].ToString();
            foreach (ArrowLine2 arrow in ((Grid)this.FindName("Routs_" + city)).Children)
            {
                arrow.Visibility = Visibility.Hidden;
            }
        }

        private void Add_RoutPart_on_Rout(object sender, RoutedEventArgs e)
        {
            Rout r = (Rout)this.grid_TowCabels.SelectedItem;
            //r.addRout(10);

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //((Slider)sender).SelectionEnd = e.NewValue;
            //MessageBox.Show(((Grid)((Grid)((Slider)sender).Parent).Parent).Parent.ToString());
        }
    }
}
