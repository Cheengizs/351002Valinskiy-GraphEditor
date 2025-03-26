using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MyPaint;

public class RectangleDefault : ShapeAllKinds
{
    public double x1, y1, x2, y2;

    public double X1
    {
        get { return x1; }
        set { x1 = value; }
    }

    public double X2
    {
        get { return x2; }
        set
        {
            x2 = value;
            Canvas.SetLeft(FigurePtr, x2 > x1 ? x1 : x2);
            FigurePtr.Width = Math.Abs(x2 - x1);
        }
    }

    public double Y1
    {
        get { return y1; }
        set { y1 = value; }
    }

    public double Y2
    {
        get { return y2; }
        set
        {
            y2 = value;
            Canvas.SetTop(FigurePtr, y2 > y1 ? y1 : y2);
            FigurePtr.Height = Math.Abs(y2 - y1);
        }
    }

    public int strokeThickness;

    public int StrokeThickness
    {
        get { return strokeThickness; }
        set
        {
            // if (value != strokeThickness)
            // {
                strokeThickness = value;
                FigurePtr.StrokeThickness = value;
            // }
        }
    }

    public Color fillColor, strokeColor;

    public Color FillColor
    {
        get { return fillColor; }
        set
        {
            // if (value != fillColor)
            // {
                fillColor = value;
                FigurePtr.Fill = new SolidColorBrush(value);
            // }
        }
    }

    public Color StrokeColor
    {
        get { return strokeColor; }
        set
        {
            // if (value != strokeColor)
            // {
                strokeColor = value;
                FigurePtr.Stroke = new SolidColorBrush(value);
            // }
        }
    }


    public override Shape FigurePtr { get; set; }

    public override void UpdateData()
    {
        X1 = InformationForDraw.xEnter;
        Y1 = InformationForDraw.yEnter;
        X2 = InformationForDraw.xExit;
        Y2 = InformationForDraw.yExit;

        StrokeColor = InformationForDraw.StrokeColor;
        FillColor = InformationForDraw.FillColor;
        StrokeThickness = InformationForDraw.StrokeThicknes;
    }

    public override void Draw()
    {
        FigurePtr = new Rectangle()
        {
            IsHitTestVisible = false,
        };
    }
}