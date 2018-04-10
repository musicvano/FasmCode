using ICSharpCode.AvalonEdit.Document;
using System.IO;

namespace FasmCode.ViewModels
{
    public class SourceViewModel
    {
        // The document for AvalonEditor
        public TextDocument Document { get; set; }

        // Returns true if document has been modified
        public bool IsModified { get; set; }

        // Returns file name and extention without full path
        public string ShortFileName
        {
            get
            {
                return Path.GetFileName(Document.FileName);
            }
        }

        public SourceViewModel()
        {
            Document = new TextDocument();
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
        }
    }
}