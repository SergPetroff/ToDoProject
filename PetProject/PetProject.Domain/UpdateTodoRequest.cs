namespace PetProject.Domain
{
    public record UpdateTodoRequest(string Title, string Description, bool IsDone);
}
