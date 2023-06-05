using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Pages;

namespace TodoApp.Model
{
    public class HomeWork
    {
        [LiteDB.BsonId]
        public int Id { get; set; }

        public string Subject { get; set; }
        public enum TypeSubject
        {
            Math,
            German,
            English,
            Philosophy,
            Art,
            Sport,
            French,
            Informatic,
            Other,
        }

        public string HomeWorkPage { get; set; }
        public string HomeWorkNumber { get; set; }
        public string Combine { get; set; }
        public string Description { get; set; }

        public bool IsDone { get; set; }

        public string HomeWorkDate { get; set; }

    }
}
