namespace PetProject.Domain
{
    public class Todo
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }

        public string Description { get; private set; }
        public bool IsDone { get; private set; }

        public Todo( Guid Id, string Title, string Description, bool IsDone)
        {
            this.Id = Id;
            this.Title = Title;
            this.Description = Description;
            this.IsDone = IsDone;
        }
    }
}
