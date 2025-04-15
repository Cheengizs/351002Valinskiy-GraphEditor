using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace MyPaint;

public class ShowTools
{
    public InformationForDraw informationForDraw;
    public SelectItemMethods selectItemMethods;
    public SelectedTool selectedTool;
    
    public void AddColorsToTools()
    {
        for (int i = 0; i < DefaultTools.ColorsTools.Count(); i++)
            AddOneColorToTools(i);
    }

    private void AddOneColorToTools(int indexOfColor)
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
                informationForDraw.StrokeColor = DefaultTools.ColorsTools[indexOfColor];
                _borderForStroke.BorderBrush = Brushes.CornflowerBlue;
                selectedTool.CurrSelectedStrokeColor = _borderForStroke;
                break;
            case 1:
                informationForDraw.FillColor = DefaultTools.ColorsTools[indexOfColor];
                _borderForFill.BorderBrush = Brushes.Maroon;
                selectedTool.CurrSelectedFillColor = _borderForFill;
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
            { selectItemMethods.SelectFillColor(s, e, indexOfColor); };

        _borderForStroke.MouseRightButtonDown += (s, e) => 
            { selectItemMethods.SelectStrokeColor(s, e, indexOfColor); };
        
        informationForDraw.UniColors.Children.Add(_borderForStroke);
    }

    public void AddShapesToTools()
    {
        for (int i = 0; i < DefaultTools.ShapesTools.Count; i++)
            AddOneShapeToTools(i);
    }

    private void AddOneShapeToTools(int index)
    {
        Button _btnShape = new Button()
        {
            Background = Brushes.Transparent,
            Content = DefaultTools.ShapesTools[index].GetType().Name,
        };

        if (index == 0)
        {
            _btnShape.Background = Brushes.CornflowerBlue;
            selectedTool.CurrSelectedShape = _btnShape;
            informationForDraw.CurrShape = DefaultTools.ShapesTools[index];
        }

        _btnShape.Click += (s, e) =>
        {
            selectItemMethods.SelectShape(s, e, index);
        };

        informationForDraw.UniShapes.Children.Add(_btnShape);
    }

    public void AddThicknessesToTools()
    {
        StackPanel _ = new StackPanel();

        for (int i = 0; i < DefaultTools.ThicknessesTools.Count(); i++)
            _.Children.Add(AddOneThicknessToTools(i));

        informationForDraw.PopupThicknesses.Child = _;
    }

    private Button AddOneThicknessToTools(int index)
    {
        Button _btnThicknessAndText = new Button();

        _btnThicknessAndText.Click += (s, e) =>
            selectItemMethods.SelectThickness(s, e, index);

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