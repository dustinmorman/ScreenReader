# ScreenReader
This is an accessibility tool the snips portions of the screen and reads them aloud. 

It takes a snip of the screen and saves that as a bitmap. It then feeds that into the TesseractOCR Engine and performs Optical Character Recognition on the bitmap

This then returns a string which is fed into the windows speech synthesiser that then reads the text to the user. The benefit of this is that it does not just read
plain text. It can pull text from images and read it to the user. This overlays itself on any application so even if you are playing a game you can quickly have text read
to you in games that lack accessibility options.

To use run the program and press F1 or click the Make Selection button. The screen will dim and you can then make your selection similar to how the windows
snip tool works. It will then read back the text to you.

Built using Winforms
