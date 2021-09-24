using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using WPFFirstTask.Model;
using System.Windows.Input;
using WPFFirstTask.Command;

namespace WPFFirstTask.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;
        private List<Person> _persons;
        private ICommand _SubmitCommand;
        public Person Person
        {
            get { return _person; }
            set { _person = value; NotifyPropertyChanged("Person"); }
        }
      
        public List<Person> Persons
        {
            get
            {
                return _persons;
            }
            set
            {
                _persons = value;
                NotifyPropertyChanged("Persons");
            }
        }
        public PersonViewModel()
        {
            Person = new Person();
            Persons = new List<Person>();

        }

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _SubmitCommand;
            }
        }
       
        private void SubmitExecute(object parameter)
        {
            Persons.Add(Person);
        }
        private bool CanSubmitExecute(object parameter)
        {
            if(string.IsNullOrEmpty(Person.FName)|| string.IsNullOrEmpty(Person.MName) || string.IsNullOrEmpty(Person.LName) || string.IsNullOrEmpty(Person.Gender) || string.IsNullOrEmpty(Person.DOB))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
