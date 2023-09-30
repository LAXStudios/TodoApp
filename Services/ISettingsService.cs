using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Services
{
    public interface ISettingsService
    {
        public Task<T> Get<T>(string key, T defaultValue);

        public Task Set<T>(string key, T value);
    }
}
