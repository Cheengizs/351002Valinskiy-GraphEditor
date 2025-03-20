using System.Drawing;

namespace MyPaint;

public static class InformationForDraw
{
    // т.к. значения могут быть отрицательными, то использовать 
    // формулу нахождения расстояния между 2 точками
    // |b| > |a| ? b - a : a - b
    
    public static double xEnter;
    public static double yEnter;
    public static double xExit;
    public static double yExit;

    public static Color FillColor;
    public static Color StrokeColor;

    public static int StrokeThicknes;
    public static int LineThickness;
    
}