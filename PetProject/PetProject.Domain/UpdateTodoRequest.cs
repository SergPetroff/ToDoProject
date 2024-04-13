namespace PetProject.Domain
{
    public class UpdateTodoRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public bool IsDone { get; set; }
    }
}
