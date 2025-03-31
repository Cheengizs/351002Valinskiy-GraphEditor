﻿using System.Windows;
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