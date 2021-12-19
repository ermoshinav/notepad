using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotepadCSharp
{
    public partial class frmmain : Form
    {

        private int openDocuments = 0;

        public frmmain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void mnuNew_Click(object sender, EventArgs e)
        {
            //Создаемновыйэкземплярформы  frm
            blank frm = new blank();
            frm.DocName = "Untitled " + ++openDocuments;
            frm.Text = frm.DocName;
            frm.MdiParent = this;
            frm.Show();

        }

        private void mnuArrangeIcons_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void mnuCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mnuTileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void mnuTileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Cut();
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Copy();
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Paste();
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Delete();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.SelectAll();
        }

        private void mnuOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                blank frm = new blank();
                frm.MdiParent = this;
                frm.DocName = openFileDialog1.FileName;
                frm.Text = frm.DocName;
                frm.Show();
                frm.IsSaved = true;
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            //Можно программно задавать доступные для обзора расширения файлов 
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";

            //Если выбран диалог открытия файла, выполняем условие
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = (blank)this.ActiveMdiChild;
                frm.Save(saveFileDialog1.FileName);
                frm.MdiParent = this;
                //Присваиваем переменной FileName имя сохраняемого файла
                frm.DocName = saveFileDialog1.FileName;
                //Свойству Text формы присваиваем переменную DocName
                frm.Text = frm.DocName;

            }
        }

        private void mnuFont_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            fontDialog1.ShowColor = true;
            fontDialog1.Font = frm.richTextBox1.SelectionFont;
            fontDialog1.Color = frm.richTextBox1.SelectionColor;
            if (fontDialog1.ShowDialog()==DialogResult.OK)
            {
                frm.richTextBox1.SelectionFont=fontDialog1.Font;
                frm.richTextBox1.SelectionColor=fontDialog1.Color;
            }
        }

        private void mnuColor_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            colorDialog1.Color = frm.richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                frm.richTextBox1.SelectionColor = colorDialog1.Color;
            }
            frm.Show();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuFind_Click(object sender, EventArgs e)
        {
            //Создаемновыйэкземплярформы FindForm
            FindForm frm = new FindForm();
            //ЕсливыбранрезультатDialogResult.Cancel, закрываемформу (доэтого
            //мы использовали DialogResult.OK)
            if (frm.ShowDialog(this) == DialogResult.Cancel) return;
            ////Переключаем фокус на данную форму.
            blank form = (blank)this.ActiveMdiChild;
            ////Указываем, что родительской формой является форма frmmain  
            form.MdiParent = this;
            //Вводим переменную для поиска в определенной части текста —
            //поиск слова будет осуществляться от текущей позиции курсора
            int start = form.richTextBox1.SelectionStart;
            //Вызываем предопределенный метод Find элемента richTextBox1.
            form.richTextBox1.Find(frm.FindText, start, frm.FindCondition);

        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Создаемновыйэкземплярформы  About
            About frm = new About();
            frm.ShowDialog();

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.Button.Equals(tbCut))
            {
                mnuCut_Click(this, new EventArgs());
            }
            //Copy
            if (e.Button.Equals(tbCopy))
            {
                mnuCopy_Click(this, new EventArgs());
            }
            //Paste
            if (e.Button.Equals(tbpaste))
            {
                mnuPaste_Click(this, new EventArgs());
            }


        }
    }
    
}
