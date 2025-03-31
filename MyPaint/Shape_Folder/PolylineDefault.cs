using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace MyPaint;

public class PolylineDefault : ShapeAllKinds
{
    
    public double[] points;
    
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
        (FigurePtr as Polyline).Points[^1] = new Point(InformationForDraw.xExit, InformationForDraw.yExit);

        if (InformationForDraw.ShiftWasPressed)
        {
            (FigurePtr as Polyline).Points.Add(new Point(InformationForDraw.xExit, InformationForDraw.yExit));
            InformationForDraw.ShiftWasPressed = false;
        }

        LineColor = InformationForDraw.StrokeColor;
        LineThickness = InformationForDraw.Thickness;
        
    }

    public override void Draw()
    {
        FigurePtr = new Polyline()
        {
            IsHitTestVisible = false,
            Points = new PointCollection
            {
                new Point(InformationForDraw.xEnter, InformationForDraw.yEnter),
                new Point(InformationForDraw.xExit, InformationForDraw.yExit)
            },
        };
    }

}