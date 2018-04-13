namespace FasmCode.Models
{
    /// <summary>
    /// Represent an item of the file system
    /// </summary>
    public class Item
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
                return System.IO.Path.GetFileName(Path);
            }
        }
    }
}