using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AOOP_Homework2;

public partial class SubjectSelectViewModel : ObservableObject
{
    [ObservableProperty]
    private SubjectDisplay _subject;
    [ObservableProperty]
    private ObservableCollection<SubjectDisplay> _availableSubjects;

    public SubjectSelectViewModel()
    {

    }
    public SubjectSelectViewModel(ref StudentPageViewModel studentPageViewModel)
    {
        _availableSubjects = studentPageViewModel.AvailableSubects;

    }
}