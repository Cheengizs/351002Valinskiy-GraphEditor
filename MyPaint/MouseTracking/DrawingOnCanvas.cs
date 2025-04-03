using System.Windows.Controls;
using System.Windows.Input;

namespace MyPaint;

public static class DrawingOnCanvas
{
    public static void CanvasForDrawing_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        (sender as Canvas).CaptureMouse();
        InformationForDraw.IsPressed = true;
        InformationForDraw.ShiftWasPressed = false;
        InformationForDraw.xEnter = e.GetPosition(sender as Canvas).X;
        InformationForDraw.yEnter = e.GetPosition(sender as Canvas).Y;
    }

    public static void CanvasForDrawing_OnMouseMove(object sender, MouseEventArgs e)
    {
        if (InformationForDraw.IsPressed)
        {
            if (sender is Canvas canvas)
            {
                InformationForDraw.xExit = e.GetPosition(canvas).X;
                InformationForDraw.yExit = e.GetPosition(canvas).Y;

                if (!InformationForDraw.isDrawed)
                {
                    InformationForDraw.isDrawed = true;
                    InformationForDraw.CurrShape.Draw();
                    InformationForDraw.CanvasForDrawing.Children.Add(InformationForDraw.CurrShape.FigurePtr);
                }

                InformationForDraw.CurrShape.UpdateData();
            }
            // }
        }
    }

    public static void CanvasForDrawing_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        InformationForDraw.isDrawed = false;
        InformationForDraw.IsPressed = false;
        InformationForDraw.xExit = e.GetPosition(sender as Canvas).X;
        InformationForDraw.yExit = e.GetPosition(sender as Canvas).Y;

        InformationForDraw.ShiftWasPressed = false;

        Undo_Redo.ShapeUndoStack.Clear();
        (sender as Canvas).ReleaseMouseCapture();
    }
}