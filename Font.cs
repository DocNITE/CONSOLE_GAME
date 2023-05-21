using System;
using System.Runtime.InteropServices;

namespace Engine;

public partial class Font {
    internal static int SetFont(IntPtr h, short sizeX, short sizeY) {
		if (h == new IntPtr(-1)) {
			return Marshal.GetLastWin32Error();
		}

		Kernel32.CONSOLE_FONT_INFO_EX cfi = new Kernel32.CONSOLE_FONT_INFO_EX();
		cfi.cbSize = (uint)Marshal.SizeOf(cfi);
		cfi.nFont = 0;

		cfi.dwFontSize.X = sizeX;
		cfi.dwFontSize.Y = sizeY;

		// sätter font till Terminal (Raster)
		if (sizeX < 4 || sizeY < 4) cfi.FaceName = "Consolas";
		else cfi.FaceName = "Terminal"; //Terminal

		Kernel32.SetCurrentConsoleFontEx(h, false, ref cfi);
		return 0;
	}
}