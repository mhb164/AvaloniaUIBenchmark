using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaUIBenchmark.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public HeaderBarViewModel HeaderBar { get; } = new HeaderBarViewModel();

    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";
}
