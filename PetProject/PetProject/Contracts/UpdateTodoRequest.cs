namespace PetProject.API.Contracts
{
    public record UpdateTodoRequest(string Title, string Description, bool IsDone);
}
