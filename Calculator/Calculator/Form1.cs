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

        float FirstNum,SecondNum, Answer;
        bool FirstInput;
        Operations Opt;

        private void Form1_Load(object sender, EventArgs e)
        {
            FirstInput = true;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 1;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtScreen.Text = "";
            FirstNum = 0;
            SecondNum = 0;
            FirstInput = true;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 2;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 3;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 4;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 5;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 6;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 7;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 8;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 9;
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtScreen.Text += 0;
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            txtScreen.Text += "00";
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
            ClearScreen();
            Opt = Operations.Division;
            FirstInput = false;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text != "" )
            {
                if (!FirstInput)
                {
                    SecondNum = float.Parse(txtScreen.Text);
                    Calculate();
                }
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
            if (txtScreen.Text!="" && !txtScreen.Text.Contains("."))
            {
                txtScreen.Text += ".";
            }
           
        }

        private void ClearScreen()
        {
            txtScreen.Clear();
            txtScreen.Focus();
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
                    FirstNum /= SecondNum;
                    break;
            }
        }

        
    }
}
