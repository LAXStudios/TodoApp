using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Model;

namespace TodoApp.Services
{
    public class HomeWorkService : IHomeWorkService
    {
        public async Task Add(HomeWork homeWork)
        {
            using var db = new LiteDatabase(GetConnectionString());

            var collection = db.GetCollection<HomeWork>("homeworks");

            collection.Insert(homeWork);

            collection.EnsureIndex(x => x.Id);
        }

        public async Task Delete(int id)
        {
            using var db = new LiteDatabase(GetConnectionString());
            var homeworks = db.GetCollection<Todo>("homeworks");
            homeworks.EnsureIndex(x => x.Id);
            var itemToDelete = homeworks.FindOne(x => x.Id == id);
            if (itemToDelete != null)
            {
                homeworks.Delete(itemToDelete.Id);
            }
        }

        public Task GetHomeWork(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<HomeWork>> GetAllHomeWork()
        {
            using var db = new LiteDatabase(GetConnectionString());

            var collection = db.GetCollection<HomeWork>("homeworks");

            var homeworks = collection.Query().ToList();

            return homeworks;
        }

        public async Task Update(HomeWork homeWork)
        {
            using var db = new LiteDatabase(GetConnectionString());
            var collection = db.GetCollection<HomeWork>("homeworks");
            collection.EnsureIndex(x => x.Id);
            var itemToDelete = collection.FindOne(x => x.Id == homeWork.Id);
            if (itemToDelete != null)
            {
                collection.Update(itemToDelete);
            }
        }

        private string GetConnectionString()
        {
            var path = FileSystem.Current.AppDataDirectory;
            string fullpath = Path.Combine(path, "homework.db");
            return fullpath;
        }
    }
}
