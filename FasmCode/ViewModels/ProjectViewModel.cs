using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FasmCode.ViewModels
{
    class ProjectViewModel
    {
        public bool ShowTree { get; set; }

        public ProjectViewModel()
        {
            ShowTree = true;
        }
    }
}
