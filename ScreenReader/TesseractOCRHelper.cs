using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Tesseract;

namespace ScreenReader
{
    class TesseractOCRHelper
    {
        public string ConvertBitmapToString(Bitmap bitmap)
        {
            //Run the bitmap through the tesseract Engine to return a string
            //Occasionally it seems to misread the string so adding 5 to a list then sorting by quantity 
            //seems to solve this problem
            List<string> textOutputs = new List<string>();
            Dictionary<string, int> instanceCount = new Dictionary<string, int>();
            for (int i = 0; i < 5; i++)
            {
                using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
                {

                    using (var page = engine.Process(bitmap))
                    {
                        textOutputs.Add(page.GetText());


                    }
                }
            }

            foreach(string s in textOutputs)
            {
                if (!instanceCount.ContainsKey(s))
                {
                    int count = textOutputs.Where(x => x == s).Count();
                    instanceCount.Add(s, count);
                }
            }


            return instanceCount.OrderByDescending(x => x.Value).FirstOrDefault().Key;
        }
    }
}
