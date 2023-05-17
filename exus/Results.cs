using System.Windows.Forms;


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

    }
}
