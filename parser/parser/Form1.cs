
using com.calitha.goldparser;

namespace parser

{
    public partial class Form1 : Form
    {
        MyParser p;
        public Form1()
        {
            InitializeComponent();
            p=new MyParser("C:\\Users\\nivee\\source\\repos\\parser\\parser\\bin\\Debug\\net8.0-windows\\t1.cgt",listBox1,listBox2);


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            p.Parse(textBox1.Text);

        }
    }
}
