using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalHuay
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string twoDigit = txtDigit.Text.Substring(0, 2);
                string threeDigit = txtDigit.Text.Substring(2, 3);
                //
                txt3DigitUpDaily.Text = threeDigit;
                txt2DigitDownDaily.Text = twoDigit;
                //
                txt3DigitTodDaily.Text = calculate3DigitTod(threeDigit);
                //
                txt2DigitUpDaily.Text = threeDigit[1].ToString() + threeDigit[2].ToString();
                //
                txt1DigitUpDaily.Text = calculate1DigitUpDown(threeDigit);
                txt1DigitDownDaily.Text = calculate1DigitUpDown(twoDigit);
                //
                txtUpEvenOddDaily.Text = ((Convert.ToInt32(threeDigit) % 2) == 0) ? "0" : "1";
                txtDownEvenOddDaily.Text = ((Convert.ToInt32(twoDigit) % 2) == 0) ? "0" : "1";
                //
                txt3DigitUpHighLowDaily.Text = (Convert.ToInt32(threeDigit) < 500) ? "0" : "1";
                txt2DigitUpHighLowDaily.Text = (Convert.ToInt32(threeDigit[1].ToString() + threeDigit[2].ToString()) < 50) ? "0" : "1";
                txtDownHighLowDaily.Text = (Convert.ToInt32(twoDigit) < 50) ? "0" : "1";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string calculate1DigitUpDown(string number)
        {
            List<string> digits = new List<string>();

            for(int i=0; i<number.Length; i++)
            {
                string n = number[i].ToString();
                if(digits.Contains(n) == false)
                {
                    digits.Add(n);
                }
            }

            return string.Join(", ", digits);
        }

        private string calculate3DigitTod(string threeDigit)
        {
            List<string> tod = new List<string>();

            {
                var item = threeDigit[0].ToString() + threeDigit[1].ToString() + threeDigit[2].ToString();
                if (tod.Contains(item) == false)
                {
                    tod.Add(item);
                }
            }
            {
                var item = threeDigit[0].ToString() + threeDigit[2].ToString() + threeDigit[1].ToString();
                if (tod.Contains(item) == false)
                {
                    tod.Add(item);
                }
            }

            //

            {
                var item = threeDigit[1].ToString() + threeDigit[0].ToString() + threeDigit[2].ToString();
                if (tod.Contains(item) == false)
                {
                    tod.Add(item);
                }
            }
            {
                var item = threeDigit[1].ToString() + threeDigit[2].ToString() + threeDigit[0].ToString();
                if (tod.Contains(item) == false)
                {
                    tod.Add(item);
                }
            }

            //

            {
                var item = threeDigit[2].ToString() + threeDigit[1].ToString() + threeDigit[0].ToString();
                if (tod.Contains(item) == false)
                {
                    tod.Add(item);
                }
            }
            {
                var item = threeDigit[2].ToString() + threeDigit[0].ToString() + threeDigit[1].ToString();
                if (tod.Contains(item) == false)
                {
                    tod.Add(item);
                }
            }

            //

            return string.Join(", ", tod);
        }
    }
}
