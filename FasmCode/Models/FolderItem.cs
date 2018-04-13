using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FasmCode.Models
{
    /// <summary>
    /// The directory of the file system
    /// </summary>
    public class FolderItem : Item
    {
        /// <summary>
        /// Creates a new FolderItem instance
        /// </summary>
        public FolderItem(string path)
        {
            Path = path;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            DirectoryInfo[] dirInfos = dirInfo.GetDirectories();
            Items = dirInfos
                .Where(d => !d.Attributes.HasFlag(FileAttributes.Hidden | FileAttributes.System))
                .Select(d => (Item)new FolderItem(d.FullName)).ToList();
            FileInfo[] fileInfos = dirInfo.GetFiles();
            var files = fileInfos
                .Where(f => !f.Attributes.HasFlag(FileAttributes.Hidden | FileAttributes.System))
                .Select(f => (Item)new FileItem(f.FullName)).ToList();
            Items.AddRange(files);        }

        /// <summary>
        /// Contains all directories and files
        /// </summary>
        public List<Item> Items { get; set; }
    }
}