using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DrumPad_beta.Constants;
using System.Xml.Serialization;

namespace DrumPad_beta
{
    static class KeyBind
    {
        private static int MAX = VARS.NUM_OF_PAD;
        private static Keys[] Binds = new Keys[MAX];

        public static int Bind(Keys key)
        {
            for (int i = 0; i < MAX; i++)
                if (Binds[i] == key)
                    return i;
            return -1;
        }
        public static void LoadBinds()
        {
            string[] buffer;
            buffer = Properties.Settings.Default.SavedBinds.Split(' ');
            for (int i = 0; i < MAX; i++)
                   Binds[i] = (Keys)int.Parse(buffer[i]);
        }
        public static void SaveBinds()
        {
            string SavedStr = "";
            foreach (Keys key in Binds)
            {
                SavedStr += ((int)key).ToString();
                SavedStr += " ";
            }
            SavedStr = SavedStr.Substring(0, SavedStr.Length - 1);
            Properties.Settings.Default.SavedBinds = SavedStr;
            Properties.Settings.Default.Save();
        }
        public static void SetBind(int num, Keys key)
        {
            Binds[num] = key;
        }
        private static void defBinds()
        {
            for (int i = 0, key = (int)Keys.NumPad0; i < MAX; i++, key++)
                Binds[i] = (Keys)key;
        }
    }
}
