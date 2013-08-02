using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mouser
{
    [Flags]
    public enum Modifiers : int
    {
        ALT = 1,
        CONTROL = 2,
        SHIFT = 4,
        WIN = 8,
        CONTROL_ALT = 0X2 | 0X1,
        CONTROL_SHIFT = 0X2 | 0X4,
        ALT_SHIFT = 0X1 | 0x4,
        CONTROL_ALT_SHIFT = 0X2 | 0X1 | 0X4,
    }

    [Flags]
    enum MouseFlags
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        Absolute = 0x8000
    };

    static class HotKeys
    {
        const string USER32 = "user32.dll";

        [DllImport(USER32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool RegisterHotKey(
            IntPtr hWnd,
            int Id,
            Modifiers fsModifiers,
            Keys vk
            );

        [DllImport(USER32, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool UnregisterHotKey(
            IntPtr hWnd,
            int Id
            );

        public static bool Register(Form frm, int id,
                                      Modifiers mod,
                                      Keys key)
        {

            if (frm == null || frm.IsDisposed)
                return false;
            if ((uint)mod == 0U)
                return false;
            if (key == Keys.None)
                return false;

            return RegisterHotKey(frm.Handle, id, mod, key);
        }

        public static bool Unregister(Form frm, int id)
        {
            if (frm == null || frm.IsDisposed)
                return false;

            return UnregisterHotKey(frm.Handle, id);
        }


        public static Modifiers GetMod(Keys Input)
        {
            Modifiers mod = Modifiers.ALT;

            switch (Input)
            {
                case Keys.Alt:
                    mod = Modifiers.ALT;
                    break;
                case Keys.Control:
                    mod = Modifiers.CONTROL;
                    break;
                case Keys.Shift:
                    mod = Modifiers.SHIFT;
                    break;
                case Keys.LWin:
                    mod = Modifiers.WIN;
                    break;
                case Keys.Control | Keys.Alt:
                    mod = Modifiers.CONTROL_ALT;
                    break;
                case Keys.Control | Keys.Shift:
                    mod = Modifiers.CONTROL_SHIFT;
                    break;
                case Keys.Alt | Keys.Shift:
                    mod = Modifiers.ALT_SHIFT;
                    break;
                case Keys.Control | Keys.Alt | Keys.Shift:
                    mod = Modifiers.CONTROL_ALT_SHIFT;
                    break;
            }

            return mod;
        }
    }
}
