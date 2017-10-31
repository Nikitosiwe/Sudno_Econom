using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Econom_Sudno.Models
{
    public class ShipTemplate :INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string name { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private bool strokeMode { get; set; }
        public bool StrokeMode
        {
            get { return strokeMode; }
            set { strokeMode = value; OnPropertyChanged(); }
        }
        private bool parkingMode { get; set; }
        public bool ParkingMode
        {
            get { return parkingMode; }
            set { parkingMode = value; OnPropertyChanged(); }
        }

        private int stroke_Index1 { get; set; }
        public int Stroke_Index1
        {
            get { return stroke_Index1; }
            set { stroke_Index1 = value; OnPropertyChanged(); }
        }
        private int stroke_Index2 { get; set; }
        public int Stroke_Index2
        {
            get { return stroke_Index2; }
            set { stroke_Index2 = value; OnPropertyChanged(); }
        }
        private int stroke_Index3 { get; set; }
        public int Stroke_Index3
        {
            get { return stroke_Index3; }
            set { stroke_Index3 = value; OnPropertyChanged(); }
        }
        private int stroke_Index4 { get; set; }
        public int Stroke_Index4
        {
            get { return stroke_Index4; }
            set { stroke_Index4 = value; OnPropertyChanged(); }
        }

        private int parking_Index1 { get; set; }
        public int Parking_Index1
        {
            get { return parking_Index1; }
            set { parking_Index1 = value; OnPropertyChanged(); }
        }
        private int parking_Index2 { get; set; }
        public int Parking_Index2
        {
            get { return parking_Index2; }
            set { parking_Index2 = value; OnPropertyChanged(); }
        }
        private int parking_Index3 { get; set; }
        public int Parking_Index3
        {
            get { return parking_Index3; }
            set { parking_Index3 = value; OnPropertyChanged(); }
        }
        private int parking_Index4 { get; set; }
        public int Parking_Index4
        {
            get { return parking_Index4; }
            set { parking_Index4 = value; OnPropertyChanged(); }
        }


        public ShipTemplate()
        {
            StrokeMode = true;
        }

        public void SetValues(ShipTemplate curentTemplate)
        {
            Id = curentTemplate.Id;
            Name = curentTemplate.Name;
            StrokeMode = curentTemplate.StrokeMode;
            ParkingMode = curentTemplate.ParkingMode;
            Stroke_Index1 = curentTemplate.Stroke_Index1;
            Stroke_Index2 = curentTemplate.Stroke_Index2;
            Stroke_Index3 = curentTemplate.Stroke_Index3;
            Stroke_Index4 = curentTemplate.Stroke_Index4;
            Parking_Index1 = curentTemplate.Parking_Index1;
            Parking_Index2 = curentTemplate.Parking_Index2;
            Parking_Index3 = curentTemplate.Parking_Index3;
            Parking_Index4 = curentTemplate.Parking_Index4;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("ID: "+Id.ToString()+"\n");
            str.Append("Name: "); if (Name != null) str.Append(Name.ToString()); else str.Append(""); str.Append("\n");
            str.Append("StrokeMode: "); str.Append(StrokeMode.ToString()); str.Append("\n");
            str.Append("ParkingMode: "); str.Append(ParkingMode.ToString()); str.Append("\n");
            str.Append("Stroke_Index1: "); if (Stroke_Index1 != null) str.Append(Stroke_Index1.ToString()); else str.Append(""); str.Append("\n");
            str.Append("Stroke_Index2: "); if (Stroke_Index2 != null) str.Append(Stroke_Index2.ToString()); else str.Append(""); str.Append("\n");
            str.Append("Stroke_Index3: "); if (Stroke_Index3 != null) str.Append(Stroke_Index3.ToString()); else str.Append(""); str.Append("\n");
            str.Append("Stroke_Index4: "); if (Stroke_Index4 != null) str.Append(Stroke_Index4.ToString()); else str.Append(""); str.Append("\n");
            str.Append("Parking_Index1: "); if (Parking_Index1 != null) str.Append(Parking_Index1.ToString()); else str.Append(""); str.Append("\n");
            str.Append("Parking_Index2: "); if (Parking_Index2 != null) str.Append(Parking_Index2.ToString()); else str.Append(""); str.Append("\n");
            str.Append("Parking_Index3: "); if (Parking_Index3 != null) str.Append(Parking_Index3.ToString()); else str.Append(""); str.Append("\n");
            str.Append("Parking_Index4: "); if (Parking_Index4 != null) str.Append(Parking_Index4.ToString()); else str.Append(""); str.Append("\n");
            return str.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));

            }
                
        }
    }
}
