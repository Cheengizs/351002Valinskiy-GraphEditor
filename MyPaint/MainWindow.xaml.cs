using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Reflection;
using System.Windows.Media;

namespace MyPaint
{
    public partial class MainWindow : Window
    {
        public static List<ShapeAllKinds> ProbablyShapes = new List<ShapeAllKinds>();
        public static List<Shape> ShapesOnCanvas = new List<Shape>();
        public static int currPointer = -1;
        public static Stack<Shape> ShapeUndoStack = new Stack<Shape>();

        private Border? currSelectedFillColor;

        private Border? CurrSelectedFillColor
        {
            get => currSelectedFillColor;
            set
            {
                if (currSelectedFillColor != null)
                    currSelectedFillColor.BorderBrush = Brushes.Transparent;

                currSelectedFillColor = value;
            }
        }

        private Border? currSelectedStrokeColor = null;

        private Border? CurrSelectedStrokeColor
        {
            get => currSelectedStrokeColor;
            set
            {
                if (currSelectedStrokeColor != null)
                    currSelectedStrokeColor.BorderBrush = Brushes.Transparent;
                currSelectedStrokeColor = value;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            ProbablyShapes.Add(new RectangleDefault() { });
            AddColorsToTools();
        }

        private void AddOneColorToTools(int indexOfColor)
        {
            Border _borderForStroke = new Border()
            {
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(14),
            };

            Border _borderForFill = new Border()
            {
                Background = Brushes.Transparent,
                Margin = new Thickness(1),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(12),
            };

            switch (indexOfColor)
            {
                case 0:
                    _borderForStroke.BorderBrush = Brushes.CornflowerBlue;
                    currSelectedStrokeColor = _borderForStroke;
                    break;
                case 1:
                    _borderForFill.BorderBrush = Brushes.Maroon;
                    currSelectedFillColor = _borderForFill;
                    break;
            }

            Border _border = new Border()
            {
                Background = Brushes.Transparent,
                Margin = new Thickness(1),
                BorderThickness = new Thickness(1),
                BorderBrush = new SolidColorBrush(Colors.Black),
                CornerRadius = new CornerRadius(10),
            };

            Ellipse _ellipse = new Ellipse()
            {
                Width = 10,
                Height = 10,
                Margin = new Thickness(1),
                Fill = new SolidColorBrush(DefaultTools.ColorsTools[indexOfColor]),
                IsHitTestVisible = true,
            };

            _border.Child = _ellipse;
            _borderForFill.Child = _border;
            _borderForStroke.Child = _borderForFill;

            _borderForFill.MouseLeftButtonDown += (s, e) => { SelectFillColor(s, e, indexOfColor); };

            _borderForStroke.MouseRightButtonDown += (s, e) => { SelectStrokeColor(s, e, indexOfColor); };
            uniColors.Children.Add(_borderForStroke);
        }

        private void AddColorsToTools()
        {
            for (int i = 0; i < DefaultTools.ColorsTools.Count() - 1; i++)
                AddOneColorToTools(i);
        }

        private void SelectFillColor(object sender, RoutedEventArgs e, int index)
        {
            InformationForDraw.FillColor = DefaultTools.ColorsTools[index];
            CurrSelectedFillColor = (sender as Border);
            CurrSelectedFillColor.BorderBrush = Brushes.Maroon;
        }

        private void SelectStrokeColor(object sender, RoutedEventArgs e, int index)
        {
            InformationForDraw.StrokeColor = DefaultTools.ColorsTools[index];
            // rectStrokeColor.Fill = new SolidColorBrush(InformationForDraw.StrokeColor);
            CurrSelectedStrokeColor = (sender as Border);
            CurrSelectedStrokeColor.BorderBrush = Brushes.CornflowerBlue;
        }


        private void CanvasForDrawing_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            (sender as Canvas).CaptureMouse();
            InformationForDraw.IsPressed = true;
            InformationForDraw.xEnter = e.GetPosition(sender as Canvas).X;
            InformationForDraw.yEnter = e.GetPosition(sender as Canvas).Y;
        }

        private void CanvasForDrawing_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (InformationForDraw.IsPressed)
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
                            ProbablyShapes[0].Draw();
                            ShapesOnCanvas.Add(ProbablyShapes[0].FigurePtr);
                            canvasForDrawing.Children.Add(ShapesOnCanvas.Last());
                            currPointer++;
                        }

                        ProbablyShapes[0].UpdateData();
                    }
                }
            }
        }

        private void CanvasForDrawing_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            InformationForDraw.xExit = e.GetPosition(sender as Canvas).X;
            InformationForDraw.yExit = e.GetPosition(sender as Canvas).Y;
            InformationForDraw.IsPressed = false;
            InformationForDraw.isDrawed = false;

            ShapeUndoStack.Clear();
            (sender as Canvas).ReleaseMouseCapture();
        }

        private void BtnUndo_OnClick(object sender, RoutedEventArgs e)
        {
            if (canvasForDrawing.Children.Count > 0)
            {
                ShapeUndoStack.Push((Shape)canvasForDrawing.Children[canvasForDrawing.Children.Count - 1]);
                canvasForDrawing.Children.RemoveAt(canvasForDrawing.Children.Count - 1);
            }
        }


        private void BtnRedo_OnClick(object sender, RoutedEventArgs e)
        {
            if (ShapeUndoStack.Count > 0)
                canvasForDrawing.Children.Add(ShapeUndoStack.Pop());
        }
    }
}