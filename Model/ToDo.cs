using System;


namespace Model
{
    public class ToDo
    {
        private string titel;
        private string priority;
        private bool isDone;
        private DateTime faelligkeit;

        public string Titel { get => titel; set => titel = value; }
        public string Priority { get => priority; set => priority = value; }
        public bool IsDone { get => isDone; set => isDone = value; }
        public DateTime Faelligkeit { get => faelligkeit; set => faelligkeit = value; }

        public ToDo(string titel, string priority, bool isDone, DateTime faelligkeit)
        {
            this.titel = titel;
            this.priority = priority;
            this.isDone = isDone;
            this.faelligkeit = faelligkeit;
        }

        public override string ToString()
        {
            return titel + " " + priority + " " + isDone;
        }
    }
}


