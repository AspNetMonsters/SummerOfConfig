using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigFromAnywhere.Configuration
{
    public class ImageConfigurationRegion
    {
        public string PropertyName { get; set; }
        public Point TopLeft { get; set; }
        public int Dimension { get; set; }

    }
}
