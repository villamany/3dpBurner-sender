# 3dpBurner-sender GPLv3 licensed
A GCODE sender for 3dpBurner laser cutter/engraver (GRBL based)

GitHub notes:
The master branch contain the development version.
Check the "Releases" for release versions and binary files.

v0.1.1
// Improved file streaming speed: On file streaming all line responses was added to log console. this produce a slowly file streaming due many visual lines to move. Now only add lines if response is not "ok"

// Removed "stop" button it no was canceling instantly, now only "start" button enabled/disabled during streaming, press reset if you want to cancel the work.

// Added bufer status text near progress bar

// Added total processed lines on the total lines label

// Other minor changes

v0.1 Initial release