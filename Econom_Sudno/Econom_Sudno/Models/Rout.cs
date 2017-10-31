using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

using System.Windows;

namespace Econom_Sudno.Models
{
    public class Rout : INotifyPropertyChanged
    {
        public string Start_City{get;set;}
        public string End_City { get; set; }

        private double wind_Speed;
        public double Wind_Speed
        {
            get { return wind_Speed; }
            set { wind_Speed = value; OnPropertyChanged(); RoutPartsUpdate(); }
        }
        private double flow_Speed;
        public double Flow_Speed
        {
            get { return flow_Speed; }
            set { flow_Speed = value; OnPropertyChanged(); RoutPartsUpdate(); }
        }
        private int route_length;
        public int Route_length
        {
            get { return route_length; }
            set { route_length = value; OnPropertyChanged(); RoutPartsUpdate(); }
        }

        private ObservableCollection<RoutPart> routParts { get; set; }
        public ObservableCollection<RoutPart> RoutParts
        {
            get { return routParts; }
            set { routParts = value; OnPropertyChanged(); }
        }

        private ShipTemplate shipTemplate;



        public Rout(string start_city, string end_city, double wind_Speed, double flow_Speed, int route_length, ShipTemplate ST)
        {
            Start_City = start_city;
            End_City = end_city;
            Wind_Speed = wind_Speed;
            Flow_Speed = flow_Speed;
            Route_length = route_length;
            shipTemplate = ST;

            RoutParts = new ObservableCollection<RoutPart>();
            RoutPartsUpdate();
        }




        public void RoutPartsUpdate()
        {
            if (RoutParts == null) return;
            RoutParts.Clear();
            RoutParts.Add(new RoutPart(shipTemplate, Route_length * 0.1, shipTemplate.Parking_Index3 - Wind_Speed - Flow_Speed , shipTemplate.Parking_Index4 - Wind_Speed - Flow_Speed));
            RoutParts.Add(new RoutPart(shipTemplate, Route_length * 0.8, shipTemplate.Parking_Index3 - Wind_Speed - Flow_Speed, shipTemplate.Parking_Index4 - Wind_Speed - Flow_Speed));
            RoutParts.Add(new RoutPart(shipTemplate, Route_length * 0.1, shipTemplate.Parking_Index3 - Wind_Speed - Flow_Speed, shipTemplate.Parking_Index4 - Wind_Speed - Flow_Speed));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
