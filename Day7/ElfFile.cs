using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class ElfFile
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public int DirectoryLevel { get; set; }
        public int Size { get; set; }
    }
}
