using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Econom_Sudno.Models
{
    public class ArrowLine2 : Shape
    {


        public double X1
        {
            get { return (double)this.GetValue(X1Property); }
            set { this.SetValue(X1Property, value); this.InvalidateVisual(); }
        }

        public static readonly DependencyProperty X1Property = System.Windows.DependencyProperty.Register(
            "X1",
            typeof(double),
            typeof(ArrowLine2),
            new System.Windows.PropertyMetadata(0.0, OnX1PropertyChanged));

        private static void OnX1PropertyChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            ArrowLine2 control = sender as ArrowLine2;

            if (control != null)
            {
                control.InvalidateVisual();
            }
        }

        public double Y1
        {
            get { return (double)this.GetValue(Y1Property); }
            set { this.SetValue(Y1Property, value); this.InvalidateVisual(); }
        }

        public static readonly DependencyProperty Y1Property = System.Windows.DependencyProperty.Register(
            "Y1",
            typeof(double),
            typeof(ArrowLine2),
            new System.Windows.PropertyMetadata(0.0, OnY1PropertyChanged));

        private static void OnY1PropertyChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            ArrowLine2 control = sender as ArrowLine2;

            if (control != null)
            {
                control.InvalidateVisual();
            }
        }




        public double X2
        {
            get { return (double)this.GetValue(X2Property); }
            set { this.SetValue(X2Property, value); this.InvalidateVisual(); }
        }

        public static readonly DependencyProperty X2Property = System.Windows.DependencyProperty.Register(
            "X2",
            typeof(double),
            typeof(ArrowLine2),
            new System.Windows.PropertyMetadata(0.0, OnX2PropertyChanged));

        private static void OnX2PropertyChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            ArrowLine2 control = sender as ArrowLine2;

            if (control != null)
            {
                control.InvalidateVisual();
            }
        }

        public double Y2
        {
            get { return (double)this.GetValue(Y2Property); }
            set { this.SetValue(Y2Property, value); this.InvalidateVisual(); }
        }

        public static readonly DependencyProperty Y2Property = System.Windows.DependencyProperty.Register(
            "Y2",
            typeof(double),
            typeof(ArrowLine2),
            new System.Windows.PropertyMetadata(0.0, OnY2PropertyChanged));

        private static void OnY2PropertyChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            ArrowLine2 control = sender as ArrowLine2;

            if (control != null)
            {
                control.InvalidateVisual();
            }
        }

        public double ControlX
        {
            get { return (double)this.GetValue(ControlXProperty); }
            set { this.SetValue(ControlXProperty, value); this.InvalidateVisual(); }
        }

        public static readonly DependencyProperty ControlXProperty = System.Windows.DependencyProperty.Register(
            "ControlX",
            typeof(double),
            typeof(ArrowLine2),
            new System.Windows.PropertyMetadata(0.0, OnControlXPropertyChanged));

        private static void OnControlXPropertyChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            ArrowLine2 control = sender as ArrowLine2;

            if (control != null)
            {
                control.InvalidateVisual();
            }
        }

        public double ControlY
        {
            get { return (double)this.GetValue(ControlYProperty); }
            set { this.SetValue(ControlYProperty, value); this.InvalidateVisual(); }
        }

        public static readonly DependencyProperty ControlYProperty = System.Windows.DependencyProperty.Register(
            "ControlY",
            typeof(double),
            typeof(ArrowLine2),
            new System.Windows.PropertyMetadata(0.0, OnControlYPropertyChanged));

        private static void OnControlYPropertyChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            ArrowLine2 control = sender as ArrowLine2;

            if (control != null)
            {
                control.InvalidateVisual();
            }
        }

        public PolyLineSegment DrawArrow(Point a, Point b)
        {
            double HeadWidth = 0.004; // Ширина между ребрами стрелки
            double HeadHeight = 0.002; // Длина ребер стрелки

            double X1 = a.X;
            double Y1 = a.Y;

            double X2 = b.X;
            double Y2 = b.Y;

            double theta = Math.Atan2(Y1 - Y2, X1 - X2);
            double sint = Math.Sin(theta);
            double cost = Math.Cos(theta);

            Point pt3 = new Point(
                X2 + (HeadWidth * cost - HeadHeight * sint),
                Y2 + (HeadWidth * sint + HeadHeight * cost));

            Point pt4 = new Point(
                X2 + (HeadWidth * cost + HeadHeight * sint),
                Y2 - (HeadHeight * cost - HeadWidth * sint));

            PolyLineSegment arrow = new PolyLineSegment();
            arrow.Points.Add(b);
            arrow.Points.Add(pt3);
            arrow.Points.Add(b);
            arrow.Points.Add(pt4);
            arrow.Points.Add(b);

            return arrow;
        }


        protected override Geometry DefiningGeometry
        {
            get
            {
                GeometryGroup geometryGroup = new GeometryGroup();


                // координаты центра отрезка
                double X3 = 0;
                double Y3 = 0;
                if (ControlX == 0 && ControlY == 0)
                {
                    ControlX = (this.X1 + this.X2) / 2;
                    ControlY = (this.Y1 + this.Y2) / 2;
                    LineGeometry lineGeometry = new LineGeometry(new Point(this.X1, this.Y1), new Point(this.X2, this.Y2));
                    geometryGroup.Children.Add(lineGeometry);
                }
                else
                {
                    X3 = ControlX;
                    Y3 = ControlY;
                }


                // длина отрезка
                double d = Math.Sqrt(Math.Pow(this.X2 - this.X1, 2) + Math.Pow(this.Y2 - this.Y1, 2));

                // координаты вектора
                double X = this.X2 - this.X1;
                double Y = this.Y2 - this.Y1;

                // координаты точки, удалённой от центра к началу отрезка на 20px
                double X4 = X3 - (X / d) * 20;
                double Y4 = Y3 - (Y / d) * 20;

                // из уравнения прямой { (x - x1)/(x1 - x2) = (y - y1)/(y1 - y2) } получаем вектор перпендикуляра
                // (x - x1)/(x1 - x2) = (y - y1)/(y1 - y2) =>
                // (x - x1)*(y1 - y2) = (y - y1)*(x1 - x2) =>
                // (x - x1)*(y1 - y2) - (y - y1)*(x1 - x2) = 0 =>
                // полученные множители x и y => координаты вектора перпендикуляра
                double Xp = this.Y2 - this.Y1;
                double Yp = this.X1 - this.X2;

                // координаты перпендикуляров, удалённой от точки X4;Y4 на 10px в разные стороны
                double X5 = X4 + (Xp / d) * 10;
                double Y5 = Y4 + (Yp / d) * 10;
                double X6 = X4 - (Xp / d) * 10;
                double Y6 = Y4 - (Yp / d) * 10;


                LineGeometry arrowPart1Geometry = new LineGeometry(new Point(X3, Y3), new Point(X5, Y5));
                LineGeometry arrowPart2Geometry = new LineGeometry(new Point(X3, Y3), new Point(X6, Y6));

                LineGeometry arrowPart3Geometry = new LineGeometry(new Point(X3, Y3), new Point(X6 + 100, Y6 + 200));

                PathGeometry pathGeom = new PathGeometry();

                //Path p = new Path();

                PathFigure pathFigure = new PathFigure();

                pathFigure.StartPoint = new Point(this.X1, this.Y1);

                //LineSegment line = new LineSegment();
                //line.Point = new Point(X6 + 100, Y6 + 200);
                QuadraticBezierSegment BezierLine = new QuadraticBezierSegment();
                BezierLine.Point1 = new Point(ControlX, ControlY);
                BezierLine.Point2 = new Point(this.X2, this.Y2);

                PolyLineSegment arrow = new PolyLineSegment();
                arrow = DrawArrow(new Point(X3, Y3), new Point(this.X2, this.Y2));

                Polygon triangle = new Polygon();
                triangle.Points.Add(new Point(this.X1, this.Y1));
                triangle.Points.Add(new Point(X3, Y3));
                triangle.Points.Add(new Point(this.X2, this.Y2));



                pathFigure.Segments.Add(BezierLine);
                pathFigure.Segments.Add(arrow);

                pathGeom.Figures.Add(pathFigure);


                //geometryGroup.Children.Add(arrowPart1Geometry);
                // geometryGroup.Children.Add(arrowPart2Geometry);
                geometryGroup.Children.Add(pathGeom);


                return geometryGroup;
            }

        }
    }
}
