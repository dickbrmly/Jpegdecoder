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
    public partial class Control: Form
    {
        bool showHuffs = false;
        bool showQuant = false;
        bool showDescrete = false;
        bool showYCbCr = false;
        bool showRGB = false;

        public  byte[] data; //read data buffer
        string file;               //name of file

        public Control() { InitializeComponent(); } // initalize control form.

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int imageType; //coded image type

            DialogResult result = openFileDialog1.ShowDialog();                     // open directory for file selection formm.
            if (result == DialogResult.OK) { file = openFileDialog1.FileName; }     // if selection valid, load file name.
            try { data = File.ReadAllBytes(file); }                                 // dump whole file into read buffer for best performance.
            catch (IOException) { }                                                 // Exceptions are currently unhandled.

            textBox1.Text = System.IO.Path.GetFileName(file);                       //display only file name less path...

            imageType = (Int32)(data[0] * 0x100 + data[1]);                         // determine image type.

            switch (imageType)  // switch on image type.
            {
                case 0x424d: // BMP Windows 
                            callBmp(data);
                            break;
                case 0x4241: // OS/2 struct bitmap array
                            callBmp(data);
                            break;
                case 0x4349: // OS/2 struct color icon
                            callBmp(data);
                            break;
                case 0x4350: // OS/2 const color pointer
                            callBmp(data);
                            break;
                case 0x4943: // OS/2 struct icon
                            callBmp(data);
                            break;
                case 0x5054: // OS/2 Pointer
                            callBmp(data);
                            break;

                case 0xffd8://jpeg
                            JPG photo = new JPG();
                            photo.jpg(data, showHuffs, showQuant, showDescrete, showYCbCr, showRGB,numericUpDown1.Value,numericUpDown2.Value);
                            textBox2.Text = JPG.width.ToString();
                            textBox3.Text = JPG.height.ToString();
                            textBox4.Text = JPG.BPP.ToString();
                            textBox5.Text = JPG.imageSize.ToString();
                            lumFactor.Text = JPG.lumRatio.ToString("X");
                            blueFactor.Text = JPG.blueRatio.ToString("X");
                            redFactor.Text = JPG.redRatio.ToString("X");
                            restartBox.Text = JPG.restart.ToString();
                            break;
                
                default:
                            textBox1.Text = "Unknown Format"; //load file name box with state.
                            break;
            }
        }
        private void callBmp(byte[] data) //
        {
             BMP winFile = new BMP();
             winFile.bmp(data); // here.
             textBox2.Text = BMP.width.ToString();
             textBox3.Text = BMP.height.ToString();
             textBox4.Text = BMP.BPP.ToString();
             textBox5.Text = BMP.imageSize.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) { Dispose(true); }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showHuffs == false) showHuffs = true;
            else showHuffs = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (showQuant == false) showQuant = true;
            else showQuant = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (showDescrete == false) showDescrete = true;
            else showDescrete = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (showYCbCr == false) showYCbCr = true;
            else showYCbCr = false;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (showRGB == false) showRGB = true;
            else showRGB = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }
       
    }
}
