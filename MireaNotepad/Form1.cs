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

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем был ли выбран файл
            {
                textBox1.Clear(); //Очищаем textBox
                openFileDialog1.Filter = "Text Files (*.txt)|*.txt"; //Указываем что нас интересуют только текстовые файлы
                string fileName = openFileDialog1.FileName; //получаем наименование файл и путь к нему.
                LoadingFile l1 = new LoadingFile(fileName); //создаем экземпляр класса загрузки файла
                textBox1.Text = l1.Load(); //Передаем содержимое файла в textBox
            }
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";//Задаем доступные расширения
            saveFileDialog1.DefaultExt = ".txt"; //Задаем расширение по умолчанию
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) //Проверяем подтверждение сохранения информации.
            {
                var name = saveFileDialog1.FileName; //Задаем имя файлу
                SavingFile s1 = new SavingFile(name, textBox1.Text); //создаем экземпляр класса сохранения в файл
                s1.Save(); //Записываем в файл содержимое textBox
            }
            textBox1.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
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
            // установка шрифта
            textBox1.Font = fontDialog1.Font;
        }
    }

    class SavingFile //класс сохранения в файл
    {
        public string FileName;
        private string Text = " ";
        public SavingFile(string a, string b) //конструктор
        {
            FileName = a;
            Text = b;
        }
        public SavingFile(string a) //конструктор
        {
            FileName = a;
        }


        public void Save()  //метод сохранения
        {
            File.WriteAllText(FileName, Text);
        }
    }

    class LoadingFile : SavingFile //класс загрузки из файла, наследник SavingFile
    {
        public LoadingFile(string a)
            : base(a)
        {

        }
        public string Load() //метод загрузки
        {
            string text = File.ReadAllText(FileName);
            return text;
        }
    }


}