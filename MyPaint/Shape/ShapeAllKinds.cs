using System.Windows.Shapes;

namespace MyPaint;

public abstract class ShapeAllKinds
{
    public abstract Shape FigurePtr { get; set; }
    public abstract void UpdateData(InformationForDraw informationForDraw);
    public abstract void Draw(InformationForDraw informationForDraw);
    
}