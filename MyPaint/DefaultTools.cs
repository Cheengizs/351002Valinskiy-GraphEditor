using System.Windows.Media;

namespace MyPaint;

public static class DefaultTools
{
    public static List<Color> ColorsTools = new List<Color>();
    public static List<int> ThicknessesTools = new List<int>();

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
        ThicknessesTools.Add(2);
        ThicknessesTools.Add(4);
        ThicknessesTools.Add(6);
        ThicknessesTools.Add(8);
        ThicknessesTools.Add(10);
        ThicknessesTools.Sort();
    }
}