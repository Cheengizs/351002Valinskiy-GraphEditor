using System.Windows.Media;
using System.Windows.Shapes;
using Color = System.Drawing.Color;

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

    public int lineThickness;

    public int LineThickness
    {
        get { return lineThickness; }
        set { lineThickness = value; }
    }

    public Color lineColor;

    public Color LineColor
    {
        get { return lineColor; }
        set { lineColor = value; }
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
        // не забыть накинуть свойство, которое отменяет поверхностное нажатие
        // а то снова через костыли надо будет писать
    }
}