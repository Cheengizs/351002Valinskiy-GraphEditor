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

    public override void UpdateData(InformationForDraw informationForDraw)
    {
        if(informationForDraw.isDrawed)
        
        (FigurePtr as Polyline).Points[^1] = new Point(informationForDraw.xExit, informationForDraw.yExit);

        if (informationForDraw.ShiftWasPressed)
        {
            (FigurePtr as Polyline).Points.Add(new Point(informationForDraw.xExit, informationForDraw.yExit));
            informationForDraw.ShiftWasPressed = false;
        }

        LineColor = informationForDraw.StrokeColor;
        LineThickness = informationForDraw.Thickness;
        
    }

    public override void Draw(InformationForDraw informationForDraw)
    {
        FigurePtr = new Polyline()
        {
            IsHitTestVisible = false,
            Points = new PointCollection
            {
                new Point(informationForDraw.xEnter, informationForDraw.yEnter),
                new Point(informationForDraw.xExit, informationForDraw.yExit)
            },
        };
    }

}