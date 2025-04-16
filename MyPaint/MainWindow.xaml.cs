using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Shapes;
using Microsoft.Win32;
using Newtonsoft.Json;

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
        
        public List<ShapeAllKinds> ShapesOnCanvas = new List<ShapeAllKinds>();
        public MainWindow()
        {
            InitializeComponent();

            informationForDraw = new InformationForDraw();
            
            InformationForDraw.CanvasForDrawing = canvasForDrawing;
            InformationForDraw.PopupThicknesses = popupThicknesses;
            InformationForDraw.UniColors = uniColors;
            InformationForDraw.UniShapes = uniShapes;
            InformationForDraw.ShapesOnCanvas = ShapesOnCanvas;
                
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

            menuOpenFile.Click += MenuOpenFile_OpenFile;
            menuSaveFile.Click += MenuSaveFile_SaveFile;
            menuSaveAs.Click += MenuSaveAs_SaveAsFile;
        }

        public void CanvasForDrawing_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Canvas).CaptureMouse();
            InformationForDraw.IsPressed = true;
            InformationForDraw.ShiftWasPressed = false;
            informationForDraw.xEnter = e.GetPosition(sender as Canvas).X;
            informationForDraw.yEnter = e.GetPosition(sender as Canvas).Y;
        }

        public void CanvasForDrawing_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (InformationForDraw.IsPressed)
            {
                if (sender is Canvas canvas)
                {
                    informationForDraw.xExit = e.GetPosition(canvas).X;
                    informationForDraw.yExit = e.GetPosition(canvas).Y;

                    if (!InformationForDraw.isDrawed)
                    {
                        InformationForDraw.isDrawed = true;
                        var shape = (ShapeAllKinds)Activator.CreateInstance(InformationForDraw.CurrShapeType);
                        shape.Draw(informationForDraw);
                        ShapesOnCanvas.Add(shape);
                        InformationForDraw.CanvasForDrawing.Children.Add(ShapesOnCanvas[^1].FigurePtr);
                    }

                    ShapesOnCanvas[^1].UpdateData(informationForDraw);
                }
            }
        }

        public void CanvasForDrawing_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            InformationForDraw.isDrawed = false;
            InformationForDraw.IsPressed = false;
            informationForDraw.xExit = e.GetPosition(sender as Canvas).X;
            informationForDraw.yExit = e.GetPosition(sender as Canvas).Y;

            InformationForDraw.ShiftWasPressed = false;

            undoRedo.ShapeUndoStack.Clear();
            (sender as Canvas).ReleaseMouseCapture();
        }

        private void MenuOpenFile_OpenFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog _ = new OpenFileDialog()
            {
                Filter = "graph edit files (*.gredit)|*.gredit"
            };

            if (_.ShowDialog() == true)
            {
                if (string.IsNullOrEmpty(_.FileName)) return;
                
                InformationForDraw.CanvasForDrawing?.Children?.Clear();
                string shapesInJson = File.ReadAllText(_.FileName);
                
                ShapesOnCanvas.Clear();
                ShapesOnCanvas = JsonConvert.DeserializeObject<List<ShapeAllKinds>>(shapesInJson, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                });
                InformationForDraw.ShapesOnCanvas = ShapesOnCanvas;
                
                Console.WriteLine(JsonConvert.SerializeObject(ShapesOnCanvas, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                }));

                foreach (var elem in ShapesOnCanvas)
                    elem.Draw(InformationForDraw.CanvasForDrawing);
                


            }
            
        }
        
        private void MenuSaveFile_SaveFile(object sender, RoutedEventArgs e)
        {
            var _ = new SaveFileDialog()
            {
                Title = "Сохранить как",
                FileName = "",
                DefaultExt = ".gredit",        // Можно указать любое расширение
                Filter = "Graph editor (*.gredit)|*.gredit"
            };

            if (_.ShowDialog() == true)
            {
                string shapesJson = JsonConvert.SerializeObject(ShapesOnCanvas, new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                    
                Console.WriteLine(shapesJson);
                File.WriteAllText(_.FileName, shapesJson);
            }
        }

        private void MenuSaveAs_SaveAsFile(object sender, RoutedEventArgs e)
        {
            
        }
        
    }
}