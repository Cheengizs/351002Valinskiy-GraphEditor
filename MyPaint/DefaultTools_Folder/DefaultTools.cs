using System.Windows.Media;
using System.Reflection;

namespace MyPaint;

public static class DefaultTools
{
    public static List<Color> ColorsTools = new List<Color>();
    public static List<int> ThicknessesTools = new List<int>();
    public static List<ShapeAllKinds> ShapesTools = new List<ShapeAllKinds>();

    static DefaultTools()
    {
        InitializeColors();
        InitializeThicknesses();
        InitializeShapes();
    }

    static void InitializeColors()
    {
        ColorsTools.Add(Colors.Black);
        ColorsTools.Add(Colors.White);
        ColorsTools.Add(Colors.Red);
        ColorsTools.Add(Colors.Orange);
        ColorsTools.Add(Colors.Yellow);
        ColorsTools.Add(Colors.Green);
        ColorsTools.Add(Colors.CornflowerBlue);
        ColorsTools.Add(Colors.Blue);
        ColorsTools.Add(Colors.Purple);
        ColorsTools.Add(Colors.Transparent);
        ColorsTools.Add(Colors.Gray);
    }

    static void InitializeThicknesses()
    {
        ThicknessesTools.Add(2);
        ThicknessesTools.Add(4);
        ThicknessesTools.Add(10);
        ThicknessesTools.Add(6);
        ThicknessesTools.Add(8);
        ThicknessesTools.Sort();
    }

    static void InitializeShapes()
    {
        ShapesTools = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(ShapeAllKinds).IsAssignableFrom(t))
            .Select(t => (ShapeAllKinds)Activator.CreateInstance(t))
            .ToList();
    }
}