using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    internal static class CommunicationSystemService
    {
        private static List<ElfDirectory> _navigationHistory = new List<ElfDirectory>();
        private static ElfDirectory _parentDirectory;
        private static ElfDirectory _rootDirectory;

        internal static int CalculateSumOfDirectorySizesBelowThreshold(int threshold)
        {
            var sizes = new List<int>();
            sizes = GetSizesBelowThreshold(_rootDirectory, sizes);

            var sum = sizes.Sum();

            return sum;
        }

        private static List<int> GetSizesBelowThreshold(ElfDirectory parentDirectory, List<int> childDirectorySizes)
        {
            if (childDirectorySizes == null)
            {
                childDirectorySizes = new List<int>();
            }

            foreach (var childDirectory in parentDirectory.DirectSubDirectories)
            {
                if (childDirectory.BelowThreshold)
                {
                    childDirectorySizes.Add(childDirectory.Size);
                }

                GetSizesBelowThreshold(childDirectory, childDirectorySizes);
            }
            return childDirectorySizes;
        }

        internal static void AddFile(ElfFile file)
        {
            var directory = _navigationHistory.Last();
            directory.DirectFiles.Add(file);
        }

        internal static void AddDirectory(string directoryName)
        {
            var directory = new ElfDirectory();
            directory.DirectoryName = directoryName;
            directory.ParentDirectory = _parentDirectory;

            _parentDirectory.DirectSubDirectories.Add(directory);
        }

        internal static void NavigateToRoot()
        {
            if (_parentDirectory == null && _navigationHistory.Count == 0)
            {
                _parentDirectory = new ElfDirectory { DirectoryName = "Root" };
                _rootDirectory = _parentDirectory;

                _navigationHistory.Add(_parentDirectory);
            }
            else
            {
                var rootDirectory = _navigationHistory.Where(e => e.DirectoryName.Equals("Root")).First();

                if (rootDirectory != null)
                {
                    _navigationHistory.Add(rootDirectory);
                }
            }
        }

        internal static void NavigateTo(string directoryName)
        {
            var foundDirectories = _navigationHistory.Last().DirectSubDirectories.Where(e => e.DirectoryName.Equals(directoryName));

            if (foundDirectories.Count() > 1)
            {
                _navigationHistory.Add(foundDirectories.Where(f => f.ParentDirectory.Equals(_parentDirectory)).First());
            }
            else
            {
                _navigationHistory.Add(foundDirectories.First());
            }
        }

        internal static void NavigateBack()
        {
            var goToDirectory = _navigationHistory.Last().ParentDirectory;
            _navigationHistory.Add(goToDirectory);
        }

        internal static void BuildListing()
        {
            _parentDirectory = _navigationHistory.Last();
        }

    }
}
