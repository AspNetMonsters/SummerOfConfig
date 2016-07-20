using Microsoft.Extensions.Configuration;

namespace ConfigFromAnywhere.Configuration.Speech
{
    public class SpeechConfigurationSource : FileConfigurationSource
    {
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            FileProvider = FileProvider ?? builder.GetFileProvider();
            return new SpeechConfigurationProvider(this);
        }
    }
}