using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MyPaint;

public static class InformationForDraw
{
    public static double xEnter;
    public static double yEnter;
    public static double xExit;
    public static double yExit;

    public static Color FillColor;
    public static Color StrokeColor;
    
    public static int Thickness = 1;
    
    public static bool isDrawed = false;
    public static bool IsPressed = false;
    public static bool ShiftWasPressed = false;
    
    public static int ColorNumber = 1;

    public static ShapeAllKinds CurrShape = new EllipseDefault();

    public static Canvas? CanvasForDrawing;

    public static UniformGrid UniColors;
    public static UniformGrid UniShapes;

    public static Popup PopupThicknesses;
}