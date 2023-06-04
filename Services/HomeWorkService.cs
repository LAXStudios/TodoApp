using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task Delete(int id)
        {
            throw new NotImplementedException();
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

        public Task Update(HomeWork homeWork)
        {
            throw new NotImplementedException();
        }

        private string GetConnectionString()
        {
            var path = FileSystem.Current.AppDataDirectory;
            string fullpath = Path.Combine(path, "homework.db");
            return fullpath;
        }
    }
}
