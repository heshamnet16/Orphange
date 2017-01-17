using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SearchControl
{
    public partial class SearchControl : UserControl
    {
        public event EventHandler SearchButtonClick;
        public string SearchedText
        {
            get { return textBox1.Text; }
            set { textBox1.Text  = value; }
        }
        public SearchControl()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (SearchButtonClick != null)
                SearchButtonClick(sender, e);
        }

        private void SearchControl_FontChanged(object sender, EventArgs e)
        {
            textBox1.Font = this.Font;
             
            if (textBox1.Height != this.Height)
            {
                this.MinimumSize = new Size(textBox1.Height *2, textBox1.Height);
                this.MaximumSize = new Size(4000, textBox1.Height+5);
                this.Height = textBox1.Height+5 ;
                textBox1.Width = this.Width - textBox1.Height -2;
                button1.Size = new Size(textBox1.Height, textBox1.Height);
                textBox1.Left = textBox1.Height;
                textBox1.Top = 0;
            }
        }

        private void SearchControl_ForeColorChanged(object sender, EventArgs e)
        {
            textBox1.ForeColor = this.ForeColor;
        }

        private void SearchControl_BackColorChanged(object sender, EventArgs e)
        {
            textBox1.BackColor = this.BackColor;
            button1.BackColor = this.BackColor;
        }

        private void textBox1_SizeChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (SearchButtonClick != null)
                    SearchButtonClick(sender, e);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            LangChanger.CurLang.SaveCurrentLanguage();
            LangChanger.CurLang.ChangeToArabic();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            LangChanger.CurLang.ReturnToSavedLanguage();
        }

    }
}
