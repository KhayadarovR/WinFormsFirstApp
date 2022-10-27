using System.Windows.Forms;
using System.Drawing;
using System;
using System.Diagnostics;
using System.Threading;

namespace WinFormsApp
{
    partial class Form1: Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            var label = new Label {
                Location = new Point(ClientSize.Width/2, 0),
                Size = new Size(ClientSize.Width, 40),
                Text = "Ниче минуттансон пк ны сундерим? \n в минутах"
            };
            var input = new TextBox {
                Location = new Point(0, label.Bottom),
                Size = new Size(100, 100),
                
            };
            var button = new Button {
                Location = new Point(0, input.Bottom),
                Size = label.Size,
                Text = "Сундерге куярга:)",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Red,
            };
            var buttonCancel = new Button {
                Location = new Point(0, button.Bottom),
                Size = label.Size,
                Text = "Ой отменяю отменяю!!!",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.LightGreen,
            };
            Controls.Add(label);
            Controls.Add(input);
            Controls.Add(button);
            Controls.Add(buttonCancel);
            
            //Обработка изминения размера окна
            SizeChanged += (sender, args) =>
            {
                var height = 100;

                label.Location = new Point(0, (ClientSize.Height - height * 3) / 2);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Size = new Size(ClientSize.Width, height);
                input.Location = new Point(0, label.Bottom);
                input.Size = label.Size;
                input.TextAlign = HorizontalAlignment.Center;

                button.Location = new Point(0, input.Bottom);
                button.Size = label.Size / 2;
                buttonCancel.Location = new Point(button.Location.X + button.Size.Width, button.Location.Y);
                buttonCancel.Size = label.Size / 2;
            };

            CursorChanged += (s, a) => {
                input.PlaceholderText = "10";
            };

            //Обработка нажатия
            button.Click += (s, a) => {
                int.TryParse(input.Text, out int TimeInMin);
                if (TimeInMin > 0)
                {
                    var TimeInSec = TimeInMin * 60;
                    var psi = new ProcessStartInfo("shutdown", $"/s /t {TimeInSec}");
                    psi.CreateNoWindow = true;
                    psi.UseShellExecute = false;
                    Process.Start(psi);
                    MessageBox.Show("Булды куйдым", "Сина эйтем");
                }
                else
                {
                    MessageBox.Show("Дорес итеп яз ангыра!");
                }
            };

            //Обработка нажатия
            buttonCancel.Click += (s, a) => {
                Process.Start("cmd", "/c shutdown -a");
                MessageBox.Show("Все узбакойся отменил все");
            };


            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //MaximizeBox = false;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 528);
            this.Name = "Сундергеч";
            this.Text = "Сундергеч";
            this.ResumeLayout(false);
            this.BackColor = Color.LightSlateGray;
        }

        #endregion
    }
}
