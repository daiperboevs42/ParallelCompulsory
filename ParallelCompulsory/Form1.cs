using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParallelCompulsory
{
    public partial class Form1 : Form
    {
        PrimeGenerator primeGen = new PrimeGenerator();
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            long first = 0;
            long second = 0;
            var firstString = textBox1.Text;
            var secondString = textBox2.Text;
            try
            {
                first = (long)Convert.ToDouble(firstString);
                second = (long)Convert.ToDouble(secondString);
                if(checkBox1.Checked == false)
                MeasureTime(() => primeGen.GetPrimesSequential(first, second),false);
                else if(checkBox1.Checked == true)
                MeasureTime(() => primeGen.GetPrimesParallel(first, second),true);
            }
            catch
            {
                label3.Visible = true;
            }
        }

        private void MeasureTime(Action ac, bool isSequential)
        {
            Stopwatch sw = Stopwatch.StartNew();
            ac.Invoke();
            sw.Stop();
            if(!isSequential)
            listView1.Items.Add($"Sequential Time = {sw.Elapsed.TotalSeconds} seconds");
            else if(isSequential)
            listView1.Items.Add($"Parallel Time = {sw.Elapsed.TotalSeconds} seconds");
            //Console.WriteLine("Time = {0} seconds", sw.Elapsed.TotalSeconds);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
