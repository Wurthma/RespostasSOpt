using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resposta_359680
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RenderizarPDF(@"C:\Users\ge_h_\Google Drive\Sockets e processadores.pdf");
        }

        private void RenderizarPDF(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                webBrowser1.Navigate(@filePath);
            }
        }
    }
}
