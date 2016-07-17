using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigFromAnywhere.Configuration
{
    public class ImageConfigurationSource : FileConfigurationSource
    {
        public string RegionsPath { get; set; }

        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            FileProvider = FileProvider ?? builder.GetFileProvider();
            return new ImageConfigurationProvider(this);
        }
    }
}
