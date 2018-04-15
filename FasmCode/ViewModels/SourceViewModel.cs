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
            if (!File.Exists(fileName))
            {
                File.Create(fileName).Close();
                Document = new TextDocument();
            }
            else
            {
                string str;
                using (StreamReader reader = new StreamReader(fileName))
                    str = reader.ReadToEnd();
                Document = new TextDocument(str);
            }
            Document.FileName = fileName;
        }

        private TextDocument document;

        /// <summary>
        /// The document of the AvalonEditor 
        /// </summary>
        public TextDocument Document
        {
            get { return document; }
            set
            {
                if (value == document) return;
                document = value;
                OnPropertyChanged();
            }
        }

        private bool isModified;

        /// <summary>
        /// Returns true if the document has been modified
        /// </summary>
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