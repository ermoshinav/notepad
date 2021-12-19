using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace NotepadCSharp
{
    public partial class blank : Form
    {
        public blank()
        {
            InitializeComponent();
         
            //Свойству Text панели sbTime устанавливаем системное время, 
            // конвертировавеговтип String
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            //В тексте всплывающей подсказки  выводим текущую дату
            sbTime.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());

        }

        public string DocName = "";

        private string BufferText = "";
        // Вырезание текста
        public void Cut()
        {
            this.BufferText = richTextBox1.SelectedText;
            richTextBox1.SelectedText = "";
        }

        // Копированиетекста
        public void Copy()
        {
            this.BufferText = richTextBox1.SelectedText;
        }

        // Вставка
        public void Paste()
        {
            richTextBox1.SelectedText = this.BufferText;
        }

        // Выделение всего текста — используем свойство SelectAll элемента управления RichTextBox 
        public void SelectAll()
        {
            richTextBox1.SelectAll();
        }

        // Удаление
        public void Delete()
        {
            richTextBox1.SelectedText = "";
            this.BufferText = "";
        }

        private void cmnu_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        //Создаем метод Open, в качестве параметра объявляем строку адреса  файла.
        public void Open(string OpenFileName)
        {
            //Если файл не выбран, возвращаемся назад (появится встроенное предупреждение)
            if (OpenFileName == "")
            {
                return;
            }
            else
            {
                //Создаем новый объект StreamReader и передаем ему переменную //OpenFileName
                StreamReader sr = new StreamReader(OpenFileName);
                //Читаем весь файл и записываем его в richTextBox1
                richTextBox1.Text = sr.ReadToEnd();
                // Закрываем поток
                sr.Close();
                //Переменной DocName присваиваем адресную строку
                DocName = OpenFileName;
            }
        }
        public void Save(string SaveFileName)
        {
            //Если файл не выбран, возвращаемся назад (появится встроенное предупреждение)
            if (SaveFileName == "")
            {
                return;
            }
            else
            {
                //Создаем новый объект StreamWriter и передаем ему переменную //OpenFileName
                StreamWriter sw = new StreamWriter(SaveFileName);
                //Содержимое richTextBox1 записываемвфайл
                sw.WriteLine(richTextBox1.Text);
                //Закрываемпоток
                sw.Close();
                //Устанавливаем в качестве имени документа название сохраненного файла
                DocName = SaveFileName;
            }
        }
        public bool IsSaved = false;

        private void blank_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsSaved==false)
                if (MessageBox.Show("Вы желаете сохранить изменения в документе "+
                    this.DocName+"?",
                    "message",MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question)==DialogResult.Yes)
                //Если была нажата  кнопка Yes, вызываем метод Save
                {
                    this.Save(this.DocName);
                }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //Свойству Text панели sbAmount устанавливаемнадпись "Аmount of symbols" 
            //и длину  текста в RichTextBox.
            sbAmount.Text = "количество символов" + richTextBox1.Text.Length.ToString();

        }
    }
}
