using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace FasmCode.Models
{
    /// <summary>
    /// The directory of the file system
    /// </summary>
    public class FolderItem : FileSystemItem
    {
        /// <summary>
        /// Creates a new FolderItem instance
        /// </summary>
        public FolderItem(string path)
        {
            Path = path;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
            var items = dirInfos
                .Where(d => !d.Attributes.HasFlag(FileAttributes.Hidden | FileAttributes.System))
                .Select(d => (FileSystemItem)new FolderItem(d.FullName));
            Items = new ObservableCollection<FileSystemItem>(items);
            FileInfo[] fileInfos = dirInfo.GetFiles();
            var files = fileInfos
                .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden | FileAttributes.System))
                .Select(f => (FileSystemItem)new FileItem(f.FullName)).ToList();
            foreach (var file in files)
                Items.Add(file);
        }

        /// <summary>
        /// Contains all directories and files
        /// </summary>
        public ObservableCollection<FileSystemItem> Items { get; set; }
    }
}