
namespace TodoApp.Services
{
    public interface ILiteDBService
    {
        Task<List<Todo>> GetAll();
        Task Save(Todo todo);
        Task Delete(int id);
        Task Update(Todo todo);
    }
}
