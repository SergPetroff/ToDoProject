namespace PetProject.API.Contracts
{
    public record AddTodoRequest(string Title, string Description, bool IsDone = false);
}
