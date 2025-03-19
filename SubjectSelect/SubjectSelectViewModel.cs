using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AOOP_Homework2;

public partial class SubjectSelectViewModel : ObservableObject
{
    [ObservableProperty]
    private Subject _subject;
    [ObservableProperty]
    public ObservableCollection<Subject> _availableSubjects;

    public SubjectSelectViewModel()
    {

    }
    public SubjectSelectViewModel(ref StudentPageViewModel studentPageViewModel)
    {
        _availableSubjects = studentPageViewModel.AvailableSubjects;
    }
}