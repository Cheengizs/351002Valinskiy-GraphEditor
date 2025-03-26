﻿using System.Windows.Media;

namespace MyPaint;

public static class InformationForDraw
{
    public static double xEnter;
    public static double yEnter;
    public static double xExit;
    public static double yExit;

    public static Color FillColor = Colors.White;
    public static Color StrokeColor = Colors.Black;

    public static int StrokeThicknes = 2;
    public static int LineThickness = 2;
    
    public static bool isDrawed = false;
    public static bool IsPressed = false;
    
    public static int ColorNumber = 1;
}