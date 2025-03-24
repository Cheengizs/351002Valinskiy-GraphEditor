using System.Windows.Media;
using System.Windows.Shapes;
using Color = System.Drawing.Color;


namespace MyPaint;

public class PolylineDefault : ShapeAllKinds
{
    
    public double[] points;
    
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