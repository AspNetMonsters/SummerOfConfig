using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace ConfigFromAnywhere.Configuration.Speech
{
    public static class SpeechConfigurationExtensions
    {
        public static IConfigurationBuilder AddSpeech(this IConfigurationBuilder builder, string speechPath, bool optional = false, bool reloadOnChange = false)
        {
            return AddSpeech(builder, null, speechPath, optional, reloadOnChange);
        }

        public static IConfigurationBuilder AddSpeech(this IConfigurationBuilder builder, IFileProvider provider, string speechPath,
            bool optional, bool reloadOnChange)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (string.IsNullOrEmpty(speechPath))
                throw new ArgumentException("Argument is null or empty", nameof(speechPath));

            if (provider == null)
            {
                if (Path.IsPathRooted(speechPath))
                {
                    provider = new PhysicalFileProvider(speechPath);
                    speechPath = Path.GetFileName(speechPath);
                }
            }

            var source = new SpeechConfigurationSource
            {
                FileProvider = provider,
                Path = speechPath,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };

            builder.Add(source);
            return builder;
        }
    }
}
