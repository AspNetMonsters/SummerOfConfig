using System.Collections.Generic;
using System.IO;
using System.Speech.Recognition;

namespace ConfigFromAnywhere.Configuration.Speech
{
    public class SpeechConfigurationRecognizer
    {
        public IDictionary<string, string> Process(string key, Stream stream)
        {
            var result = new Dictionary<string, string>();

            using (var recognizer = new SpeechRecognitionEngine())
            {
                var dictationGrammar = new DictationGrammar();
                recognizer.LoadGrammar(dictationGrammar);

                recognizer.SetInputToWaveStream(stream);
                var recognizeResult = recognizer.Recognize();
                
                result.Add(key, recognizeResult.Text);
                return result;
            }
        } 
    }
}