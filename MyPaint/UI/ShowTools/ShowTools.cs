using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace MyPaint;

public static class ShowTools
{
    public static void AddColorsToTools()
    {
        for (int i = 0; i < DefaultTools.ColorsTools.Count(); i++)
            AddOneColorToTools(i);
    }

    private static void AddOneColorToTools(int indexOfColor)
    {
        Border _borderForStroke = new Border()
        {
            Background = Brushes.Transparent,
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(14),
        };

        Border _borderForFill = new Border()
        {
            Background = Brushes.Transparent,
            Margin = new Thickness(1),
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(12),
        };

        switch (indexOfColor)
        {
            case 0:
                InformationForDraw.StrokeColor = DefaultTools.ColorsTools[indexOfColor];
                _borderForStroke.BorderBrush = Brushes.CornflowerBlue;
                SelectedTool.CurrSelectedStrokeColor = _borderForStroke;
                break;
            case 1:
                InformationForDraw.FillColor = DefaultTools.ColorsTools[indexOfColor];
                _borderForFill.BorderBrush = Brushes.Maroon;
                SelectedTool.CurrSelectedFillColor = _borderForFill;
                break;
        }

        Border _border = new Border()
        {
            Background = Brushes.Transparent,
            Margin = new Thickness(1),
            BorderThickness = new Thickness(1),
            BorderBrush = new SolidColorBrush(Colors.Black),
            CornerRadius = new CornerRadius(10),
        };

        Ellipse _ellipse = new Ellipse()
        {
            Width = 10,
            Height = 10,
            Margin = new Thickness(1),
            Fill = new SolidColorBrush(DefaultTools.ColorsTools[indexOfColor]),
            IsHitTestVisible = true,
        };

        _border.Child = _ellipse;
        _borderForFill.Child = _border;
        _borderForStroke.Child = _borderForFill;

        _borderForFill.MouseLeftButtonDown += (s, e) => 
            { SelectItemMethods.SelectFillColor(s, e, indexOfColor); };

        _borderForStroke.MouseRightButtonDown += (s, e) => 
            { SelectItemMethods.SelectStrokeColor(s, e, indexOfColor); };
        
        InformationForDraw.UniColors.Children.Add(_borderForStroke);
    }

    public static void AddShapesToTools()
    {
        for (int i = 0; i < DefaultTools.ShapesTools.Count; i++)
            AddOneShapeToTools(i);
    }

    private static void AddOneShapeToTools(int index)
    {
        Button _btnShape = new Button()
        {
            Background = Brushes.Transparent,
            Content = DefaultTools.ShapesTools[index].GetType().Name,
        };

        if (index == 0)
        {
            _btnShape.Background = Brushes.CornflowerBlue;
            SelectedTool.CurrSelectedShape = _btnShape;
            InformationForDraw.CurrShape = DefaultTools.ShapesTools[index];
        }

        _btnShape.Click += (s, e) =>
        {
            SelectItemMethods.SelectShape(s, e, index);
        };

        InformationForDraw.UniShapes.Children.Add(_btnShape);
    }

    public static void AddThicknessesToTools()
    {
        StackPanel _ = new StackPanel();

        for (int i = 0; i < DefaultTools.ThicknessesTools.Count(); i++)
            _.Children.Add(AddOneThicknessToTools(i));

        InformationForDraw.PopupThicknesses.Child = _;
    }

    private static Button AddOneThicknessToTools(int index)
    {
        Button _btnThicknessAndText = new Button();

        _btnThicknessAndText.Click += (s, e) =>
            SelectItemMethods.SelectThickness(s, e, index);

        StackPanel _stckThicknessAndText = new StackPanel()
        {
            Height = 30,
            Orientation = Orientation.Horizontal,
        };

        Line _ThicknessShow = new Line()
        {
            StrokeThickness = DefaultTools.ThicknessesTools[index],
            Stroke = new SolidColorBrush(Colors.Black),
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Center,
            // Margin = new Thickness(10,0,0,0),
            X1 = 0,
            Y1 = 0,
            X2 = 100,
        };

        _stckThicknessAndText.Children.Add(_ThicknessShow);
        _btnThicknessAndText.Content = _stckThicknessAndText;

        return _btnThicknessAndText;
    }
}