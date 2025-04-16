using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace MyPaint
{
    public partial class MainWindow : Window
    {
        public InformationForDraw informationForDraw;
        public ShowTools showTools;
        public Undo_Redo undoRedo;
        public SelectedTool selectedTool;
        public SelectItemMethods selectItemMethods;
        public DefaultTools defaultTools;
        public MainWindow()
        {
            InitializeComponent();

            informationForDraw = new InformationForDraw()
            {
                CanvasForDrawing = canvasForDrawing,
                PopupThicknesses = popupThicknesses,
                UniColors = uniColors,
                UniShapes = uniShapes
            };
            
            defaultTools = new DefaultTools();
            
            selectedTool = new SelectedTool();

            selectItemMethods = new SelectItemMethods()
            {
                informationForDraw = informationForDraw,
                selectedTool = selectedTool,
                defaultTools = defaultTools
            };

            undoRedo = new Undo_Redo()
            {
                informationForDraw = this.informationForDraw
            };

            showTools = new ShowTools()
            {
                informationForDraw = this.informationForDraw,
                selectItemMethods = selectItemMethods,
                selectedTool = selectedTool,
                defaultTools = defaultTools
            };

            showTools.AddColorsToTools();
            showTools.AddThicknessesToTools();
            showTools.AddShapesToTools();

            canvasForDrawing.MouseDown += CanvasForDrawing_OnMouseDown;
            canvasForDrawing.MouseMove += CanvasForDrawing_OnMouseMove;
            canvasForDrawing.MouseUp += CanvasForDrawing_OnMouseUp;
        }

        public void CanvasForDrawing_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Canvas).CaptureMouse();
            informationForDraw.IsPressed = true;
            informationForDraw.ShiftWasPressed = false;
            informationForDraw.xEnter = e.GetPosition(sender as Canvas).X;
            informationForDraw.yEnter = e.GetPosition(sender as Canvas).Y;
        }

        public void CanvasForDrawing_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (informationForDraw.IsPressed)
            {
                if (sender is Canvas canvas)
                {
                    informationForDraw.xExit = e.GetPosition(canvas).X;
                    informationForDraw.yExit = e.GetPosition(canvas).Y;

                    if (!informationForDraw.isDrawed)
                    {
                        informationForDraw.isDrawed = true;
                        informationForDraw.CurrShape.Draw(informationForDraw);
                        informationForDraw.CanvasForDrawing.Children.Add(informationForDraw.CurrShape.FigurePtr);
                    }

                    informationForDraw.CurrShape.UpdateData(informationForDraw);
                }
            }
        }

        public void CanvasForDrawing_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            informationForDraw.isDrawed = false;
            informationForDraw.IsPressed = false;
            informationForDraw.xExit = e.GetPosition(sender as Canvas).X;
            informationForDraw.yExit = e.GetPosition(sender as Canvas).Y;

            informationForDraw.ShiftWasPressed = false;

            undoRedo.ShapeUndoStack.Clear();
            (sender as Canvas).ReleaseMouseCapture();
        }
    }
}