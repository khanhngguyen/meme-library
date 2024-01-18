using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeLibrary.Domain.src.Entities
{
    public class Meme
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public Uri Url { get; set; } = default!;
        public int Width { get; set; } = default!;
        public int Height { get; set; } = default!;
        public int Captions { get; set; } = default!;
    }
}