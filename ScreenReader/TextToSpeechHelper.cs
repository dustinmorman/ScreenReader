using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;

namespace ScreenReader
{
    public class TextToSpeechHelper
    {
        SpeechSynthesizer speechSynthesizerObj;

        public TextToSpeechHelper()
        {
            speechSynthesizerObj = new SpeechSynthesizer();

        }
        public void ReadTextAloud(string text)
        {

            string newText = text.Replace("\n", " ");
            newText = newText.Replace("\r", " ");
            speechSynthesizerObj = new SpeechSynthesizer();
            
            
            speechSynthesizerObj.SpeakAsync(newText);
        }
    }
}
