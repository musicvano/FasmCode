namespace FasmCode.Models
{
    class Config
    {
        // Current keymap file
        public string Keymap { get; set; }

        // Current theme file
        public string Theme { get; set; }

        // Path from the root application folder to the compiler executable
        public string Compiler { get; set; }
    }
}