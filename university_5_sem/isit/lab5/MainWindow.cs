using System;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace lab5
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCustomComponent();
        }

        private void input_number_Enter(object sender, EventArgs e)
        {
            if (input_number.Text == placeholder_text)
            {
                input_number.Text = "";
                input_number.ForeColor = Color.Black;
            }
        }

        private void input_number_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(input_number.Text.Trim()))
            {
                input_number.Text = placeholder_text;
                input_number.ForeColor = Color.Gray;
            }
        }

        private void check3_btn_Click(object sender, EventArgs e)
        {
            Int32 number;
            if (!Int32.TryParse(input_number.Text, out number))
            {
                MessageBox.Show("Неправильный ввод!");
                return;
            }
            MessageBox.Show(number % 3 == 0 ? "Число делится на 3" : "Число не делится на 3");
        }

        private void changeColor(string color, ref byte red, ref byte green, ref byte blue)
        {
            switch (color)
            {
                case "Красный":
                    red = 0xFF;
                    break;
                case "Оранжевый":
                    red = 0xFF;
                    green |= 127;
                    break;
                case "Желтый":
                    red = 0xFF;
                    green = 0xFF;
                    break;
                case "Зеленый":
                    green = 0xFF;
                    break;
                case "Голубой":
                    green |= 0xBF;
                    blue = 0xFF;
                    break;
                case "Синий":
                    blue = 0xFF;
                    break;
                case "Фиолетовый":
                    red |= 42;
                    green |= 31;
                    blue |= 89;
                    break;
            }
        }

        private void list_box_color_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            byte red = 0, green = 0, blue = 0;
            if (e.NewValue == CheckState.Checked)  // текущий объект не добавляется в list_box_color.CheckedItems, поэтому если он нажат, надо его добавить дополнительно
            {
                changeColor(list_box_color.Items[e.Index].ToString(), ref red, ref green, ref blue);
            }
            foreach (string color in list_box_color.CheckedItems)
            {
                if (color != list_box_color.Items[e.Index].ToString())  // также этот метод реагирует на Unchecked, поэтому в этот момент нужно пропустить добавление этого элемента
                    changeColor(color, ref red, ref green, ref blue);
            }

            color_panel.BackColor = Color.FromArgb(red, green, blue);
        }

        private void clicker_btn_Click(object sender, EventArgs e)
        {
            ++n_clicks;
        }

        private void count_btn_Click(object sender, EventArgs e)
        {
            chart1.Series["Количество кликов"].Points.Add(n_clicks, n_step++);
            n_clicks = 0;
        }

        private string placeholder_text = "Введите целое число:";
        private UInt32 n_clicks = 0;
        private UInt32 n_step = 1;

        private void calc_btn_digit_Click(object sender, EventArgs e)
        {
            Button clicked_btn = sender as Button;
            if (clicked_btn != null)
            {
                var digit = clicked_btn.Text;
                if (digit == "0" && String.IsNullOrEmpty(calc_input_box.Text))
                    return;
                calc_input_box.Text += clicked_btn.Text;
            }
        }

        private void calc_btn_del_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(calc_input_box.Text))
                calc_input_box.Text = calc_input_box.Text.Substring(0, calc_input_box.Text.Length - 1);
        }

        private void calc_btn_clear_Click(object sender, EventArgs e)
        {
            calc_input_box.Text = "";
        }

        private void calc_btn_eq_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(calc_input_box.Text) || "/*-+^".Contains(calc_input_box.Text[calc_input_box.Text.Length - 1]))
                return;

            string pattern = @"(-?\d+(?:\.\d+)?)\^(-?\d+(?:\.\d+)?)";
            string replacement = "Pow($1, $2)";
            string prepared = Regex.Replace(calc_input_box.Text, pattern, replacement);

            var expr = new NCalc.Expression(prepared).Evaluate();
            calc_input_box.Text = expr.ToString();
        }

        private void calc_btn_ops_Click(object sender, EventArgs e)
        {
            Button clicked_btn = sender as Button;
            if (clicked_btn == null || String.IsNullOrEmpty(calc_input_box.Text) || "/*-+^".Contains(calc_input_box.Text[calc_input_box.Text.Length - 1]))
                return;
            calc_input_box.Text += clicked_btn.Text;
        }

        private void calc_btn_min_Click(object sender, EventArgs e)
        {
            Button clicked_btn = sender as Button;
            if (clicked_btn == null || (!String.IsNullOrEmpty(calc_input_box.Text) && calc_input_box.Text[calc_input_box.Text.Length - 1] == '-'))
                return;
            calc_input_box.Text += clicked_btn.Text;
        }
    }
}
