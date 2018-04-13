using ICSharpCode.AvalonEdit.Document;
using System.IO;

namespace FasmCode.ViewModels
{
    // Represents the tab of source code in the editor
    class SourceViewModel: BaseViewModel
    {
        // Creates source view model by reading content from the file
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

        // The document of the AvalonEditor
        public TextDocument Document { get; set; }

        // Returns true if the document has been modified
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

        // Returns file name and extention without full path
        public string ShortFileName
        {
            get { return Path.GetFileName(Document.FileName); }
        }

        // Saves the document to file using early specified location
        public void Save()
        {
            SaveAs(Document.FileName);
        }

        // Saves the document to file
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