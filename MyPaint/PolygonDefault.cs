using System.Windows.Media;
using System.Windows.Shapes;
using Color = System.Drawing.Color;

namespace MyPaint;

public class PolygonDefault : ShapeAllKinds
{
    
    // Продумать как отрисовывать многоугольник
    // 1) рисовать праввильный многоугольник 
    // 2) Если чел держит shift, то добавлять новую вершину 
    // ---- Чел нажал шифт --> добавление новой вершины
    
    public double[] points;

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
        // не забыть накинуть свойство, которое отменяет поверхностное нажатие
        // а то снова через костыли надо будет писать
    }
}