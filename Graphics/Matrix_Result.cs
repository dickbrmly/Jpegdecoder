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
    public partial class Matrix_Result : Form
    {
        public Matrix_Result(string title, int[,] matrix)
        {
            InitializeComponent();
            matrixTitle.Text = title;

            X0Y0.Text = matrix[0, 0].ToString(); X1Y0.Text = matrix[1, 0].ToString(); X2Y0.Text = matrix[2, 0].ToString(); X3Y0.Text = matrix[3, 0].ToString();
            X4Y0.Text = matrix[4, 0].ToString(); X5Y0.Text = matrix[5, 0].ToString(); X6Y0.Text = matrix[6, 0].ToString(); X7Y0.Text = matrix[7, 0].ToString();

            X0Y1.Text = matrix[0, 1].ToString(); X1Y1.Text = matrix[1, 1].ToString(); X2Y1.Text = matrix[2, 1].ToString(); X3Y1.Text = matrix[3, 1].ToString();
            X4Y1.Text = matrix[4, 1].ToString(); X5Y1.Text = matrix[5, 1].ToString(); X6Y1.Text = matrix[6, 1].ToString(); X7Y1.Text = matrix[7, 1].ToString();

            X0Y2.Text = matrix[0, 2].ToString(); X1Y2.Text = matrix[1, 2].ToString(); X2Y2.Text = matrix[2, 2].ToString(); X3Y2.Text = matrix[3, 2].ToString();
            X4Y2.Text = matrix[4, 2].ToString(); X5Y2.Text = matrix[5, 2].ToString(); X6Y2.Text = matrix[6, 2].ToString(); X7Y2.Text = matrix[7, 2].ToString();

            X0Y3.Text = matrix[0, 3].ToString(); X1Y3.Text = matrix[1, 3].ToString(); X2Y3.Text = matrix[2, 3].ToString(); X3Y3.Text = matrix[3, 3].ToString();
            X4Y3.Text = matrix[4, 3].ToString(); X5Y3.Text = matrix[5, 3].ToString(); X6Y3.Text = matrix[6, 3].ToString(); X7Y3.Text = matrix[7, 3].ToString();

            X0Y4.Text = matrix[0, 4].ToString(); X1Y4.Text = matrix[1, 4].ToString(); X2Y4.Text = matrix[2, 4].ToString(); X3Y4.Text = matrix[3, 4].ToString();
            X4Y4.Text = matrix[4, 4].ToString(); X5Y4.Text = matrix[5, 4].ToString(); X6Y4.Text = matrix[6, 4].ToString(); X7Y4.Text = matrix[7, 4].ToString();

            X0Y5.Text = matrix[0, 5].ToString(); X1Y5.Text = matrix[1, 5].ToString(); X2Y5.Text = matrix[2, 5].ToString(); X3Y5.Text = matrix[3, 5].ToString();
            X4Y5.Text = matrix[4, 5].ToString(); X5Y5.Text = matrix[5, 5].ToString(); X6Y5.Text = matrix[6, 5].ToString(); X7Y5.Text = matrix[7, 5].ToString();

            X0Y6.Text = matrix[0, 6].ToString(); X1Y6.Text = matrix[1, 6].ToString(); X2Y6.Text = matrix[2, 6].ToString(); X3Y6.Text = matrix[3, 6].ToString();
            X4Y6.Text = matrix[4, 6].ToString(); X5Y6.Text = matrix[5, 6].ToString(); X6Y6.Text = matrix[6, 6].ToString(); X7Y6.Text = matrix[7, 6].ToString();

            X0Y7.Text = matrix[0, 7].ToString(); X1Y7.Text = matrix[1, 7].ToString(); X2Y7.Text = matrix[2, 7].ToString(); X3Y7.Text = matrix[3, 7].ToString();
            X4Y7.Text = matrix[4, 7].ToString(); X5Y7.Text = matrix[5, 7].ToString(); X6Y7.Text = matrix[6, 7].ToString(); X7Y7.Text = matrix[7, 7].ToString();
        }
        public Matrix_Result(string title, byte[,] matrix)
        {
            InitializeComponent();
            matrixTitle.Text = title;

            X0Y0.Text = matrix[0, 0].ToString("X"); X1Y0.Text = matrix[1, 0].ToString("X"); X2Y0.Text = matrix[2, 0].ToString("X"); X3Y0.Text = matrix[3, 0].ToString("X");
            X4Y0.Text = matrix[4, 0].ToString("X"); X5Y0.Text = matrix[5, 0].ToString("X"); X6Y0.Text = matrix[6, 0].ToString("X"); X7Y0.Text = matrix[7, 0].ToString("X");

            X0Y1.Text = matrix[0, 1].ToString("X"); X1Y1.Text = matrix[1, 1].ToString("X"); X2Y1.Text = matrix[2, 1].ToString("X"); X3Y1.Text = matrix[3, 1].ToString("X");
            X4Y1.Text = matrix[4, 1].ToString("X"); X5Y1.Text = matrix[5, 1].ToString("X"); X6Y1.Text = matrix[6, 1].ToString("X"); X7Y1.Text = matrix[7, 1].ToString("X");

            X0Y2.Text = matrix[0, 2].ToString("X"); X1Y2.Text = matrix[1, 2].ToString("X"); X2Y2.Text = matrix[2, 2].ToString("X"); X3Y2.Text = matrix[3, 2].ToString("X");
            X4Y2.Text = matrix[4, 2].ToString("X"); X5Y2.Text = matrix[5, 2].ToString("X"); X6Y2.Text = matrix[6, 2].ToString("X"); X7Y2.Text = matrix[7, 2].ToString("X");

            X0Y3.Text = matrix[0, 3].ToString("X"); X1Y3.Text = matrix[1, 3].ToString("X"); X2Y3.Text = matrix[2, 3].ToString("X"); X3Y3.Text = matrix[3, 3].ToString("X");
            X4Y3.Text = matrix[4, 3].ToString("X"); X5Y3.Text = matrix[5, 3].ToString("X"); X6Y3.Text = matrix[6, 3].ToString("X"); X7Y3.Text = matrix[7, 3].ToString("X");

            X0Y4.Text = matrix[0, 4].ToString("X"); X1Y4.Text = matrix[1, 4].ToString("X"); X2Y4.Text = matrix[2, 4].ToString("X"); X3Y4.Text = matrix[3, 4].ToString("X");
            X4Y4.Text = matrix[4, 4].ToString("X"); X5Y4.Text = matrix[5, 4].ToString("X"); X6Y4.Text = matrix[6, 4].ToString("X"); X7Y4.Text = matrix[7, 4].ToString("X");

            X0Y5.Text = matrix[0, 5].ToString("X"); X1Y5.Text = matrix[1, 5].ToString("X"); X2Y5.Text = matrix[2, 5].ToString("X"); X3Y5.Text = matrix[3, 5].ToString("X");
            X4Y5.Text = matrix[4, 5].ToString("X"); X5Y5.Text = matrix[5, 5].ToString("X"); X6Y5.Text = matrix[6, 5].ToString("X"); X7Y5.Text = matrix[7, 5].ToString("X");

            X0Y6.Text = matrix[0, 6].ToString("X"); X1Y6.Text = matrix[1, 6].ToString("X"); X2Y6.Text = matrix[2, 6].ToString("X"); X3Y6.Text = matrix[3, 6].ToString("X");
            X4Y6.Text = matrix[4, 6].ToString("X"); X5Y6.Text = matrix[5, 6].ToString("X"); X6Y6.Text = matrix[6, 6].ToString("X"); X7Y6.Text = matrix[7, 6].ToString("X");

            X0Y7.Text = matrix[0, 7].ToString("X"); X1Y7.Text = matrix[1, 7].ToString("X"); X2Y7.Text = matrix[2, 7].ToString("X"); X3Y7.Text = matrix[3, 7].ToString("X");
            X4Y7.Text = matrix[4, 7].ToString("X"); X5Y7.Text = matrix[5, 7].ToString("X"); X6Y7.Text = matrix[6, 7].ToString("X"); X7Y7.Text = matrix[7, 7].ToString("X");
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
