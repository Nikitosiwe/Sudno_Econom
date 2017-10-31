using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Econom_Sudno.Models;

namespace Econom_Sudno.HelpClasses
{
    class RouteCalculation
    {
        /*
        ship
        windStrength - сила ветра
        flowStrength - сила течения
        Q = 24*q*(N+Nw)*10^-6
        q - удельный расход топлива.
        N - мощьность двигателя.
        Nw - мощьность погоды

        Осадка
        Высота
        Длина
        Нагруженность
        */

        public static double getFuelExpenses(Rout r, ShipTemplate ST)
        {
            double fuelExpenses;

            double windStrength = r.Wind_Speed;
            double flowStrength = r.Flow_Speed;

            double WindStrength = 0.08 * /*ship.SailArea*/((ST.Stroke_Index3-ST.Stroke_Index4)*ST.Stroke_Index2) * (windStrength * windStrength);
            double h = 20;
            

            double FlowStrength = 0;
            if (h > /*ship.VesselDraft*/ST.Stroke_Index4 * 3)
            {
                FlowStrength = 15 * /*ship.LoadingArea*/ST.Stroke_Index1 * (flowStrength * flowStrength);
            }
            else
                if (h > ST.Stroke_Index4 * 2)
                {
                    FlowStrength = 20 * ST.Stroke_Index1 * (flowStrength * flowStrength);
                }
                else
                    if (h > ST.Stroke_Index4 * 1.1)
                    {
                        FlowStrength = 40 * ST.Stroke_Index1 * (flowStrength * flowStrength);
                    }

            double wetherStrenght;

            if (FlowStrength >= WindStrength)
            {
                wetherStrenght= FlowStrength;
            }
            else
            {
                wetherStrenght= WindStrength;
            }

            fuelExpenses = (24 * ST.Parking_Index2 * (ST.Parking_Index2 + wetherStrenght) * Math.Pow(10, -6)) * r.Route_length;

            return fuelExpenses;

        }


    }
}
