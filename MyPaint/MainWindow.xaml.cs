using System.Windows;
using System.Windows.Input;

namespace MyPaint
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InformationForDraw.CanvasForDrawing = canvasForDrawing;
            {
                InformationForDraw.CanvasForDrawing.MouseDown += DrawingOnCanvas.CanvasForDrawing_OnMouseDown;
                InformationForDraw.CanvasForDrawing.MouseUp += DrawingOnCanvas.CanvasForDrawing_OnMouseUp;
                InformationForDraw.CanvasForDrawing.MouseMove += DrawingOnCanvas.CanvasForDrawing_OnMouseMove;
            }

            
            
            InformationForDraw.PopupThicknesses = popupThicknesses;
            InformationForDraw.UniColors = uniColors;
            InformationForDraw.UniShapes = uniShapes;

            ShowTools.AddColorsToTools();
            ShowTools.AddThicknessesToTools();
            ShowTools.AddShapesToTools();
        }

        private void UndoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Undo_Redo.Undo();
        }

        private void RedoCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Undo_Redo.Redo();
        }
        
    }
}