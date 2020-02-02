using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaterialUI
{
    public static class MaterialUISettings
    {
        public static MaterialThemes Theme { get; set; }
    }

    public enum MaterialThemes
    {
        None,
        Light,
        Dark
    }
}
