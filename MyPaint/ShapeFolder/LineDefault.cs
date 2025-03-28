using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace MyPaint;

public class LineDefault : ShapeAllKinds
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
            
            // Canvas.SetLeft(FigurePtr, x2 > x1 ? x1 : x2);
            (FigurePtr as Line).X2 = x2 > x1 ? x2 : x1;
            
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
            (FigurePtr as Line).Y2 = y2 > y1 ? y2 : y1;
            // Canvas.SetTop(FigurePtr, y2 > y1 ? y1 : y2);
            // FigurePtr.Height = Math.Abs(y2 - y1);
        }
    }

    public int lineThickness;

    public int LineThickness
    {
        get { return lineThickness; }
        set
        {
            lineThickness = value;
            FigurePtr.StrokeThickness = value;
        }
    }

    public Color lineColor;

    public Color LineColor
    {
        get { return lineColor; }
        set
        {
            lineColor = value;
            FigurePtr.Stroke = new SolidColorBrush(value);
        }
    }

    public override Shape FigurePtr { get; set; }

    public override void UpdateData()
    {
        X1 = InformationForDraw.xEnter;
        Y1 = InformationForDraw.yEnter;
        X2 = InformationForDraw.xExit;
        Y2 = InformationForDraw.yExit;
    
        LineThickness = InformationForDraw.Thickness;
        LineColor = InformationForDraw.FillColor;
    }

    public override void Draw()
    {
        FigurePtr = new Line()
        {
            IsHitTestVisible = false,
        };
    }
}