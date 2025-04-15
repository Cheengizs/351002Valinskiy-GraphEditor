using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MyPaint;

public class InformationForDraw
{
    public double xEnter;
    public double yEnter;
    public double xExit;
    public double yExit;

    public Color FillColor;
    public Color StrokeColor;
    
    public int Thickness = 1;
    
    public bool isDrawed = false;
    public bool IsPressed = false;
    public bool ShiftWasPressed = false;
    
    public int ColorNumber = 1;

    public ShapeAllKinds CurrShape = new EllipseDefault();

    public Canvas? CanvasForDrawing;

    public UniformGrid UniColors;
    public UniformGrid UniShapes;

    public Popup PopupThicknesses;
}