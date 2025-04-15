using System.Windows.Shapes;

namespace MyPaint;

public class Undo_Redo
{
    public Stack<Shape> ShapeUndoStack = new Stack<Shape>();
    public InformationForDraw informationForDraw { get; set; }
    
    
    public void Redo()
    {
        if (ShapeUndoStack.Count > 0)
            informationForDraw.CanvasForDrawing.Children.Add(ShapeUndoStack.Pop());
    }

    public void Undo()
    {
        if (informationForDraw.CanvasForDrawing.Children.Count > 0)
        {
            ShapeUndoStack.Push((Shape)informationForDraw.CanvasForDrawing.Children[informationForDraw.CanvasForDrawing.Children.Count - 1]);
            informationForDraw.CanvasForDrawing.Children.RemoveAt(informationForDraw.CanvasForDrawing.Children.Count - 1);
        }
    }
    
}