using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab1proj
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public bool IsPressed { get; set; } = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MyEllipse ellipse = new MyEllipse();
            //ellipse.X1 = 00;
            //ellipse.Y1 = 100;
            //ellipse.Width = 150;
            //ellipse.Height = 150;
            //ellipse.LineThickness = 10;
            //ellipse.FillColor = 0xFFAAEEBB;
            //ellipse.LineColor = 0x00BB6969;
            //ellipse.drawShape(canvasForDraw);

            //MyPolyline polyline = new MyPolyline();
            //polyline.LineThickness = 1;
            //polyline.LineColor = 0xAAAAAAA;
            //polyline.drawShape(canvasForDraw);

            MyPolygon myPolygon = new MyPolygon();
            myPolygon.LineThickness = 1;
            myPolygon.LineColor = 0xBBCCBBCC;
            myPolygon.FillColor = 0xBBCCBBCC;

            myPolygon.drawShape(canvasForDraw);

        }

        private void btnEllipse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void onMouseDownDraw(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Point point = e.GetPosition(canvasForDraw);
            X1 = (int)point.X;
            Y1 = (int)point.Y;
            IsPressed = true;
            canvasForDraw.Children.Add(new Ellipse());
        }

        private void onMouseMoveDraw(object sender, MouseEventArgs e)
        {

            MyEllipse myEllipse = new MyEllipse();
            myEllipse.LineThickness = 1;
            myEllipse.FillColor = 0xff665566;


            if (IsPressed)
            {
                canvasForDraw.Children.Remove(canvasForDraw.Children[canvasForDraw.Children.Count - 1]);
                System.Windows.Point p = e.GetPosition(canvasForDraw);
                X2 = (int)p.X;
                Y2 = (int)p.Y;

                myEllipse.X1 = (X1 > X2 ? X2 : X1);
                myEllipse.Y1 = (Y1 > Y2 ? Y2 : Y1);

                myEllipse.Width = (uint)Math.Abs(X2 - X1);
                myEllipse.Height = (uint)Math.Abs(Y2 - Y1);
                myEllipse.drawShape(canvasForDraw);

            }
        }

        private void onMouseUpDraw(object sender, MouseButtonEventArgs e)
        {
            IsPressed = false;

            canvasForDraw.Children.Remove(canvasForDraw.Children[canvasForDraw.Children.Count - 1]);
            MyEllipse myEllipse = new MyEllipse();
            myEllipse.LineThickness = 1;
            myEllipse.FillColor = 0xff99bbaa;
            myEllipse.X1 = (X1 > X2 ? X2 : X1);
            myEllipse.Y1 = (Y1 > Y2 ? Y2 : Y1);
            myEllipse.Width = (uint)Math.Abs(X2 - X1);
            myEllipse.Height = (uint)Math.Abs(Y2 - Y1);
            myEllipse.drawShape(canvasForDraw);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            canvasForDraw.Children.Remove(canvasForDraw.Children[canvasForDraw.Children.Count - 1]);
        }

    }
}