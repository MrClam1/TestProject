using System.Drawing;

namespace TestProject;

public class PaletteService
{
    private readonly Dictionary<string, Color> _palette = new();

    public void AddColor(string key, Color color)
    {
        _palette.Add(key, color);
    }

    public Color GetColor(string key)
    {
        if (_palette.TryGetValue(key, out var color))
        {
            return color;
        }
        
        return Color.Black;
    }
}