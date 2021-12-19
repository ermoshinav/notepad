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
    public partial class FindForm : Form
    {
        public FindForm()
        {
            InitializeComponent();
        }

        // Создаем перечисление, возвращающее параметр FindCondition
        public RichTextBoxFinds FindCondition
        {
            get
            {
                //Выбраны два чекбокса
                if (cbMatchCase.Checked && cbMatchWhole.Checked)
                {
                    // Возвращаем свойство MatchCase и WholeWord 
                    return RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord;
                }
                //Выбран один чекбокс
                if (cbMatchCase.Checked)
                {
                    // ВозвращаемсвойствоMatchCase
                    return RichTextBoxFinds.MatchCase;
                }
                //Выбрандругойчекбокс
                if (cbMatchWhole.Checked)
                {
                    // ВозвращаемсвойствоWholeWord
                    return RichTextBoxFinds.WholeWord;
                }
                //Невыбранниодинчекбокс
                return RichTextBoxFinds.None;
            }
        }
        public string FindText
        {
            get { return textFind.Text; }
            set { textFind.Text = value; }
        }

    }
}
