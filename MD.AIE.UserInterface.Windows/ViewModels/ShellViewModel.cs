using Caliburn.Micro;

namespace MD.AIE.UserInterface.Windows.ViewModels;

public class ShellViewModel : Conductor<object>
{
    private MainWindowViewModel _mainWindowViewModel;
    
    public ShellViewModel(MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;
        
        // ReSharper disable once VirtualMemberCallInConstructor
        ActivateItemAsync(mainWindowViewModel);
    }
}