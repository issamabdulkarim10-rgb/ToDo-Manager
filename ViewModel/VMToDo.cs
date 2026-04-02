using Model;
using System;
using System.ComponentModel;



namespace ViewModel
{
    public class VMToDo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ToDo toDo;
        public ToDo ToDo { get => toDo; set => toDo = value; }
        
        public VMToDo(string titel, string priority, bool isDone, DateTime faelligkeit)
        {
            ToDo = new ToDo(titel, priority, isDone, faelligkeit);
        }
        
        public string Titel
        {
            get
            {
                return ToDo.Titel;
            }
            set
            {
                ToDo.Titel = value;
                OnPropertyChanged(nameof(Titel));
            }
        }

        public string Priority
        {
            get
            {
                return ToDo.Priority;
            }
            set
            {
                ToDo.Priority = value;
                OnPropertyChanged(nameof(Priority));
            }
        }

        public bool IsDone
        {
            get
            {
                return toDo.IsDone;
            }
            set
            {
                toDo.IsDone = value;
                OnPropertyChanged(nameof(IsDone));
            }
        }

        public DateTime Faelligkeit
        {
            get
            {
                return ToDo.Faelligkeit;
            }
            set
            {
                ToDo.Faelligkeit = value;
                OnPropertyChanged("Faelligkeit");
            }
        }

              
        public override string ToString()
        {
            return ToDo.ToString();
        }
    }

}