using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Econom_Sudno.Models
{
    public class RoutPart : INotifyPropertyChanged
    {
        private double length;
        public double Length
        {
            get { return length; }
            set { length = value; OnPropertyChanged(); }
        }
        private double minSpeed;
        public double MinSpeed
        {
            get { return minSpeed; }
            set { minSpeed = value; OnPropertyChanged(); }
        }
        private double maxSpeed;
        public double MaxSpeed
        {
            get { return maxSpeed; }
            set { maxSpeed = value; OnPropertyChanged(); }
        }
        private double factSpeed;
        public double FactSpeed
        {
            get { return factSpeed; }
            set { factSpeed = value; OnPropertyChanged(); }
        }
        private double minTime;
        public double MinTime
        {
            get { return minTime; }
            set { minTime = value; OnPropertyChanged(); }
        }
        private double maxTime;
        public double MaxTime
        {
            get { return maxTime; }
            set { maxTime = value; OnPropertyChanged(); }
        }
        private double factTime;
        public double FactTime
        {
            get { return factTime; }
            set { factTime = value; OnPropertyChanged(); UpdateFactSpeed();  }
        }

        int MinPower = 25;
        int MaxPower = 80;
        private double power;
        public double Power
        {
            get { return power; }
            set { power = value; OnPropertyChanged(); }
        }

        private double fuelConsumption;
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; OnPropertyChanged(); }
        }



        private ShipTemplate shipTemplate;

        public RoutPart(ShipTemplate ST, double l, double minS, double maxS)
        {
            Length = l;
            MinSpeed = minS;
            MaxSpeed = maxS;
            FactSpeed = (int)((minS + maxS) / 2);
            MaxTime = (int)(l / minS);
            MinTime = (int)(l / maxS);
            FactTime = (int)(l / FactSpeed);
            Power = (int)((MinPower + MaxPower)/2);
            FuelConsumption = ((ST.Parking_Index1 * Power) / 100) * ST.Parking_Index2 * Math.Pow(10, -6);
            shipTemplate = ST;
            UpdateFactSpeed();
        }

        public void UpdateFactSpeed()
        {
            //FactSpeed = (int)(Length / FactTime);
            FactSpeed = Math.Round((((100 * (MaxTime - FactTime)) / (MaxTime - MinTime)) * (MaxSpeed - MinSpeed)) / 100 + MinSpeed,1);
            UpdatePower();
        }

        public void UpdatePower()
        {
            Power =  Math.Round((((100 * (FactSpeed - MinSpeed)) / (MaxSpeed - MinSpeed)) * (MaxPower - MinPower)) / 100 + MinPower, 1);
            UpdateFuelConsumption();
        }

        public void UpdateFuelConsumption()
        {
            if (shipTemplate == null) return;
            FuelConsumption = ((shipTemplate.Parking_Index1 * Power) / 100) * shipTemplate.Parking_Index2 * Math.Pow(10, -6) * FactTime;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
