using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exus
{
    public partial class Form1 : Form
    {
        Button[] buttons;
        static Controller controller;
        Task time;
        static int timer = 0;
        int mistake = 0, charcount = 0;
        static bool end = false;
        static Label label_time = null;
        public Form1()
        {
            InitializeComponent();
            label_time = label6;
            buttons = new Button[] { button2, button3, button4, button5, button6, button7, button8, button9, button10, button11, button12,
            button13, button14, button15, button16, button17, button18, button19, button20, button21, button22, button23, button24, button25,
            button26, button27, button28 };
            foreach (Button x in buttons)
            {
                x.BackColor = Color.DarkGray;
            }
            controller = new Controller(this);
            controller.Createdb();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (button1.Enabled == false)
            {
                if (e.KeyData.ToString() == "Space")
                {
                    controller.TapCheck(' ');
                }
                else
                {
                    controller.TapCheck(Convert.ToChar(e.KeyValue + 32));
                }
            }
            foreach (Button x in buttons)
            {
                if (x.Text == e.KeyData.ToString())
                {
                    x.BackColor = Color.LightBlue;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (Button x in buttons)
            {
                x.BackColor = Color.DarkGray;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            time = new Task(Timer);
            time.Start();
            label9.Text = controller.SetText();
            charcount = label9.Text.Length - 1;
            label2.Text = charcount.ToString();
        }

        private static void Timer()
        {
            while (!end)
            {
                Thread.Sleep(1000);
                timer++;
                label_time.Text = timer.ToString() + " s";
            }
        }
        public void Mistake()
        {
            mistake++;
            label4.Text = mistake.ToString();
        }
        public void Correct(char a)
        {
            charcount--;
            label2.Text = charcount.ToString();
            label10.Text += a;
        }
        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.ResultForm1();
        }
        public void End()
        {
            end = true;
            time.Wait();
            controller.AddResult(mistake, timer);
            MessageBox.Show($"Time: {timer} сек\nMistakes: {mistake}", "Total");
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
    }
}

