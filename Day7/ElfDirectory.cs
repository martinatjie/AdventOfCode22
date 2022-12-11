using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal class ElfDirectory
    {
        public int Id { get; set; }
        public int Size
        {
            get
            {
                return SubDirectoryTotal + FileTotal;
            }
        }
        public string DirectoryName { get; set; } = "Root";
        public int Level { get; set; }
        public ElfDirectory? ParentDirectory { get; set; }
        public List<ElfDirectory> DirectSubDirectories { get; set; } = new List<ElfDirectory>();
        public int SubDirectoryTotal
        {
            get
            {
                return DirectSubDirectories.Sum(d => d.Size);
            }
        }
        public int BelowThresholdTotal
        {
            get
            {
                var directories = DirectSubDirectories.Where(d => d.BelowThreshold.Equals(true));
                return directories.Sum(d => d.Size);
            }
        }
        public int FileTotal
        {
            get
            {
                return DirectFiles.Sum(f => f.Size);
            }
        }
        public List<ElfFile> DirectFiles { get; set; } = new List<ElfFile> { };
        public bool BelowThreshold
        {
            get
            {
                return Size <= 100000 ? true : false;
            }
        }

    }
}
