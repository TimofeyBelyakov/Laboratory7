using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonRun
{
    public partial class FormButtonRun : Form
    {
        float koeffX, koeffY;

        public FormButtonRun()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Обработка нажатия кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Поздравляем! Вы смогли нажать на кнопку!") == DialogResult.OK)
            {
                button.Location = new Point(
                    Size.Width / 2 - button.Size.Width / 2,
                    Size.Height / 2 - button.Size.Height / 2
                );
                koeffX = (float)(button.Location.X) / (float)(Size.Width);
                koeffY = (float)(button.Location.Y) / (float)(Size.Height);
            }
        }

        /// <summary>
        ///     Обработка движения мыши по форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            int btnLocationX = button.Location.X,
                btnLocationY = button.Location.Y,
                btnWidth = button.Size.Width,
                btnHeight = button.Size.Height,
                formWidth = Size.Width,
                formHeight = Size.Height;
            // Позиция указателя
            Point pointer = new Point(e.X, e.Y);
            // Позиция центра кнопки
            Point centerBtn = new Point(
                    btnLocationX + btnWidth / 2,
                    btnLocationY + btnHeight / 2
                );
            // Расстояния от центра кнопки до указателя
            int distanceX = pointer.X - centerBtn.X;
            int distanceY = pointer.Y - centerBtn.Y;

            if (Math.Abs(distanceX) <= btnWidth * 1.5 && 
                Math.Abs(distanceY) <= btnHeight * 1.5)
            {
                button.Location = new Point(
                    btnLocationX - distanceX / 15,
                    btnLocationY - distanceY / 15
                );
                if (btnLocationX < 0)
                    button.Location = new Point(0, btnLocationY);
                if (btnLocationX > formWidth - btnWidth)
                    button.Location = new Point(formWidth - btnWidth, btnLocationY);
                if (btnLocationY < 0)
                    button.Location = new Point(btnLocationX, 0);
                if (btnLocationY > formHeight - 2 * btnHeight)
                    button.Location = new Point(btnLocationX, formHeight - 2 * btnHeight);
            }

            //firstPos = pointer;
            koeffX = (float)(btnLocationX) / (float)(formWidth);
            koeffY = (float)(btnLocationY) / (float)(formHeight);
        }

        /// <summary>
        ///     Обработка загрузки формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            // Позиционирование кнопки посередине
            button.Location = new Point(
                    Size.Width / 2 - button.Size.Width / 2,
                    Size.Height / 2 - button.Size.Height / 2
                );
            koeffX = (float)(button.Location.X) / (float)(Size.Width);
            koeffY = (float)(button.Location.Y) / (float)(Size.Height);
        }
      
        /// <summary>
        ///     Обработка изменения размеров формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_SizeChanged(object sender, EventArgs e)
        {
            int btnLocationX = button.Location.X,
                btnLocationY = button.Location.Y,
                btnWidth = button.Size.Width,
                btnHeight = button.Size.Height,
                formWidth = Size.Width,
                formHeight = Size.Height;
            button.Location = new Point(
                    (int)(formWidth * koeffX),
                    (int)(formHeight * koeffY)
                );
            if (btnLocationX < 0)
                button.Location = new Point(0, btnLocationY);
            if (btnLocationX >= formWidth - btnWidth)
                button.Location = new Point(formWidth - btnWidth, btnLocationY);
            if (btnLocationY < 0)
                button.Location = new Point(btnLocationX, 0);
            if (btnLocationY > formHeight - 2 * btnHeight)
                button.Location = new Point(btnLocationX, formHeight - 2 * btnHeight);
        }
    }
}
