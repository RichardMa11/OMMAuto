﻿using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CMMAuto.CommonHelp
{
    public class KeyboardSimulatorHelp
    {
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(Keys bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        public const int KEYEVENTF_KEYUP = 2;

        private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        //private const uint KEYEVENTF_KEYUP = 0x0002;
        private const int VK_CONTROL = 0x11; // VK_CONTROL (CTRL) key
        private const int VK_V = 0x56; // VK_V (V) key
        private const int VK_C = 0x43; // VK_C (C) key

        //public void PressKey(byte keyCode)
        //{
        //    keybd_event(keyCode, 0, KEYEVENTF_EXTENDEDKEY | 0, 0); // Press down the key
        //    keybd_event(keyCode, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0); // Release the key
        //}

        //public void CopyText(string text)
        //{
        //    // 将文本放入剪贴板
        //    Clipboard.SetText(text);
        //    PressKey(VK_CONTROL); // Press CTRL key down
        //    PressKey(VK_C); // Press C key down (Copy)
        //    PressKey(VK_CONTROL); // Release CTRL key up
        //}

        //public void PasteText()
        //{
        //    PressKey(VK_CONTROL); // Press CTRL key down
        //    PressKey(VK_V); // Press V key down (Paste)
        //    PressKey(VK_CONTROL); // Release CTRL key up
        //}

        public void SimiuCrtlO()
        {
            keybd_event(Keys.ControlKey, 0, 0, 0);
            keybd_event(Keys.O, 0, 0, 0);
            keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
        }

        public void SimiuCrtlV()
        {
            keybd_event(Keys.ControlKey, 0, 0, 0);
            keybd_event(Keys.V, 0, 0, 0);
            keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
        }

        public void SimiuCrtlQ()
        {
            keybd_event(Keys.ControlKey, 0, 0, 0);
            keybd_event(Keys.Q, 0, 0, 0);
            keybd_event(Keys.ControlKey, 0, KEYEVENTF_KEYUP, 0);
        }
    }



}
