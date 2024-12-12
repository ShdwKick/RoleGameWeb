using Avalonia.Styling;

namespace RoleGameWeb;

public interface IApp
{
    public ThemeVariant CurrentTheme { get; set; }

    public void ChangeCurrentTheme(string theme);

}