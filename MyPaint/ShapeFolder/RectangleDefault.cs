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
        set { x2 = value; }
    }

    public double Y1
    {
        get { return y1; }
        set { y1 = value; }
    }

    public double Y2
    {
        get { return y2; }
        set { y2 = value; }
    }

    public int strokeThickness;

    public int StrokeThickness
    {
        get { return strokeThickness; }
        set { strokeThickness = value; }
    }

    public Color fillColor, strokeColor;

    public Color FillColor
    {
        get { return fillColor; }
        set { fillColor = value; }
    }

    public Color StrokeColor
    {
        get { return strokeColor; }
        set { strokeColor = value; }
    }


    public override Path FigurePtr { get; set; }

    public override void UpdateData()
    {
        //обновления данных, и из-за наличия get{}; set{};
        // фигура будет сама перерисовываться
    }

    public override void Draw()
    {
        FigurePtr = new Path();
        // функцию вывода EllipseGeometry
    }
}