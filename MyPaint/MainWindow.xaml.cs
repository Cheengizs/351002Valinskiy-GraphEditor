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

namespace MyPaint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static class ShapesOnWindow
        {
            public static List<ShapeAllKinds> ProbablyShapes = new List<ShapeAllKinds>();
            public static List<Shape> ShapesOnCanvas = new List<Shape>();
            public static int currPointer = 0;
        }

        
        
        
        public MainWindow()
        {
            ShapesOnWindow.ProbablyShapes.Add(new RectangleDefault(){});
            InitializeComponent();
        }

        private void CanvasForDrawing_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Canvas).CaptureMouse();
            InformationForDraw.xEnter = e.GetPosition(sender as Canvas).X;
            InformationForDraw.yEnter = e.GetPosition(sender as Canvas).Y;
        }

        private void CanvasForDrawing_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Canvas canvas = sender as Canvas;
                if (canvas != null)
                {
                    // Point position = System.Windows.Forms.Cursor.Position;

                    Point position = e.GetPosition(canvas);
                    this.Title = $"{canvasForDrawing.Children.Count}";

                    InformationForDraw.xExit = position.X;
                    InformationForDraw.yExit = position.Y;

                    if (!InformationForDraw.isDrawed)
                    {
                        InformationForDraw.isDrawed = true;
                        ShapesOnWindow.ProbablyShapes[0].Draw();
                        ShapesOnWindow.ShapesOnCanvas.Add(ShapesOnWindow.ProbablyShapes[0].FigurePtr);
                        canvasForDrawing.Children.Add(ShapesOnWindow.ShapesOnCanvas.Last());
                    }
                    
                    ShapesOnWindow.ProbablyShapes[0].UpdateData();
                    
                    
                }
            }
        }

        private void CanvasForDrawing_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            InformationForDraw.xExit = e.GetPosition(sender as Canvas).X;
            InformationForDraw.yExit = e.GetPosition(sender as Canvas).Y;
            
            InformationForDraw.isDrawed = false;
            
            (sender as Canvas).ReleaseMouseCapture();

            // throw new NotImplementedException();
        }
    }
}