using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigFromAnywhere.Configuration
{
    internal class ImageConfigurationRegionsParser
    {
        private Dictionary<string, ImageConfigurationRegion> _regions = new Dictionary<string, ImageConfigurationRegion>();

        public IDictionary< string, ImageConfigurationRegion> Parse(string regionsPath)
        {            
            _regions.Clear();

            using (var reader = new StreamReader(regionsPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var region = BuildRegion(line);
                    _regions.Add(region.PropertyName, region);
                }
            }

            return _regions;
        }

        private ImageConfigurationRegion BuildRegion(string regionLineData)
        {
            var data = regionLineData.Split(' ');

            var key = data[0];
            var x = int.Parse(data[1]);
            var y = int.Parse(data[2]);
            var dim = int.Parse(data[3]);

            return new ImageConfigurationRegion
            {
                PropertyName = key,
                Dimension = dim,
                TopLeft = new Point(x, y)
            };
        }

    }
}
