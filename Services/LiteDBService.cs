using LiteDB;

namespace TodoApp.Services
{
    public class LiteDBService : ILiteDBService
    {
        public async Task Delete(int id)
        {
            using var db = new LiteDatabase(GetConnectionString());
            var todos = db.GetCollection<Todo>("todos");
            todos.EnsureIndex(x => x.Id);
            var itemToDelete = todos.FindOne(x => x.Id == id);
            if (itemToDelete != null)
            {
                todos.Delete(itemToDelete.Id);
            }
        }

        public async Task<List<Todo>> GetAll()
        {
            using var db = new LiteDatabase(GetConnectionString());

            var collection = db.GetCollection<Todo>("todos");

            var todos = collection.Query().ToList();

            return todos;
        }

        public async Task Save(Todo todo)
        {
            using var db = new LiteDatabase(GetConnectionString());

            var collection = db.GetCollection<Todo>("todos");

            collection.Insert(todo);

            collection.EnsureIndex(x => x.Title);
        }

        public async Task Update(Todo todo)
        {
            using var db = new LiteDatabase(GetConnectionString());
            var todos = db.GetCollection<Todo>("todos");
            todos.EnsureIndex(x => x.Id);
            var itemToDelete = todos.FindOne(x => x.Id == todo.Id);
            if (itemToDelete != null)
            {
                todos.Update(todo);
            }
        }

        private string GetConnectionString()
        {
            var path = FileSystem.Current.AppDataDirectory;
            string fullpath = Path.Combine(path, "todo.db");
            return fullpath;
        }
    }
}
