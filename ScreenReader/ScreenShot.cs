using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ScreenReader
{
    class ScreenShot
    {

        public static bool saveToClipboard = false;

        public static void CaptureImage(bool showCursor, Size curSize, Point curPos, Point SourcePoint, Point DestinationPoint, Rectangle SelectionRectangle)
        {
            try
            {
                using (Bitmap bitmap = new Bitmap(SelectionRectangle.Width, SelectionRectangle.Height))
                {

                    using (Graphics g = Graphics.FromImage(bitmap))
                    {

                        g.CopyFromScreen(SourcePoint, DestinationPoint, SelectionRectangle.Size);

                        if (showCursor)
                        {

                            Rectangle cursorBounds = new Rectangle(curPos, curSize);
                            Cursors.Default.Draw(g, cursorBounds);

                        }

                    }

                    TesseractOCRHelper t = new TesseractOCRHelper();
                    string text = t.ConvertBitmapToString(bitmap);
                    TextToSpeechHelper s = new TextToSpeechHelper();
                    s.ReadTextAloud(text);


                }
            }
            catch
            {

            }


        }
    }
}
