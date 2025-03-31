using System.Windows.Media;
using System.Windows.Shapes;


namespace MyPaint;


public static class Undo_Redo
{
    public static Stack<Shape> ShapeUndoStack = new Stack<Shape>();

    public static void Redo()
    {
        if (Undo_Redo.ShapeUndoStack.Count > 0)
            InformationForDraw.CanvasForDrawing.Children.Add(Undo_Redo.ShapeUndoStack.Pop());
    }

    public static void Undo()
    {
        if (InformationForDraw.CanvasForDrawing.Children.Count > 0)
        {
            Undo_Redo.ShapeUndoStack.Push((Shape)InformationForDraw.CanvasForDrawing.Children[InformationForDraw.CanvasForDrawing.Children.Count - 1]);
            InformationForDraw.CanvasForDrawing.Children.RemoveAt(InformationForDraw.CanvasForDrawing.Children.Count - 1);
        }
    }
    
}