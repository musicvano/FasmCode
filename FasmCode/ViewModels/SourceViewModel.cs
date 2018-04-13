using ICSharpCode.AvalonEdit.Document;
using System.IO;

namespace FasmCode.ViewModels
{
    /// <summary>
    /// Represents the tab of source code in the editor
    /// </summary>
    class SourceViewModel : BaseViewModel
    {
        /// <summary>
        /// Creates source view model by reading content from the file
        /// </summary>
        public SourceViewModel(string fileName)
        {
            Document = new TextDocument();
            Document.FileName = fileName;
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
            }
            else
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    Document.Text = reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// The document of the AvalonEditor 
        /// </summary>
        public TextDocument Document { get; set; }

        /// <summary>
        /// Returns true if the document has been modified
        /// </summary>
        private bool isModified;
        public bool IsModified
        {
            get { return isModified; }
            set
            {
                if (value == isModified) return;
                isModified = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Returns file name and extention without full path
        /// </summary>
        public string ShortFileName
        {
            get { return Path.GetFileName(Document.FileName); }
        }

        /// <summary>
        /// Saves the document to file using early specified location
        /// </summary>
        public void Save()
        {
            SaveAs(Document.FileName);
        }

        /// <summary>
        /// Saves the document to file
        /// </summary>
        public void SaveAs(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.Write(Document.Text);
            }
            IsModified = false;
        }
    }
}