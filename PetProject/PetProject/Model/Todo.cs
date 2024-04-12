﻿namespace PetProject.Model
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public bool IsDone { get; set; } = false;
    }
}