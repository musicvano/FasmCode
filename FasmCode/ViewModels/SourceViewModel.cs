using ICSharpCode.AvalonEdit.Document;
using System.IO;

namespace FasmCode.ViewModels
{
    public class SourceViewModel
    {
        public TextDocument Document { get; set; }
        public bool IsModified { get; set; }
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
    }
}