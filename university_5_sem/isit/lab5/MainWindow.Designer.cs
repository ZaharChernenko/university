using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace lab5
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tab_control = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.check3_btn = new System.Windows.Forms.Button();
            this.input_number = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.list_box_color = new System.Windows.Forms.CheckedListBox();
            this.color_panel = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.count_btn = new System.Windows.Forms.Button();
            this.clicker_btn = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.calc_btn0 = new System.Windows.Forms.Button();
            this.calc_btn_del = new System.Windows.Forms.Button();
            this.calc_btn_clear = new System.Windows.Forms.Button();
            this.calc_btn_eq = new System.Windows.Forms.Button();
            this.calc_btn_pow = new System.Windows.Forms.Button();
            this.calc_btn_plus = new System.Windows.Forms.Button();
            this.calc_btn_min = new System.Windows.Forms.Button();
            this.calc_btn_mul = new System.Windows.Forms.Button();
            this.calc_btn_div = new System.Windows.Forms.Button();
            this.calc_btn5 = new System.Windows.Forms.Button();
            this.calc_btn9 = new System.Windows.Forms.Button();
            this.calc_btn8 = new System.Windows.Forms.Button();
            this.calc_btn4 = new System.Windows.Forms.Button();
            this.calc_btn6 = new System.Windows.Forms.Button();
            this.calc_btn7 = new System.Windows.Forms.Button();
            this.calc_btn1 = new System.Windows.Forms.Button();
            this.calc_btn2 = new System.Windows.Forms.Button();
            this.calc_input_box = new System.Windows.Forms.TextBox();
            this.calc_btn3 = new System.Windows.Forms.Button();
            this.tab_control.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_control
            // 
            this.tab_control.Controls.Add(this.tabPage1);
            this.tab_control.Controls.Add(this.tabPage2);
            this.tab_control.Controls.Add(this.tabPage3);
            this.tab_control.Controls.Add(this.tabPage4);
            this.tab_control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_control.Location = new System.Drawing.Point(0, 0);
            this.tab_control.Name = "tab_control";
            this.tab_control.SelectedIndex = 0;
            this.tab_control.Size = new System.Drawing.Size(622, 438);
            this.tab_control.TabIndex = 0;
            this.tab_control.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.check3_btn);
            this.tabPage1.Controls.Add(this.input_number);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(614, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Проверка делимости на 3";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // check3_btn
            // 
            this.check3_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.check3_btn.Location = new System.Drawing.Point(3, 362);
            this.check3_btn.Name = "check3_btn";
            this.check3_btn.Size = new System.Drawing.Size(608, 47);
            this.check3_btn.TabIndex = 1;
            this.check3_btn.Text = "Проверить";
            this.check3_btn.UseVisualStyleBackColor = true;
            this.check3_btn.Click += new System.EventHandler(this.check3_btn_Click);
            // 
            // input_number
            // 
            this.input_number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input_number.ForeColor = System.Drawing.Color.Gray;
            this.input_number.Location = new System.Drawing.Point(3, 3);
            this.input_number.Margin = new System.Windows.Forms.Padding(10);
            this.input_number.Name = "input_number";
            this.input_number.Size = new System.Drawing.Size(608, 20);
            this.input_number.TabIndex = 0;
            this.input_number.Enter += new System.EventHandler(this.input_number_Enter);
            this.input_number.Leave += new System.EventHandler(this.input_number_Leave);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.list_box_color);
            this.tabPage2.Controls.Add(this.color_panel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(614, 412);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Палитра";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // list_box_color
            // 
            this.list_box_color.CheckOnClick = true;
            this.list_box_color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_box_color.FormattingEnabled = true;
            this.list_box_color.Items.AddRange(new object[] {
            "Красный",
            "Оранжевый",
            "Желтый",
            "Зеленый",
            "Голубой",
            "Синий",
            "Фиолетовый"});
            this.list_box_color.Location = new System.Drawing.Point(3, 3);
            this.list_box_color.Name = "list_box_color";
            this.list_box_color.Size = new System.Drawing.Size(408, 406);
            this.list_box_color.TabIndex = 1;
            this.list_box_color.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.list_box_color_ItemCheck);
            // 
            // color_panel
            // 
            this.color_panel.BackColor = System.Drawing.Color.Black;
            this.color_panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.color_panel.Location = new System.Drawing.Point(411, 3);
            this.color_panel.Name = "color_panel";
            this.color_panel.Size = new System.Drawing.Size(200, 406);
            this.color_panel.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chart1);
            this.tabPage3.Controls.Add(this.count_btn);
            this.tabPage3.Controls.Add(this.clicker_btn);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(614, 412);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Кликер";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 26);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Количество кликов";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(608, 360);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // count_btn
            // 
            this.count_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.count_btn.Location = new System.Drawing.Point(3, 386);
            this.count_btn.Name = "count_btn";
            this.count_btn.Size = new System.Drawing.Size(608, 23);
            this.count_btn.TabIndex = 1;
            this.count_btn.Text = "Записать результат";
            this.count_btn.UseVisualStyleBackColor = true;
            this.count_btn.Click += new System.EventHandler(this.count_btn_Click);
            // 
            // clicker_btn
            // 
            this.clicker_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.clicker_btn.Location = new System.Drawing.Point(3, 3);
            this.clicker_btn.Name = "clicker_btn";
            this.clicker_btn.Size = new System.Drawing.Size(608, 23);
            this.clicker_btn.TabIndex = 0;
            this.clicker_btn.Text = "Нажми меня";
            this.clicker_btn.UseVisualStyleBackColor = true;
            this.clicker_btn.Click += new System.EventHandler(this.clicker_btn_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.calc_btn0);
            this.tabPage4.Controls.Add(this.calc_btn_del);
            this.tabPage4.Controls.Add(this.calc_btn_clear);
            this.tabPage4.Controls.Add(this.calc_btn_eq);
            this.tabPage4.Controls.Add(this.calc_btn_pow);
            this.tabPage4.Controls.Add(this.calc_btn_plus);
            this.tabPage4.Controls.Add(this.calc_btn_min);
            this.tabPage4.Controls.Add(this.calc_btn_mul);
            this.tabPage4.Controls.Add(this.calc_btn_div);
            this.tabPage4.Controls.Add(this.calc_btn5);
            this.tabPage4.Controls.Add(this.calc_btn9);
            this.tabPage4.Controls.Add(this.calc_btn8);
            this.tabPage4.Controls.Add(this.calc_btn4);
            this.tabPage4.Controls.Add(this.calc_btn6);
            this.tabPage4.Controls.Add(this.calc_btn7);
            this.tabPage4.Controls.Add(this.calc_btn1);
            this.tabPage4.Controls.Add(this.calc_btn2);
            this.tabPage4.Controls.Add(this.calc_input_box);
            this.tabPage4.Controls.Add(this.calc_btn3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(614, 412);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Калькулятор";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // calc_btn0
            // 
            this.calc_btn0.BackColor = System.Drawing.Color.Black;
            this.calc_btn0.ForeColor = System.Drawing.Color.White;
            this.calc_btn0.Location = new System.Drawing.Point(6, 332);
            this.calc_btn0.Name = "calc_btn0";
            this.calc_btn0.Size = new System.Drawing.Size(70, 70);
            this.calc_btn0.TabIndex = 18;
            this.calc_btn0.Text = "0";
            this.calc_btn0.UseVisualStyleBackColor = false;
            this.calc_btn0.Click += new System.EventHandler(this.calc_btn_digit_Click);
            // 
            // calc_btn_del
            // 
            this.calc_btn_del.BackColor = System.Drawing.Color.IndianRed;
            this.calc_btn_del.Location = new System.Drawing.Point(6, 29);
            this.calc_btn_del.Name = "calc_btn_del";
            this.calc_btn_del.Size = new System.Drawing.Size(70, 70);
            this.calc_btn_del.TabIndex = 17;
            this.calc_btn_del.Text = "Del";
            this.calc_btn_del.UseVisualStyleBackColor = false;
            this.calc_btn_del.Click += new System.EventHandler(this.calc_btn_del_Click);
            // 
            // calc_btn_clear
            // 
            this.calc_btn_clear.BackColor = System.Drawing.Color.IndianRed;
            this.calc_btn_clear.Location = new System.Drawing.Point(82, 29);
            this.calc_btn_clear.Name = "calc_btn_clear";
            this.calc_btn_clear.Size = new System.Drawing.Size(70, 70);
            this.calc_btn_clear.TabIndex = 16;
            this.calc_btn_clear.Text = "C";
            this.calc_btn_clear.UseVisualStyleBackColor = false;
            this.calc_btn_clear.Click += new System.EventHandler(this.calc_btn_clear_Click);
            // 
            // calc_btn_eq
            // 
            this.calc_btn_eq.BackColor = System.Drawing.Color.LightSalmon;
            this.calc_btn_eq.Location = new System.Drawing.Point(82, 332);
            this.calc_btn_eq.Name = "calc_btn_eq";
            this.calc_btn_eq.Size = new System.Drawing.Size(146, 70);
            this.calc_btn_eq.TabIndex = 15;
            this.calc_btn_eq.Text = "=";
            this.calc_btn_eq.UseVisualStyleBackColor = false;
            this.calc_btn_eq.Click += new System.EventHandler(this.calc_btn_eq_Click);
            // 
            // calc_btn_pow
            // 
            this.calc_btn_pow.BackColor = System.Drawing.Color.LightSalmon;
            this.calc_btn_pow.Location = new System.Drawing.Point(234, 29);
            this.calc_btn_pow.Name = "calc_btn_pow";
            this.calc_btn_pow.Size = new System.Drawing.Size(70, 70);
            this.calc_btn_pow.TabIndex = 14;
            this.calc_btn_pow.Text = "^";
            this.calc_btn_pow.UseVisualStyleBackColor = false;
            this.calc_btn_pow.Click += new System.EventHandler(this.calc_btn_ops_Click);
            // 
            // calc_btn_plus
            // 
            this.calc_btn_plus.BackColor = System.Drawing.Color.LightSalmon;
            this.calc_btn_plus.Location = new System.Drawing.Point(234, 332);
            this.calc_btn_plus.Name = "calc_btn_plus";
            this.calc_btn_plus.Size = new System.Drawing.Size(70, 70);
            this.calc_btn_plus.TabIndex = 13;
            this.calc_btn_plus.Text = "+";
            this.calc_btn_plus.UseVisualStyleBackColor = false;
            this.calc_btn_plus.Click += new System.EventHandler(this.calc_btn_ops_Click);
            // 
            // calc_btn_min
            // 
            this.calc_btn_min.BackColor = System.Drawing.Color.LightSalmon;
            this.calc_btn_min.Location = new System.Drawing.Point(234, 256);
            this.calc_btn_min.Name = "calc_btn_min";
            this.calc_btn_min.Size = new System.Drawing.Size(70, 70);
            this.calc_btn_min.TabIndex = 12;
            this.calc_btn_min.Text = "-";
            this.calc_btn_min.UseVisualStyleBackColor = false;
            this.calc_btn_min.Click += new System.EventHandler(this.calc_btn_min_Click);
            // 
            // calc_btn_mul
            // 
            this.calc_btn_mul.BackColor = System.Drawing.Color.LightSalmon;
            this.calc_btn_mul.Location = new System.Drawing.Point(234, 180);
            this.calc_btn_mul.Name = "calc_btn_mul";
            this.calc_btn_mul.Size = new System.Drawing.Size(70, 70);
            this.calc_btn_mul.TabIndex = 11;
            this.calc_btn_mul.Text = "*";
            this.calc_btn_mul.UseVisualStyleBackColor = false;
            this.calc_btn_mul.Click += new System.EventHandler(this.calc_btn_ops_Click);
            // 
            // calc_btn_div
            // 
            this.calc_btn_div.BackColor = System.Drawing.Color.LightSalmon;
            this.calc_btn_div.Location = new System.Drawing.Point(234, 105);
            this.calc_btn_div.Name = "calc_btn_div";
            this.calc_btn_div.Size = new System.Drawing.Size(70, 70);
            this.calc_btn_div.TabIndex = 10;
            this.calc_btn_div.Text = "/";
            this.calc_btn_div.UseVisualStyleBackColor = false;
            this.calc_btn_div.Click += new System.EventHandler(this.calc_btn_ops_Click);
            // 
            // calc_btn5
            // 
            this.calc_btn5.BackColor = System.Drawing.Color.Black;
            this.calc_btn5.ForeColor = System.Drawing.Color.White;
            this.calc_btn5.Location = new System.Drawing.Point(82, 181);
            this.calc_btn5.Name = "calc_btn5";
            this.calc_btn5.Size = new System.Drawing.Size(70, 70);
            this.calc_btn5.TabIndex = 9;
            this.calc_btn5.Text = "5";
            this.calc_btn5.UseVisualStyleBackColor = false;
            this.calc_btn5.Click += new System.EventHandler(this.calc_btn_digit_Click);
            // 
            // calc_btn9
            // 
            this.calc_btn9.BackColor = System.Drawing.Color.Black;
            this.calc_btn9.ForeColor = System.Drawing.Color.White;
            this.calc_btn9.Location = new System.Drawing.Point(158, 105);
            this.calc_btn9.Name = "calc_btn9";
            this.calc_btn9.Size = new System.Drawing.Size(70, 70);
            this.calc_btn9.TabIndex = 8;
            this.calc_btn9.Text = "9";
            this.calc_btn9.UseVisualStyleBackColor = false;
            this.calc_btn9.Click += new System.EventHandler(this.calc_btn_digit_Click);
            // 
            // calc_btn8
            // 
            this.calc_btn8.BackColor = System.Drawing.Color.Black;
            this.calc_btn8.ForeColor = System.Drawing.Color.White;
            this.calc_btn8.Location = new System.Drawing.Point(82, 105);
            this.calc_btn8.Name = "calc_btn8";
            this.calc_btn8.Size = new System.Drawing.Size(70, 70);
            this.calc_btn8.TabIndex = 7;
            this.calc_btn8.Text = "8";
            this.calc_btn8.UseVisualStyleBackColor = false;
            this.calc_btn8.Click += new System.EventHandler(this.calc_btn_digit_Click);
            // 
            // calc_btn4
            // 
            this.calc_btn4.BackColor = System.Drawing.Color.Black;
            this.calc_btn4.ForeColor = System.Drawing.Color.White;
            this.calc_btn4.Location = new System.Drawing.Point(6, 181);
            this.calc_btn4.Name = "calc_btn4";
            this.calc_btn4.Size = new System.Drawing.Size(70, 70);
            this.calc_btn4.TabIndex = 6;
            this.calc_btn4.Text = "4";
            this.calc_btn4.UseVisualStyleBackColor = false;
            this.calc_btn4.Click += new System.EventHandler(this.calc_btn_digit_Click);
            // 
            // calc_btn6
            // 
            this.calc_btn6.BackColor = System.Drawing.Color.Black;
            this.calc_btn6.ForeColor = System.Drawing.Color.White;
            this.calc_btn6.Location = new System.Drawing.Point(158, 181);
            this.calc_btn6.Name = "calc_btn6";
            this.calc_btn6.Size = new System.Drawing.Size(70, 70);
            this.calc_btn6.TabIndex = 5;
            this.calc_btn6.Text = "6";
            this.calc_btn6.UseVisualStyleBackColor = false;
            this.calc_btn6.Click += new System.EventHandler(this.calc_btn_digit_Click);
            // 
            // calc_btn7
            // 
            this.calc_btn7.BackColor = System.Drawing.Color.Black;
            this.calc_btn7.ForeColor = System.Drawing.Color.White;
            this.calc_btn7.Location = new System.Drawing.Point(6, 105);
            this.calc_btn7.Name = "calc_btn7";
            this.calc_btn7.Size = new System.Drawing.Size(70, 70);
            this.calc_btn7.TabIndex = 4;
            this.calc_btn7.Text = "7";
            this.calc_btn7.UseVisualStyleBackColor = false;
            this.calc_btn7.Click += new System.EventHandler(this.calc_btn_digit_Click);
            // 
            // calc_btn1
            // 
            this.calc_btn1.BackColor = System.Drawing.Color.Black;
            this.calc_btn1.ForeColor = System.Drawing.Color.White;
            this.calc_btn1.Location = new System.Drawing.Point(6, 256);
            this.calc_btn1.Name = "calc_btn1";
            this.calc_btn1.Size = new System.Drawing.Size(70, 70);
            this.calc_btn1.TabIndex = 3;
            this.calc_btn1.Text = "1";
            this.calc_btn1.UseVisualStyleBackColor = false;
            this.calc_btn1.Click += new System.EventHandler(this.calc_btn_digit_Click);
            // 
            // calc_btn2
            // 
            this.calc_btn2.BackColor = System.Drawing.Color.Black;
            this.calc_btn2.ForeColor = System.Drawing.Color.White;
            this.calc_btn2.Location = new System.Drawing.Point(82, 257);
            this.calc_btn2.Name = "calc_btn2";
            this.calc_btn2.Size = new System.Drawing.Size(70, 70);
            this.calc_btn2.TabIndex = 2;
            this.calc_btn2.Text = "2";
            this.calc_btn2.UseVisualStyleBackColor = false;
            this.calc_btn2.Click += new System.EventHandler(this.calc_btn_digit_Click);
            // 
            // calc_input_box
            // 
            this.calc_input_box.Dock = System.Windows.Forms.DockStyle.Top;
            this.calc_input_box.Location = new System.Drawing.Point(3, 3);
            this.calc_input_box.Name = "calc_input_box";
            this.calc_input_box.ReadOnly = true;
            this.calc_input_box.Size = new System.Drawing.Size(608, 20);
            this.calc_input_box.TabIndex = 1;
            // 
            // calc_btn3
            // 
            this.calc_btn3.BackColor = System.Drawing.Color.Black;
            this.calc_btn3.ForeColor = System.Drawing.Color.White;
            this.calc_btn3.Location = new System.Drawing.Point(158, 257);
            this.calc_btn3.Name = "calc_btn3";
            this.calc_btn3.Size = new System.Drawing.Size(70, 70);
            this.calc_btn3.TabIndex = 0;
            this.calc_btn3.Text = "3";
            this.calc_btn3.UseVisualStyleBackColor = false;
            this.calc_btn3.Click += new System.EventHandler(this.calc_btn_digit_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 438);
            this.Controls.Add(this.tab_control);
            this.Name = "MainWindow";
            this.Text = "lab5";
            this.tab_control.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void InitializeCustomComponent()
        {
            this.input_number.Text = placeholder_text;
        }

        private System.Windows.Forms.TabControl tab_control;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox input_number;
        private System.Windows.Forms.Button check3_btn;
        private System.Windows.Forms.CheckedListBox list_box_color;
        private System.Windows.Forms.Panel color_panel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button count_btn;
        private System.Windows.Forms.Button clicker_btn;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataVisualization.Charting.Series series1;
        private System.Windows.Forms.Button calc_btn_div;
        private System.Windows.Forms.Button calc_btn5;
        private System.Windows.Forms.Button calc_btn9;
        private System.Windows.Forms.Button calc_btn8;
        private System.Windows.Forms.Button calc_btn4;
        private System.Windows.Forms.Button calc_btn6;
        private System.Windows.Forms.Button calc_btn7;
        private System.Windows.Forms.Button calc_btn1;
        private System.Windows.Forms.Button calc_btn2;
        private System.Windows.Forms.TextBox calc_input_box;
        private System.Windows.Forms.Button calc_btn3;
        private System.Windows.Forms.Button calc_btn_plus;
        private System.Windows.Forms.Button calc_btn_min;
        private System.Windows.Forms.Button calc_btn_mul;
        private System.Windows.Forms.Button calc_btn0;
        private System.Windows.Forms.Button calc_btn_del;
        private System.Windows.Forms.Button calc_btn_clear;
        private System.Windows.Forms.Button calc_btn_eq;
        private System.Windows.Forms.Button calc_btn_pow;
    }
}

