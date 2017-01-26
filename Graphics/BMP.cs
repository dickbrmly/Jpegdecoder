using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics
{
    public class BMP
    {
        int[] ctable = new int[256];
        public static Bitmap map; //Pixels for PictureBox        
        public static int filler, width, height, offset, imageSize, BPP;

        public void bmp(byte[] data)
        {
            width =     (Int32)(data[21] * 0x1000000 + data[20] * 0x10000 + data[19] * 0x100 + data[18]);
            height =    (Int32)(data[25] * 0x1000000 + data[24] * 0x10000 + data[23] * 0x100 + data[22]);
            offset =    (Int32)(data[13] * 0x1000000 + data[12] * 0x10000 + data[11] * 0x100 + data[10]);
            imageSize = (Int32)(data[37] * 0x1000000 + data[36] * 0x10000 + data[35] * 0x100 + data[34]);
            BPP =       (Int32)(data[29] * 0x100 + data[28]);

            filler = imageSize / height - width * BPP / 8; // record size to pixel box size adjustment.
            
            int j = 0;
            for (int i = 0x36; i < 0x436; i = i + 4)
            {
                ctable[j] = BitConverter.ToInt32(data, i);
                j++;
            }
            
            if (BPP <= 4) fourBit(data);  // 16 color
            else if (BPP <= 8) eightBit(data); // 256 color
            else if (BPP <= 24) twentyfourBit(data);// 16 million colors
            
            Form1 settingsForm = new Form1(map,width,height);
            settingsForm.Show();
         }

        private void fourBit(byte[] data)
        {
            byte index;
            int red, green, blue;
            map = new Bitmap(width, height);

            for (int y = height - 1; y > 0; y--)
            {
                for (int nibble = 0; nibble < width; nibble++)
                {
                    if (nibble % 2 > 0)
                    {
                        index = (byte)(data[offset] & 0x0f);
                        offset++;
                    }
                    else index = (byte)((data[offset] & 0xf0) / 0x10);

                    red = (ctable[index] / 0x10000) & 0xff;
                    green = (ctable[index] / 0x100) & 0xff;
                    blue = ctable[index] & 0xff;
                    map.SetPixel(nibble, y, Color.FromArgb(red, green, blue));
                }
                offset += filler;
            }
        }

        private void eightBit(byte[] data)
        {
           int red, green, blue;
           map = new Bitmap(width, height);

           for (int y = height - 1; y > 0; y--)
           {
               for (int x = 0; x < width; x++)
               {
                   red = (ctable[data[offset]] / 0x10000) & 0xff;
                   green = (ctable[data[offset]] / 0x100) & 0xff;
                   blue = (ctable[data[offset]]) & 0xff;
                   map.SetPixel(x, y, Color.FromArgb(red, green, blue));
                   offset++;
               }
               offset += filler;  
           }
        }

        private void twentyfourBit(byte[] data)
        {
            byte red, green, blue;
            map = new Bitmap(width, height);
            for (int y = height - 1; y >= 0; y--)
            {
                for (int x = 0; x < width; x++)
                {
                    blue = data[offset++];
                    green = data[offset++];
                    red = data[offset++];
                    map.SetPixel(x, y, Color.FromArgb(red, green, blue));
                }
                offset += filler;
            }
        }
    }
}
