namespace FasmCode.Models
{
    /// <summary>
    /// The file of the file system
    /// </summary>
    public class FileItem : Item
    {
        /// <summary>
        /// Creates a new FileItem instance
        /// </summary>
        public FileItem(string path)
        {
            Path = path;
        }
    }
}