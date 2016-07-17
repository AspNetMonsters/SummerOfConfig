using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigFromAnywhere.Configuration
{
    public static class ImageConfigurationExtensions
    {
        public static IConfigurationBuilder AddImageFile(this IConfigurationBuilder builder, string imagePath, string regionsPath)
        {
            return AddImageFile(builder, null, imagePath, regionsPath, false, false);
        }

        public static IConfigurationBuilder AddImageFile(this IConfigurationBuilder builder, IFileProvider provider, string imagePath, string regionsPath, bool optional, bool reloadOnChange)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }
            if (string.IsNullOrEmpty(imagePath))
            {
                throw new ArgumentException("Invalid file path.", nameof(imagePath));
            }
            if (string.IsNullOrEmpty(regionsPath))
            {
                throw new ArgumentException("Invalid regions path.", nameof(regionsPath));
            }
            if (provider == null)
            {
                if (Path.IsPathRooted(imagePath))
                {
                    provider = new PhysicalFileProvider(Path.GetDirectoryName(imagePath));
                    imagePath = Path.GetFileName(imagePath);
                }
                if (Path.IsPathRooted(regionsPath))
                {
                    provider = new PhysicalFileProvider(Path.GetDirectoryName(imagePath));
                    regionsPath = Path.GetFileName(regionsPath);
                }
            }
                var source = new ImageConfigurationSource
            {
                FileProvider = provider,
                Path = imagePath,
                RegionsPath = regionsPath,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };
            builder.Add(source);
            return builder;
        }



    }
}
