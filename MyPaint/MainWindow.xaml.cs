using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace MyPaint
{
    public partial class MainWindow : Window
    {
        public static List<Shape> ShapesOnCanvas = new List<Shape>();
        
        public MainWindow()
        {
            InitializeComponent();
            InformationForDraw.CanvasForDrawing = canvasForDrawing;
            InformationForDraw.PopupThicknesses = popupThicknesses;
            InformationForDraw.UniColors = uniColors;
            ShowTools.AddColorsToTools();
            ShowTools.AddThicknessesToTools();
            ShowTools.AddShapesToTools();
        }
        
        
        
        
        private void CanvasForDrawing_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Canvas).CaptureMouse();
            InformationForDraw.IsPressed = true;
            InformationForDraw.ShiftWasPressed = false;
            InformationForDraw.xEnter = e.GetPosition(sender as Canvas).X;
            InformationForDraw.yEnter = e.GetPosition(sender as Canvas).Y;
        }

        private void CanvasForDrawing_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (InformationForDraw.IsPressed)
            {
                // if (e.LeftButton == MouseButtonState.Pressed)
                // {
                // тут можно сократить объем кода
                // Canvas canvas = sender as Canvas;
                if (sender is Canvas canvas)
                {
                    this.Title = $"{canvasForDrawing.Children.Count}";

                    InformationForDraw.xExit = e.GetPosition(canvas).X;
                    InformationForDraw.yExit = e.GetPosition(canvas).Y;

                    if (!InformationForDraw.isDrawed)
                    {
                        InformationForDraw.isDrawed = true;
                        InformationForDraw.CurrShape.Draw();
                        ShapesOnCanvas.Add(InformationForDraw.CurrShape.FigurePtr);
                        canvasForDrawing.Children.Add(ShapesOnCanvas.Last());
                    }

                    InformationForDraw.CurrShape.UpdateData();
                }
                // }
            }
        }

        private void CanvasForDrawing_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            InformationForDraw.isDrawed = false;
            InformationForDraw.IsPressed = false;
            InformationForDraw.xExit = e.GetPosition(sender as Canvas).X;
            InformationForDraw.yExit = e.GetPosition(sender as Canvas).Y;

            InformationForDraw.ShiftWasPressed = false;

            Undo_Redo.ShapeUndoStack.Clear();
            (sender as Canvas).ReleaseMouseCapture();
        }

        private void BtnUndo_OnClick(object sender, RoutedEventArgs e)
        {
            Undo_Redo.Undo();
        }

        private void BtnRedo_OnClick(object sender, RoutedEventArgs e)
        {
            Undo_Redo.Redo();
        }

        private void BtnThicknesses_OnClick(object sender, EventArgs e)
        {
            popupThicknesses.IsOpen = !popupThicknesses.IsOpen;
        }

        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
                InformationForDraw.ShiftWasPressed = true;
        }
    }
}