using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;

namespace AvaloniaUIBenchmark.ViewModels;

public partial class HeaderBarViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _title = $"Avalonia UI Benchmark {App.Version}";

    [RelayCommand]
    private void SwitchTheme()
    {
        App.SwitchTheme();
    }
}
