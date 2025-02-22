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
    }
}