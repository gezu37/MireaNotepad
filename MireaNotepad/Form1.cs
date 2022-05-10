namespace MireaNotepad
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //��������� ��� �� ������ ����
            {
                textBox1.Clear(); //������� textBox
                openFileDialog1.Filter = "Text Files (*.txt)|*.txt"; //��������� ��� ��� ���������� ������ ��������� �����
                string fileName = openFileDialog1.FileName; //�������� ������������ ���� � ���� � ����.
                LoadingFile l1 = new LoadingFile(fileName); //������� ��������� ������ �������� �����
                textBox1.Text = l1.Load(); //�������� ���������� ����� � textBox
            }
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";//������ ��������� ����������
            saveFileDialog1.DefaultExt = ".txt"; //������ ���������� �� ���������
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) //��������� ������������� ���������� ����������.
            {
                var name = saveFileDialog1.FileName; //������ ��� �����
                SavingFile s1 = new SavingFile(name, textBox1.Text); //������� ��������� ������ ���������� � ����
                s1.Save(); //���������� � ���� ���������� textBox
            }
            textBox1.Clear();
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // ��������� ������
            textBox1.Font = fontDialog1.Font;
        }
    }

    class SavingFile //����� ���������� � ����
    {
        public string FileName;
        private string Text = " ";
        public SavingFile(string a, string b) //�����������
        {
            FileName = a;
            Text = b;
        }
        public SavingFile(string a) //�����������
        {
            FileName = a;
        }


        public void Save()  //����� ����������
        {
            File.WriteAllText(FileName, Text);
        }
    }

    class LoadingFile : SavingFile //����� �������� �� �����, ��������� SavingFile
    {
        public LoadingFile(string a)
            : base(a)
        {

        }
        public string Load() //����� ��������
        {
            string text = File.ReadAllText(FileName);
            return text;
        }
    }


}