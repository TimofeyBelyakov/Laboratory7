using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorApp
{
    public partial class Form1 : Form
    {
        string strColor = "";
        Color color;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Обработка загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            trackBar1.Value = 125;
            trackBar2.Value = 125;
            trackBar3.Value = 125;

            SetBackColor();
        }

        /// <summary>
        ///     Обработка изменения TrackBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valueTrackBar(object sender, EventArgs e)
        {
            SetBackColor();
            strColor = "#" + Convert.ToString(color.R, 16) + Convert.ToString(color.G, 16) + Convert.ToString(color.B, 16);
            Clipboard.SetText(strColor);
            toolTip.SetToolTip(pictureBox1, strColor);
        }

        /// <summary>
        ///     Задаёт цвет полотна
        /// </summary>
        /// <param name="col1"></param>
        /// <param name="col2"></param>
        /// <param name="col3"></param>
        private void SetBackColor()
        {
            color = Color.FromArgb(
                    trackBar1.Value,
                    trackBar2.Value,
                    trackBar3.Value
                );
            pictureBox1.BackColor = color;
        }
    }
}
