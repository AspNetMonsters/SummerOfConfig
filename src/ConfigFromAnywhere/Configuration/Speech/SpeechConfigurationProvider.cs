using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConfigFromAnywhere.Configuration.Speech
{
    public class SpeechConfigurationProvider : FileConfigurationProvider
    {
        public SpeechConfigurationProvider(FileConfigurationSource source) : base(source)
        {
        }

        public override void Load(Stream stream)
        {
            var parser = new SpeechConfigurationRecognizer();
            Data = parser.Process(key: Path.GetFileNameWithoutExtension(Source.Path), stream: stream);
        }
    }
}