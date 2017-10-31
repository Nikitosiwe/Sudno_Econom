using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

using Econom_Sudno.Models;
using Econom_Sudno.ViewModels;
using System.Collections.ObjectModel;

namespace Econom_Sudno.HelpClasses
{
    class SetBindings
    {
        public void SetBindingForAllShipTemplates(MainWindow view_MainWindow,MainWindow_ViewModel MV)
        {
            view_MainWindow.Menu_TemplateList.SetBinding(System.Windows.Controls.MenuItem.ItemsSourceProperty,
                    new Binding
                    {
                        Source = MV,
                        Path = new System.Windows.PropertyPath("AllShipTemplates"),
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                    });
        }

        public void SetBindingForCurrentShipTemplate(MainWindow view_MainWindow, ShipTemplate currentShipTemplate)
        {
            view_MainWindow.Menu_Template.SetBinding(System.Windows.Controls.MenuItem.HeaderProperty,
                    new Binding
                    {
                        Source = currentShipTemplate,
                        TargetNullValue = "Шаблон",
                        Path = new System.Windows.PropertyPath("Name"),
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                    });
            //view_MainWindow.StrokeMode.SetBinding(System.Windows.Controls.RadioButton.IsCheckedProperty,
            //        new Binding
            //        {
            //            Source = currentShipTemplate,
            //            Path = new System.Windows.PropertyPath("StrokeMode"),
            //            Mode = BindingMode.TwoWay,
            //            UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
            //        });
            //view_MainWindow.ParkingMode.SetBinding(System.Windows.Controls.RadioButton.IsCheckedProperty,
            //        new Binding
            //        {
            //            Source = currentShipTemplate,
            //            Path = new System.Windows.PropertyPath("ParkingMode"),
            //            Mode = BindingMode.TwoWay,
            //            UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
            //        });
            view_MainWindow.Stroke_Index1.SetBinding(System.Windows.Controls.TextBox.TextProperty,
                    new Binding
                    {
                        Source = currentShipTemplate,
                        TargetNullValue="",
                        Path = new System.Windows.PropertyPath("Stroke_Index1"),
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger=System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                       
                    });
            view_MainWindow.Stroke_Index2.SetBinding(System.Windows.Controls.TextBox.TextProperty,
                    new Binding
                    {
                        Source = currentShipTemplate,
                        TargetNullValue = "",
                        Path = new System.Windows.PropertyPath("Stroke_Index2"),
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                    });
            view_MainWindow.Stroke_Index3.SetBinding(System.Windows.Controls.TextBox.TextProperty,
                    new Binding
                    {
                        Source = currentShipTemplate,
                        TargetNullValue = "",
                        Path = new System.Windows.PropertyPath("Stroke_Index3"),
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                    });
            view_MainWindow.Stroke_Index4.SetBinding(System.Windows.Controls.TextBox.TextProperty,
                    new Binding
                    {
                        Source = currentShipTemplate,
                        TargetNullValue = "",
                        Path = new System.Windows.PropertyPath("Stroke_Index4"),
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                    });
            view_MainWindow.Parking_Index1.SetBinding(System.Windows.Controls.TextBox.TextProperty,
                    new Binding
                    {
                        Source = currentShipTemplate,
                        TargetNullValue = "",
                        Path = new System.Windows.PropertyPath("Parking_Index1"),
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                    });
            view_MainWindow.Parking_Index2.SetBinding(System.Windows.Controls.TextBox.TextProperty,
                    new Binding
                    {
                        Source = currentShipTemplate,
                        TargetNullValue = "",
                        Path = new System.Windows.PropertyPath("Parking_Index2"),
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                    });
            view_MainWindow.Parking_Index3.SetBinding(System.Windows.Controls.TextBox.TextProperty,
                    new Binding
                    {
                        Source = currentShipTemplate,
                        TargetNullValue = "",
                        Path = new System.Windows.PropertyPath("Parking_Index3"),
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                    });
            view_MainWindow.Parking_Index4.SetBinding(System.Windows.Controls.TextBox.TextProperty,
                    new Binding
                    {
                        Source = currentShipTemplate,
                        TargetNullValue = "",
                        Path = new System.Windows.PropertyPath("Parking_Index4"),
                        Mode = BindingMode.TwoWay,
                        UpdateSourceTrigger = System.Windows.Data.UpdateSourceTrigger.PropertyChanged
                    });

        }
    }
}
