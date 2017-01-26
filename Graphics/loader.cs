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
    public partial class loader : Form
    {
        public loader()
        {
            InitializeComponent();
        }

        public void progress(int value)
        {
            progressBar1.Value = value;
        }
    }
}
