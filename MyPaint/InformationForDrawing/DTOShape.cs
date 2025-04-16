using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;

namespace MyPaint;

public class DTOShape
{
    public Type Type { get; set; }
    public Point[] Points { get; set; }
    public Color FillColor { get; set; }
    public Color StrokeColor { get; set; }
    public int StrokeThickness { get; set; }
}