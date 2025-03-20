using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AOOP_Homework2;

public partial class SubjectSelectViewModel : ObservableObject
{
    [ObservableProperty]
    private SubjectDisplay _subject = new();
    [ObservableProperty]
    private ObservableCollection<SubjectDisplay> _availableSubjects = new();
    public SubjectSelectViewModel()
    {

    }
    public SubjectSelectViewModel(ref StudentPageViewModel studentPageViewModel)
    {
        _availableSubjects = studentPageViewModel.AvailableSubects;

    }
}