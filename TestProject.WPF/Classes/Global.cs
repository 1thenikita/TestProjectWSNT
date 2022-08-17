using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TestProject.WPF.Entities;

namespace TestProject.WPF.Classes
{
    public static class Global
    {
        public static Frame FrameMain { get; set; }
        public static DBEntities DB { get; set; }
    }
}
