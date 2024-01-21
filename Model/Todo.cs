using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TodoApp.Model;

namespace TodoApp.Model
{
    public class Todo
    {
        [BsonId]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public bool? UnderList { get; set; }
        public ExtendedTodoModel ExtendedTodo { get; set; }
    }
}
