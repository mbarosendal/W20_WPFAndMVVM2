using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person person;

        // Properties tilgængelige for View-laget?
        public string FirstName
        {
            get { return person.FirstName; }
            set
            {
                person.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public void DeletePerson(PersonRepository personRepo)
        {
            if (person != null)
            {
                personRepo.Remove(person.Id);
            }
        }

        public string LastName
        {
            get { return person.LastName; }
            set
            {
                person.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public int Age
        {
            get { return person.Age; }
            set
            {
                person.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string Phone
        {
            get { return person.Phone; }
            set
            {
                person.Phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        // Constructor til initialisering af klassens medlemmer
        public PersonViewModel(Person person)
        {
            this.person = person;
        }

        // Implementering af INotifyPropertyChanged for at notificere UI om ændringer
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)           
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));  
            }
        }

    }
}
