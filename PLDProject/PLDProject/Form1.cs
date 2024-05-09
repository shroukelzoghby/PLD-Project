using com.calitha.goldparser;
using System.IO;

namespace PLDProject
{

    public partial class Form1 : Form
    {

        MyParser p;

        public Form1()
        {
            InitializeComponent();
            p = new MyParser("ShProgrammingLang.cgt", listBox1, listBox2);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            p.Parse(textBox1.Text);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
