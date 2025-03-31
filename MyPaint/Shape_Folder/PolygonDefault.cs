using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Media;

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
        set
        {
            strokeThickness = value;
            FigurePtr.StrokeThickness = value;
        }
    }

    public Color fillColor, strokeColor;

    public Color FillColor
    {
        get { return fillColor; }
        set
        {
            fillColor = value;
            FigurePtr.Fill = new SolidColorBrush(value);
        }
    }

    public Color StrokeColor
    {
        get { return strokeColor; }
        set
        {
            strokeColor = value;
            FigurePtr.Stroke = new SolidColorBrush(value);
        }
    }


    public override Shape FigurePtr { get; set; }

    public override void UpdateData()
    {
        (FigurePtr as Polygon).Points[^1] = new Point(InformationForDraw.xExit, InformationForDraw.yExit);

        if (InformationForDraw.ShiftWasPressed)
        {
            (FigurePtr as Polygon).Points.Add(new Point(InformationForDraw.xExit, InformationForDraw.yExit));
            InformationForDraw.ShiftWasPressed = false;
        }

        FillColor = InformationForDraw.FillColor;
        StrokeColor = InformationForDraw.StrokeColor;
        StrokeThickness = InformationForDraw.Thickness;
    }

    public override void Draw()
    {
        FigurePtr = new Polygon()
        {
            IsHitTestVisible = false,
            Points = new PointCollection
            {
                new Point(InformationForDraw.xEnter, InformationForDraw.yEnter),
                new Point(InformationForDraw.xExit, InformationForDraw.yExit)
            },
        };


        // функцию вывода EllipseGeometry
        // не забыть накинуть свойство, которое отменяет поверхностное нажатие
        // а то снова через костыли надо будет писать
    }
}