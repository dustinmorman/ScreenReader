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
                using (var engine = new TesseractEngine(@"tessdata", "eng", EngineMode.Default))
                {

                    using (var page = engine.Process(bitmap))
                    {
                    return page.GetText();
                    }
                }
          




        }
    }
}
