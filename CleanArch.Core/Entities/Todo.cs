using System;

namespace CleanArch.Core.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Complete { get; set; }

        internal void CompleteTask()
        {
            this.Complete = true;
        }
    }
}