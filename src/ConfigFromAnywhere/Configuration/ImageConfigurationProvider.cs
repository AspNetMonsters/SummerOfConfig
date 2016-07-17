using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace ConfigFromAnywhere.Configuration
{
    public class ImageConfigurationProvider : FileConfigurationProvider
    {
        public ImageConfigurationProvider(ImageConfigurationSource source) : base(source) { }

        public override void Load(Stream stream)
        {
            var regionsFile = (this.Source as ImageConfigurationSource).RegionsPath;
            var regions = (new ImageConfigurationRegionsParser()).Parse(regionsFile);
            var parser = new ImageConfigurationParser();

            Data = parser.Parse(stream, regions.Values);
        }
        
    }
}
