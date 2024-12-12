using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;
using AvaloniaControls;
using RoleGameWeb;

namespace CustomControl;

public partial class CustomTextBox : UserControl, INotifyPropertyChanged
{
    private bool _hasError;

    public IApp App { get; }
    private bool _isNeedShowPassword = true;
    private IBrush _brush = Brushes.Black;

    public event PropertyChangedEventHandler? PropertyChanged;

    public static readonly StyledProperty<string> LabelProperty = AvaloniaProperty.Register<CustomTextBox, string>(nameof(Label));
    public static readonly StyledProperty<string> TextProperty =
        AvaloniaProperty.Register<CustomTextBox, string>(nameof(Text), "", defaultBindingMode: BindingMode.TwoWay);
    public static readonly StyledProperty<string> ErrorTextProperty = AvaloniaProperty.Register<CustomTextBox, string>(nameof(ErrorText));
    public static readonly StyledProperty<string> PlaceholderTextProperty = AvaloniaProperty.Register<CustomTextBox, string>(nameof(PlaceholderText));
    public static readonly StyledProperty<int> LabelFontSizeProperty = AvaloniaProperty.Register<CustomTextBox, int>(nameof(LabelFontSize), 10);
    public new static readonly StyledProperty<int> FontSizeProperty = AvaloniaProperty.Register<CustomTextBox, int>(nameof(FontSize), 14);
    public static readonly StyledProperty<bool> IsPasswordProperty = AvaloniaProperty.Register<CustomTextBox, bool>(nameof(IsPassword), false);
    public static readonly StyledProperty<bool> IsEmailProperty = AvaloniaProperty.Register<CustomTextBox, bool>(nameof(IsPassword), false);
    public static readonly StyledProperty<bool> IsRequiredProperty = AvaloniaProperty.Register<CustomTextBox, bool>(nameof(IsRequired), false);


    public string Label
    {
        get => GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }
    public string Text
    {
        get => GetValue(TextProperty);
        set
        {
            SetValue(TextProperty, value);
            OnPropertyChanged(nameof(Text));
        }
    }
    public string ErrorText
    {
        get => GetValue(ErrorTextProperty);
        set => SetValue(ErrorTextProperty, value);
    }
    public string PlaceholderText
    {
        get => GetValue(PlaceholderTextProperty);
        set => SetValue(PlaceholderTextProperty, value);
    }

    public int LabelFontSize
    {
        get => GetValue(LabelFontSizeProperty);
        set => SetValue(LabelFontSizeProperty, value);
    }
    public new int FontSize
    {
        get => GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }
    public bool IsPassword
    {
        get => GetValue(IsPasswordProperty);
        set => SetValue(IsPasswordProperty, value);
    }
    public bool IsRequired
    {
        get => GetValue(IsRequiredProperty);
        set => SetValue(IsRequiredProperty, value);
    }
    public bool IsEmail
    {
        get => GetValue(IsEmailProperty);
        set => SetValue(IsEmailProperty, value);
    }
    public bool IsNeedShowPassword
    {
        get => _isNeedShowPassword;
        set
        {
            if (value != _isNeedShowPassword)
            {
                _isNeedShowPassword = value;
                OnPropertyChanged(nameof(IsNeedShowPassword));
            }
        }
    }
    public bool HasError
    {
        get => _hasError;
        set
        {
            if (value != _hasError)
            {
                _hasError = value;
                OnPropertyChanged(nameof(HasError));
            }
        }
    }


    public CustomTextBox()
    {
        DataContext = this;
        App = Application.Current as IApp;
        InitializeComponent();
    }

    private void PasswordToggleButton_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is ToggleButton tg)
            IsNeedShowPassword = (bool)tg.IsChecked;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void OnInitialized(object? sender, EventArgs e)
    {
        if (IsPassword)
            IsNeedShowPassword = false;
    }

    private void TextBox_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        HasError = false;
        if (Text == null)
            return;

        if (IsRequired)
        {
            HasError = Text.Length == 0;
            ErrorText = "Поле не может быть пустым";
        }
        if (IsPassword)
        {
            HasError = Text.Length <= 10;
            ErrorText = "Пароль должен быть длинее 10 символов";
        }
        if (IsEmail)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(emailPattern);
            if (!regex.IsMatch(Text))
            {
                HasError = true;
                ErrorText = "Не верная почта";
            }
        }
    }
}