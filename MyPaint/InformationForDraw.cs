using System.DirectoryServices.ActiveDirectory;
using System.Windows.Media;

namespace MyPaint;

public static class InformationForDraw
{
    public static double xEnter;
    public static double yEnter;
    public static double xExit;
    public static double yExit;

    public static Color FillColor = Colors.White;
    public static Color StrokeColor = Colors.Black;

    // public static int StrokeThickness = 2;
    // public static int LineThickness = 2;

    public static int Thickness = 1;
    
    public static bool isDrawed = false;
    public static bool IsPressed = false;
    public static bool ShiftWasPressed = false;
    
    public static int ColorNumber = 1;

    public static ShapeAllKinds CurrShape;

}