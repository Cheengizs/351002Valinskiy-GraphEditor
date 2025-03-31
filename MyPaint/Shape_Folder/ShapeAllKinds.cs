using System.Windows.Shapes;

namespace MyPaint;

public abstract class ShapeAllKinds
{
    public abstract Shape FigurePtr { get; set; }
    public abstract void UpdateData();
    public abstract void Draw();
}