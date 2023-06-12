using System.Windows.Forms;
using System.IO;


namespace exus
{
    public partial class Results : Form
    {
        Controller controller;
        public Results(Controller a)
        {
            InitializeComponent();
            controller = a;
        }
        public void ShowMenu()
        {
            Show();
            string temp = controller.GetResult();
            string[] res = temp.Split('\n');
            foreach (string s in res)
            {
                listBox1.Items.Add(s);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            DialogResult check = MessageBox.Show("Are you sure?", "Results", MessageBoxButtons.YesNo);
            if (check == DialogResult.Yes)
            {
                File.WriteAllText("results.txt", "");
                listBox1.Items.Clear();
                string temp = controller.GetResult();
                string[] res = temp.Split('\n');
                foreach (string s in res)
                {
                    listBox1.Items.Add(s);
                }
            }
        }
    }
}
