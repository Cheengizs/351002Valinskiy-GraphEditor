using System.Windows.Media;

namespace MyPaint;

public static class DefaultTools
{
    public static List<Color> ColorsTools = new List<Color>();
    public static List<int> LineThicknesses = new List<int>();

    static DefaultTools()
    {
        InitializeColors();
        InitializeThicknesses();
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
    }

    static void InitializeThicknesses()
    {
        LineThicknesses.Add(2);
        LineThicknesses.Add(4);
        LineThicknesses.Add(6);
        LineThicknesses.Add(8);
        LineThicknesses.Add(10);
        LineThicknesses.Sort();
    }
}