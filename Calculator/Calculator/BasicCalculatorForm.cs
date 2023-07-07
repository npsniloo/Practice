
using MyCalculator.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCalculator
{
    public partial class CalculatorClass : Form
    {
        private readonly Calculator Calculator;
        public CalculatorClass()
        {
            InitializeComponent();
            Calculator = new Calculator();
        }

        private static float Num, Answer;
        bool StartNewOperation;
        Operations Operation;
        bool Error;


        private void ResetCalculator()
        {
            txtScreen.Text = "";
            lblError.Text = "";

            Operation = Operations.Equal;
            Num = 0;
            Answer = 0;
            Error = false;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            StartNewOperation = true;
            ResetCalculator();
            TypeNumber("0");

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtHistory.Text += (txtHistory.Text) != "" ? Environment.NewLine : "";
            StartNewOperation = true;
            ResetCalculator();
        }

        private void SetTextboxTextNumber(string number)
        {
            var parsed = float.TryParse(txtScreen.Text, out float result);
            if (!parsed || result != 0 || txtScreen.Text.EndsWith("."))
            {
                txtScreen.Text = txtScreen.Text + number;
            }
            else
            {
                txtScreen.Text = number;
            }
        }
        private void TypeNumber(string number)
        {
            if (StartNewOperation || Error)
            {
                ResetCalculator();
            }
            SetTextboxTextNumber(number);
            StartNewOperation = false;
        }
        private void btn1_Click(object sender, EventArgs e)
        {
            TypeNumber("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            TypeNumber("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            TypeNumber("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            TypeNumber("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            TypeNumber("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            TypeNumber("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            TypeNumber("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            TypeNumber("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            TypeNumber("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            TypeNumber("0");
        }

        private void btn00_Click(object sender, EventArgs e)
        {
            TypeNumber("0");
            TypeNumber("0");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {

            var parsed = float.TryParse(txtScreen.Text, out Num);

            if (!parsed)
            {
                CallError("Wrong Input!");
                ClearHistoryLastLine();
                return;
            }

            try
            {
                CalculatePrev();
            }
            catch (Exception ex)
            {
                CallError($"Error:{ex.Message}");
                ClearHistoryLastLine();
                return;
            }

            txtHistory.Text += txtScreen.Text + "+";
            ClearScreen();
            Operation = Operations.Add;

        }
        private void btnMinus_Click(object sender, EventArgs e)
        {
            var parsed = float.TryParse(txtScreen.Text, out Num);

            if (!parsed)
            {
                CallError("Wrong Input!");
                ClearHistoryLastLine();
                return;
            }
            try
            {
                CalculatePrev();
            }
            catch (Exception ex)
            {
                CallError($"Error:{ex.Message}");
                ClearHistoryLastLine();
                return;
            }

            txtHistory.Text += txtScreen.Text + "-";
            ClearScreen();
            Operation = Operations.Subtract;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            var parsed = float.TryParse(txtScreen.Text, out Num);

            if (!parsed)
            {
                CallError("Wrong Input!");
                ClearHistoryLastLine();
                return;
            }
            try
            {
                CalculatePrev();
            }
            catch (Exception ex)
            {
                CallError($"Error:{ex.Message}");
                ClearHistoryLastLine();
                return;
            }
            txtHistory.Text += txtScreen.Text + "*";
            ClearScreen();
            Operation = Operations.Multiply;

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {

            var parsed = float.TryParse(txtScreen.Text, out Num);

            if (!parsed)
            {
                CallError("Wrong Input!");
            }
            try
            {
                CalculatePrev();
            }
            catch (Exception ex)
            {
                CallError($"Error:{ex.Message}");
                ClearHistoryLastLine();
                return;
            }

            txtHistory.Text += txtScreen.Text + "/";
            ClearScreen();
            Operation = Operations.Division;
        }
        private void btnPoint_Click(object sender, EventArgs e)
        {
            if (txtScreen.Text != "" && !txtScreen.Text.Contains("."))
            {
                txtScreen.Text += ".";
            }

        }
        private void btnEqual_Click(object sender, EventArgs e)
        {

            var parsed = float.TryParse(txtScreen.Text, out Num);

            if (!parsed)
            {
                CallError("Wrong Input!");
                return;
            }
            try
            {
                CalculatePrev();
            }
            catch (Exception ex)
            {
                CallError($"Error:{ex.Message}");
                ClearHistoryLastLine();
                return;
            }

            txtHistory.Text += txtScreen.Text + "=" + Answer;
            txtHistory.Text += Environment.NewLine;
            Operation = Operations.Equal;
            StartNewOperation = true;
        }





        private void ClearScreen()
        {
            txtScreen.Clear();
            txtScreen.Focus();
        }



        private void CalculatePrev()
        {
            switch (Operation)
            {
                case Operations.Add:
                    Answer = Calculator.Add(Answer, Num);
                    break;
                case Operations.Multiply:
                    Answer = Calculator.Multiply(Answer, Num);
                    break;
                case Operations.Subtract:
                    Answer = Calculator.Subtract(Answer, Num);
                    break;
                case Operations.Division:
                    Answer = Calculator.Divide(Answer, Num);
                    break;
                case Operations.Equal:
                default:
                    Answer = Num;
                    break;
            }

        }

        private void CallError(string error)
        {
            lblError.Text = error;
            Error = true;
           
        }

        private void ClearHistoryLastLine()
        {
            string history = txtHistory.Text;
            if (history.Length > 0)
            {
                int start = history.LastIndexOf("\n");
                start = start >= 0 ? start : 0;
                var str=history.Substring(start);
                history = history.Remove(start, str.Length);
                txtHistory.Text = history+Environment.NewLine;
            }
        }
    }
}
