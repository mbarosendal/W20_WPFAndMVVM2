using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonRepository PersonRepository;

        public ObservableCollection<PersonViewModel> PersonsVM { get; set; }

        private PersonViewModel selectedPerson;

        public PersonViewModel SelectedPerson
        {
            get { return selectedPerson; }
            set 
            { 
                selectedPerson = value; 
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }


        public void AddDefaultPerson()
        {
            try
            {
                // Add the default person to the repository
                Person defaultPerson = PersonRepository.Add("Specify FirstName", "Specify LastName", 0, "Specify Phone");

                // Create a corresponding view model for the default person
                PersonViewModel defaultPersonViewModel = new PersonViewModel(defaultPerson);

                // Add the view model to the collection
                PersonsVM.Add(defaultPersonViewModel);

                // Set the default person as the selected person in the ListBox
                SelectedPerson = defaultPersonViewModel;
            }
            catch (ArgumentException ex)
            {
                // Handle exception if arguments are not valid
                // For example: Log the error, show a message to the user, etc.
            }
        }
        public void DeleteSelectedPerson()
        {
            if (SelectedPerson != null)
            {
                // Slet den valgte person fra personRepo via PersonViewModel's DeletePerson metode
                SelectedPerson.DeletePerson(PersonRepository);

                // Fjern den valgte person fra PersonsVM i MainViewModel
                PersonsVM.Remove(SelectedPerson);

                // Nulstil valgt person til null, så den ikke længere er valgt i ListBox'en
                SelectedPerson = null;
            }
        }


        public MainViewModel()
        {
            PersonRepository = new PersonRepository();
            PersonsVM = new ObservableCollection<PersonViewModel>();

            foreach (var person in PersonRepository.GetAll())
            {
                PersonsVM.Add(new PersonViewModel(person));
            }
        }

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


