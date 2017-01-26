using System;
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
    public partial class HuffmanTable : Form
    {
        public HuffmanTable(string title,huffman[] table)
        {
            InitializeComponent();
            huffmanTitle.Text = title;
            for (int x = 0; x < 255; x++)
             richTextBox1.Text += x.ToString("000") + "      " + table[x].count.ToString("00") + "     " + table[x].code.ToString("X5") + "       " + table[x].outcome.ToString("X4") + "\n";

                
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
