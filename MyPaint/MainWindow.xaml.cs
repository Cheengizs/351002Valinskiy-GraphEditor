﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MyPaint
{
    public partial class MainWindow : Window
    {
        // public static List<ShapeAllKinds> ProbablyShapes = new List<ShapeAllKinds>();
        public static List<Shape> ShapesOnCanvas = new List<Shape>();
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

        private Button? currSelectedShape = null;

        private Button? CurrSelectedShape
        {
            get => currSelectedShape;
            set
            {
                if (currSelectedShape != null)
                    currSelectedShape.Background = Brushes.Transparent;
                currSelectedShape = value;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            AddColorsToTools();
            AddThicknessesToTools();
            AddShapesToTools();
        }

        private void AddShapesToTools()
        {
            for (int i = 0; i < DefaultTools.ShapesTools.Count; i++)
                AddOneShapeToTools(i);
        }

        private void AddOneShapeToTools(int index)
        {
            Button _btnShape = new Button()
            {
                Background = Brushes.Transparent,
                Content = DefaultTools.ShapesTools[index].GetType().Name,
            };

            if (index == 0)
            {
                CurrSelectedShape = _btnShape;
            }
            
            _btnShape.Click += (s, e) => { SelectShape(s, e, index); };
            
            uniShapes.Children.Add(_btnShape);
        }

        private void SelectShape(object sender, RoutedEventArgs e, int index)
        {
            InformationForDraw.CurrShape = DefaultTools.ShapesTools[index];
            CurrSelectedShape = (sender as Button);
            CurrSelectedShape.Background = Brushes.CornflowerBlue;
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

        private void AddThicknessesToTools()
        {
            StackPanel _ = new StackPanel();

            for (int i = 0; i < DefaultTools.ThicknessesTools.Count(); i++)
                _.Children.Add(AddOneThicknessToTools(i));

            popupThicknesses.Child = _;
        }

        private Button AddOneThicknessToTools(int index)
        {
            Button _btnThicknessAndText = new Button();

            _btnThicknessAndText.Click += (s, e) =>
                SelectThickness(s, e, index);

            StackPanel _stckThicknessAndText = new StackPanel()
            {
                Height = 30,
                Orientation = Orientation.Horizontal,
            };

            Line _ThicknessShow = new Line()
            {
                StrokeThickness = DefaultTools.ThicknessesTools[index],
                Stroke = new SolidColorBrush(Colors.Black),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                // Margin = new Thickness(10,0,0,0),
                X1 = 0,
                Y1 = 0,
                X2 = 100,
            };

            _stckThicknessAndText.Children.Add(_ThicknessShow);
            _btnThicknessAndText.Content = _stckThicknessAndText;

            return _btnThicknessAndText;
        }

        private void SelectThickness(object sender, RoutedEventArgs e, int index)
        {
            InformationForDraw.Thickness = DefaultTools.ThicknessesTools[index];
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
            CurrSelectedStrokeColor = (sender as Border);
            CurrSelectedStrokeColor.BorderBrush = Brushes.CornflowerBlue;
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
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    // тут можно сократить объем кода
                    // Canvas canvas = sender as Canvas;
                    if (sender is Canvas canvas)
                    {
                        Point position = e.GetPosition(canvas);
                        this.Title = $"{canvasForDrawing.Children.Count}";

                        InformationForDraw.xExit = position.X;
                        InformationForDraw.yExit = position.Y;

                        if (!InformationForDraw.isDrawed)
                        {
                            InformationForDraw.isDrawed = true;
                            InformationForDraw.CurrShape.Draw();
                            ShapesOnCanvas.Add(InformationForDraw.CurrShape.FigurePtr);
                            canvasForDrawing.Children.Add(ShapesOnCanvas.Last());
                        }

                        InformationForDraw.CurrShape.UpdateData();
                    }
                }
            }
        }

        private void CanvasForDrawing_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            InformationForDraw.isDrawed = false;
            InformationForDraw.IsPressed = false;
            InformationForDraw.xExit = e.GetPosition(sender as Canvas).X;
            InformationForDraw.yExit = e.GetPosition(sender as Canvas).Y;
            
            InformationForDraw.ShiftWasPressed = false;
            
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

        private void BtnThicknesses_OnClick(object sender, EventArgs e)
        {
            popupThicknesses.IsOpen = !popupThicknesses.IsOpen;
        }

        private void MainWindow_OnKeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.LeftShift || e.Key == Key.RightShift)
                InformationForDraw.ShiftWasPressed = true;
            
            
        }
    }
}