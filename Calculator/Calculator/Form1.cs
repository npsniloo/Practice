using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        float FirstNum, SecondNum, Answer;
        bool FirstInput;
        Operations Opt;

        private void Form1_Load(object sender, EventArgs e)
        {
            FirstInput = true;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtScreen.Text = "";
            txtHistory.Text += (txtHistory.Text) != "" ? Environment.NewLine : "";
            FirstNum = 0;
            SecondNum = 0;
            FirstInput = true;
            lblError.Text ="" ;
        }

        private string GetTextbox()
        {
            var parsed = float.TryParse(txtScreen.Text, out float result);
            if (parsed && result == 0)
            {
                return string.Empty;
            }
            else
            {
                return txtScreen.Text;
            }
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            txtScreen.Text = GetTextbox() + 1;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtScreen.Text = GetTextbox() + 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtScreen.Text = GetTextbox() + 3;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtScreen.Text = GetTextbox() + 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtScreen.Text = GetTextbox() + 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 6;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtScreen.Text = GetTextbox() + 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtScreen.Text = GetTextbox() + 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtScreen.Text = GetTextbox() + 9;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtScreen.Text = GetTextbox() + 0;
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            var txt = GetTextbox();
            txtScreen.Text = txt + (txt == "0" || txt == "" ? "0" : "00");
        }
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (!FirstInput)
            {
                SecondNum = float.Parse(txtScreen.Text);
                Calculate();
            }
            else
            {

                SetFirstNum();
            }
            // 
            txtHistory.Text += txtScreen.Text + "+";
            ClearScreen();
            Opt = Operations.Add;
            FirstInput = false;
        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (!FirstInput)
            {
                SecondNum = float.Parse(txtScreen.Text);
                Calculate();
            }
            else
            {
                SetFirstNum();
            }
            txtHistory.Text += txtScreen.Text + "-";
            ClearScreen();
            Opt = Operations.Subtract;
            FirstInput = false;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (!FirstInput)
            {
                SecondNum = float.Parse(txtScreen.Text);
                Calculate();
            }
            else
            {
                SetFirstNum();
            }
            txtHistory.Text += txtScreen.Text + "*";
            ClearScreen();
            Opt = Operations.Multiply;
            FirstInput = false;

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (!FirstInput)
            {
                SecondNum = float.Parse(txtScreen.Text);
                Calculate();
            }
            else
            {
                SetFirstNum();
            }
            txtHistory.Text += txtScreen.Text + "/";
            ClearScreen();
            Opt = Operations.Division;
            FirstInput = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text != "")
            {
                if (!FirstInput)
                {
                    SecondNum = float.Parse(txtScreen.Text);
                    Calculate();
                }
                txtHistory.Text += txtScreen.Text + "=" + FirstNum;
                txtHistory.Text += Environment.NewLine;
                txtScreen.Text = FirstNum.ToString();
                FirstNum = 0;
                SecondNum = 0;
                FirstInput = true;


            }
            else
            {

                txtScreen.Text = FirstNum.ToString();
                FirstInput = true;
            }
        }

        private void SetFirstNum()
        {
            FirstNum = float.Parse(txtScreen.Text);


        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text != "" && !txtScreen.Text.Contains("."))
            {
                txtScreen.Text += ".";
            }

        }

        private void ClearScreen()
        {
            txtScreen.Clear();
            txtScreen.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Calculate()
        {
            switch (Opt)
            {
                case Operations.Add:
                    FirstNum += SecondNum;
                    break;
                case Operations.Multiply:
                    FirstNum *= SecondNum;
                    break;
                case Operations.Subtract:
                    FirstNum -= SecondNum;
                    break;
                case Operations.Division:
                    if (SecondNum == 0)
                    {
                        CallError("Cant Divide By Zero");
                        return;
                    }
                    FirstNum /= SecondNum;
                    break;
            }
        }

        private void CallError(string error)
        {
            lblError.Text = error;
        }
    }
}
