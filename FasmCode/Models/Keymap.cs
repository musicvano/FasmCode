namespace FasmCode.Models
{
    /// <summary>
    /// Contains shortcuts for all application commands
    /// </summary>
    class Keymap
    {
        public string New { get; set; }
        public string Open { get; set; }
        public string OpenFolder { get; set; }
        public string Save { get; set; }
        public string SaveAs { get; set; }
        public string SaveAll { get; set; }
        public string Close { get; set; }
        public string CloseFolder { get; set; }
        public string Exit { get; set; }

        public string Undo { get; set; }
        public string Redo { get; set; }
        public string Cut { get; set; }
        public string Copy { get; set; }
        public string Paste { get; set; }
        public string Delete { get; set; }
        public string SelectAll { get; set; }
        public string Find { get; set; }
        public string Replace { get; set; }

        public string Compile { get; set; }
        public string Run { get; set; }
        public string Settings { get; set; }

        public string Terminal { get; set; }
        public string Calculator { get; set; }

        public string Help { get; set; }
        public string About { get; set; }
    }
}