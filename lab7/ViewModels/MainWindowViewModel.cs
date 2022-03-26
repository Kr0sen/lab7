using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using ReactiveUI;
using System.Text;
using lab7.Models;

namespace lab7.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public List<Student> Students { get; set; }
        public MainWindowViewModel()
        {
            Students = MakeStudents();
            Items = new ObservableCollection<Student>(Students);
            Items.CollectionChanged += ContentCollectionChanged;
        }
        ObservableCollection<Student> items;
        public ObservableCollection<Student> Items
        {
            get
            {
                return items;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref items, value);
            }
        }
        private List<Student> MakeStudents()
        {
            return new List<Student>
            {
                new Student("a0", "b0", "c0", new string[5] {"0","0","0","0","0"}),
                new Student("a1", "b1", "c1", new string[5] {"1","1","1","1","1"}),
                new Student("a2", "b2", "c2", new string[5] {"2","2","2","2","2"}),
                new Student("a3", "b3", "c3", new string[5] {"0","1","2","0","1"}),
                new Student("a4", "b4", "c4", new string[5] {"0","2","1","0","2"}),
                new Student("a5", "b5", "c5", new string[5] {"2","1","2","1","2"}),
                new Student("a6", "b6", "c6", new string[5] {"2","0","2","0","2"}),
                new Student("a7", "b7", "c7", new string[5] {"0","1","0","1","0"}),
                new Student("a8", "b8", "c8", new string[5] {"0","2","0","2","0"}),
                new Student("a9", "b9", "c9", new string[5] {"1","0","1","0","1"})
            };
        }
        public void ContentCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            ObservableCollection<Student> newList = (sender as ObservableCollection<Student>);
            sender = newList;
        }
    }
}
