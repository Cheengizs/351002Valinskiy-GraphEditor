using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Security.Cryptography.X509Certificates;

namespace lab1proj
{
    public abstract class MyShape
    {
        public abstract uint LineThickness { get; set; }
        public abstract uint LineColor { get; set; }
        public abstract void drawShape(Canvas canvas);
    }

    public class MyLine : MyShape
    {
        public override uint LineThickness { get; set; }
        public override uint LineColor { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }


        public override void drawShape(Canvas canvas)
        {
            Line line = new Line();
            line.StrokeThickness = LineThickness;
            line.X1 = X1;
            line.Y1 = Y1;
            line.X2 = X2;
            line.Y2 = Y2;
            line.Stroke = new SolidColorBrush(Color.FromArgb(
                (byte)(LineColor & 0xFF000000 >> 24),
                (byte)(LineColor & 0x00FF0000 >> 16),
                (byte)(LineColor & 0x0000FF00 >> 8),
                (byte)(LineColor & 0x000000FF)));

            canvas.Children.Add(line);
        }
    }

    public class MyEllipse : MyShape
    {
        public override uint LineThickness { get; set; }
        public override uint LineColor { get; set; }
        public uint FillColor { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }

        public override void drawShape(Canvas canvas)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Stroke = new SolidColorBrush(Color.FromArgb(
                (byte)(LineColor & 0xFF000000 >> 24),
                (byte)(LineColor & 0x00FF0000 >> 16),
                (byte)(LineColor & 0x0000FF00 >> 8),
                (byte)(LineColor & 0x000000FF)));

            ellipse.Fill = new SolidColorBrush(Color.FromArgb(
                (byte)(FillColor & 0xFF000000 >> 24),
                (byte)(FillColor & 0x00FF0000 >> 16),
                (byte)(FillColor & 0x0000FF00 >> 8),
                (byte)(FillColor & 0x000000FF)));

            ellipse.Width = Width;
            ellipse.Height = Height;
            ellipse.StrokeThickness = LineThickness;
            ellipse.SetValue(Canvas.LeftProperty, (double)X1);
            ellipse.SetValue(Canvas.TopProperty, (double)Y1);

            canvas.Children.Add(ellipse);
        }
    }

    public class MyRectangle : MyShape
    {
        public override uint LineColor { get; set; }
        public override uint LineThickness { get; set; }

        public uint FillColor { get; set; }
        public uint Width { get; set; }
        public uint Height { get; set; }
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public override void drawShape(Canvas canvas)
        {


        }
    }

    public class MyPolyline : MyShape
    {
        public override uint LineThickness { get; set; }
        public override uint LineColor { get; set; }
        public List<int>? Vertices { get; set; }

        public MyPolyline()
        {
            Vertices = new List<int> { 30, 30, 50, 30, 50, 50, 30, 50, 30, 25 };
        }

        public override void drawShape(Canvas canvas)
        {
            Polyline polyline = new Polyline();
            polyline.Points = new PointCollection();
            for (int i = 0; i < Vertices.Count(); i += 2)
            {
                polyline.Points.Add(new Point(Vertices[i], Vertices[i + 1]));
            }

            polyline.StrokeThickness = LineThickness;
            polyline.Stroke = new SolidColorBrush(Color.FromArgb(
                (byte)(LineColor & 0xFF000000 >> 24),
                (byte)(LineColor & 0x00FF0000 >> 16),
                (byte)(LineColor & 0x0000FF00 >> 8),
                (byte)(LineColor & 0x000000FF)));

            canvas.Children.Add(polyline);
        }
    }

    public class MyPolygon : MyShape
    {
        public override uint LineThickness { get; set; }
        public override uint LineColor { get; set; }
        public uint FillColor { get; set; }
        public List<int>? Vertices { get; set; }

        public override void drawShape(Canvas canvas)
        {
            Polygon polygon = new Polygon();
            polygon.Points = new PointCollection();
            for (int i = 0; i < Vertices.Count(); i += 2)
            {
                polygon.Points.Add(new Point(Vertices[i], Vertices[i + 1]));
            }

            polygon.StrokeThickness = LineThickness;
            polygon.Stroke = new SolidColorBrush(Color.FromArgb(
                (byte)(LineColor & 0xFF000000 >> 24),
                (byte)(LineColor & 0x00FF0000 >> 16),
                (byte)(LineColor & 0x0000FF00 >> 8),
                (byte)(LineColor & 0x000000FF)));

            polygon.Fill = new SolidColorBrush(Color.FromArgb(
               (byte)(LineColor & 0xFF000000 >> 24),
               (byte)(LineColor & 0x00FF0000 >> 16),
               (byte)(LineColor & 0x0000FF00 >> 8),
               (byte)(LineColor & 0x000000FF)));

            canvas.Children.Add(polygon);


        }

        public MyPolygon()
        {
            Vertices = new List<int>() { 200, 100, 300, 300, 100, 100, 40, 90 };
        }
    }


}