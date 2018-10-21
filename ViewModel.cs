namespace WfControlHostedInWpfControl
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;
    using CommonLibrary;

    public class ViewModel : INotifyPropertyChanged
    {
        private Person person;
        private readonly List<Person> repository;

        public ViewModel()
        {
            repository = new List<Person>
            {
                new Person { Name = "John", Age = 20 }, 
                new Person { Name = "Amber", Age = 24 },
                new Person { Name = "Sally", Age = 30 }, 
                new Person { Name = "Abe", Age = 50 }
            };

            ShowMagic = new DelegatingCommand(PickRandomPerson);
        }

        public Person Person
        {
            get { return person; }
            set
            {
                person = value;
                OnPropertyChanged("Person");
            }
        }

        public ICommand ShowMagic { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PickRandomPerson()
        {
            int index = new Random().Next(0, repository.Count);
            Person = repository[index];
        }
    }
}
