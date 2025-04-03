using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace MyPaint;

public static class SelectItemMethods
{
    public static void SelectThickness(object sender, RoutedEventArgs e, int index)
    {
        InformationForDraw.Thickness = DefaultTools.ThicknessesTools[index];
    }

    public static void SelectFillColor(object sender, RoutedEventArgs e, int index)
    {
        InformationForDraw.FillColor = DefaultTools.ColorsTools[index];
        SelectedTool.CurrSelectedFillColor = (sender as Border);
        SelectedTool.CurrSelectedFillColor.BorderBrush = Brushes.Maroon;
    }

    public static void SelectStrokeColor(object sender, RoutedEventArgs e, int index)
    {
        InformationForDraw.StrokeColor = DefaultTools.ColorsTools[index];
        SelectedTool.CurrSelectedStrokeColor = (sender as Border);
        SelectedTool. CurrSelectedStrokeColor.BorderBrush = Brushes.CornflowerBlue;
    }

    public static void SelectShape(object sender, RoutedEventArgs e, int index)
    {
        InformationForDraw.CurrShape = DefaultTools.ShapesTools[index];
        SelectedTool.CurrSelectedShape = (sender as Button);
        SelectedTool.CurrSelectedShape.Background = Brushes.CornflowerBlue;
    }


}