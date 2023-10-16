using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Services
{
    public interface IHomeWorkService
    {
        Task Add(HomeWork homeWork);
        Task GetHomeWork(int id);
        Task<List<HomeWork>> GetAllHomeWork();
        Task Update(HomeWork homeWork);
        Task Delete(int id);
    }
}
