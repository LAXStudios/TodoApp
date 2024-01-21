using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Model
{
    public class ExtendedTodoModel
    {
        public string Title { get; set; }
        public string Text { get; set; }

        public LongColors Colors { get; set; }

        public Dictionary<Enum, string> ColorsDic = new Dictionary<Enum, string>
        {
            { LongColors.Blue, "#53DFDD" },
            { LongColors.Purple, "#A882FF"},
            { LongColors.Yellow, "#E0DE71"},
            { LongColors.Green, "#44CF6E"},
            { LongColors.Orange,  "#E9973F"},
        };

    }

    public enum LongColors
    {
        Blue,
        Purple, 
        Yellow,
        Green,
        Orange,
    }
}
