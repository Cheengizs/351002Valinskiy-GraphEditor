using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace MyPaint;

public static class SelectedTool
{
    private static Border? currSelectedFillColor;
        
    public static  Border? CurrSelectedFillColor
    {
        get => currSelectedFillColor;
        set
        {
            if (currSelectedFillColor != null)
                currSelectedFillColor.BorderBrush = Brushes.Transparent;

            currSelectedFillColor = value;
        }
    }
    
    private static  Border? currSelectedStrokeColor = null;

    public static  Border? CurrSelectedStrokeColor
    {
        get => currSelectedStrokeColor;
        set
        {
            if (currSelectedStrokeColor != null)
                currSelectedStrokeColor.BorderBrush = Brushes.Transparent;
            currSelectedStrokeColor = value;
        }
    }

    private static  Button? currSelectedShape = null;

    public static  Button? CurrSelectedShape
    {
        get => currSelectedShape;
        set
        {
            if (currSelectedShape != null)
                currSelectedShape.Background = Brushes.Transparent;
            currSelectedShape = value;
        }
    }
    
    
    
    
    
}