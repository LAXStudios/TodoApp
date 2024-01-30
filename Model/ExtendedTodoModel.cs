using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Maui.Graphics;

namespace TodoApp.Model
{
    public class ExtendedTodoModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Microsoft.Maui.Graphics.Color LongColor { get; set; }

        //public string Color { get; set; }

        //public string LongColor { get; set; }

    }

    public static class LongColors
    {
        public static Microsoft.Maui.Graphics.Color Blue = new(83f, 223f, 221f);
        public static readonly Microsoft.Maui.Graphics.Color Purple = new(168, 130, 255);
        public static readonly Microsoft.Maui.Graphics.Color Yellow = new(224, 222, 113);
        public static readonly Microsoft.Maui.Graphics.Color Green = new(68, 207, 110);
        public static readonly Microsoft.Maui.Graphics.Color Orange = new(233, 151, 63);
        public static readonly Microsoft.Maui.Graphics.Color Standard = new(34, 34, 34);
    }

    public class rgb
    {
        public int r, g, b;
    }

    // Colors Hex
    // Blue #53DFDD
    // Purple #A882FF
    // Yellow #E0DE71;
    // Green #44CF6E;
    // Orange #E9973F;
    // Standard #222222;
}
