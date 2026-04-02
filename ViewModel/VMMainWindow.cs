using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ViewModel
{
    public class VMMainWindow : INotifyPropertyChanged
    {
        public ObservableCollection<VMToDo> OffeneAufgaben { get; set; } = new ObservableCollection<VMToDo>();
        public ObservableCollection<VMToDo> ErledigteAufgaben { get; set; } = new ObservableCollection<VMToDo>();

        public UserCommand ButtonHinzufuegen { get; set; }
        public UserCommand ButtonAlsErledigt { get; set; }

        private string neuerTitel;
        private VMToDo selectedToDo;
        private string neuerPriority;
        private DateTime? neuerFaelligkeit;

        
        public string NeuerTitel
        {
            get => neuerTitel;
            set 
            { 
                neuerTitel = value;
                OnPropertyChanged(nameof(NeuerTitel));
            }
        }
                
        public string NeuerPriority
        {
            get => neuerPriority;
            set 
            {
                neuerPriority = value; OnPropertyChanged(nameof(NeuerPriority));
            }
        }
                
        public DateTime? NeuerFaelligkeit
        {
            get => neuerFaelligkeit;
            set 
            {
                neuerFaelligkeit = value; OnPropertyChanged(nameof(NeuerFaelligkeit));
            }
        }

        public VMToDo SelectedToDo
        {
            get => selectedToDo;
            set
            {
                selectedToDo = value;
                OnPropertyChanged(nameof(SelectedToDo));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public VMMainWindow()
        {
            ButtonHinzufuegen = new UserCommand(Hinzufuegen);
            ButtonAlsErledigt = new UserCommand(AlsErledigt);

            AddDaten();
            Leeren();
        }

        public void AddDaten()
        {
            OffeneAufgaben.Add(new VMToDo("Wäsche waschen", "niedrig", false, new DateTime(2026, 04, 05)));
            OffeneAufgaben.Add(new VMToDo("Einkaufen", "hoch", false, new DateTime(2026, 05, 10)));
            OffeneAufgaben.Add(new VMToDo("Bürgeramt kontaktieren", "mittel", false, new DateTime(2026, 05, 20)));
        }

        public void Leeren()
        {
            NeuerTitel = "";
            NeuerPriority = "";
            NeuerFaelligkeit = DateTime.Now;
        }

        public void Hinzufuegen(object obj)
        {
            if (!string.IsNullOrWhiteSpace(NeuerTitel) && NeuerFaelligkeit != null)
            {
                OffeneAufgaben.Add(new VMToDo(NeuerTitel, NeuerPriority, false, NeuerFaelligkeit.Value));
                Leeren();
            }
        }

        private void AlsErledigt(object obj)
        {
            if (obj is VMToDo task)
            {
                task.IsDone = true;

                OffeneAufgaben.Remove(task);
                ErledigteAufgaben.Add(task);

                SelectedToDo = null;
            }
        }
    }
}