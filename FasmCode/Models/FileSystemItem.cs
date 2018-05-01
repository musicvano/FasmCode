namespace FasmCode.Models
{
    /// <summary>
    /// Represent an item of the file system
    /// </summary>
    public class FileSystemItem
    {
        /// <summary>
        /// Full path of the file or directory
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Returns the short name of the file or directory
        /// </summary>
        public string Name
        {
            get
            {
                var name = System.IO.Path.GetFileName(Path);
                return !string.IsNullOrEmpty(name) ? name : Path;
            }
        }
    }
}