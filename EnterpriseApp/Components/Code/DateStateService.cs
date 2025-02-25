namespace EnterpriseApp.Components.Code;

public class DateStateService
{
    private DateTime? _selectedDate;
    private string? _selectedDropdownValue;
    private bool _isDarkMode;
    private bool _isDrawerOpen;

    public DateTime? SelectedDate
    {
        get => _selectedDate;
        set
        {
            if (_selectedDate != value)
            {
                _selectedDate = value;
                NotifyStateChanged();
            }
        }
    }

    public string? SelectedDropdownValue
    {
        get => _selectedDropdownValue;
        set
        {
            if (_selectedDropdownValue != value)
            {
                _selectedDropdownValue = value;
                NotifyStateChanged();
            }
        }
    }

    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            if (_isDarkMode != value)
            {
                _isDarkMode = value;
                //NotifyStateChanged();
            }
        }
    }

    public bool IsDrawerOpen
    {
        get => _isDrawerOpen;
        set
        {
            if (_isDrawerOpen != value)
            {
                _isDrawerOpen = value;
                //NotifyStateChanged();
            }
        }
    }

    public event Action? OnStateChanged;

    private void NotifyStateChanged() => OnStateChanged?.Invoke();
}
