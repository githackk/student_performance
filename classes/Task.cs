using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Курсовая_работа.classes
{
    public class Task
    {
        int _ID;//ID задания
        string _name;//название задания
        Discipline _discipline;//для какой дисциплины задание
        DateTime _term;//срок выполнения
        string _type_of_lesson;//тип занятия
        string _theme_of_lesson;//тема занятия
        int _serial_number_of_theme;//порядковый номер темы
        int _max_mark;//максимальный балл, который можно получить за выполнение этого задания


        public int Id { get => _ID; set => _ID = value; }
        public string Name { get => _name; set => _name = value; }
        public Discipline Discipline { get => _discipline; set => _discipline = value; }
        public DateTime Term { get => _term; set => _term = value; }
        public string Type_of_Lesson { get => _type_of_lesson; set => _type_of_lesson = value; }
        public string Theme_of_Lesson { get => _theme_of_lesson; set => _theme_of_lesson = value; }
        public int Serial_Number_of_Theme { get => _serial_number_of_theme; set => _serial_number_of_theme = value; }
        public int Max_Mark { get => _max_mark; set => _max_mark = value; }

        public Task()//конструктор по умолчания
        {
            this._ID = 0;
            this._name = "";
            this._discipline = null;
            this._term = DateTime.Today;
            this._type_of_lesson = "";
            this._theme_of_lesson = "";
            this._serial_number_of_theme = 0;
            this._max_mark = 0;
        }

        public Task(int id, string name, Discipline discipline, DateTime term, string type_of_lesson, string theme_of_lesson, int serial_number_of_theme, int max_mark)//конструктор инициализации
        {
            this._ID = id;
            this._name = name;
            this._discipline = discipline;
            this._term = term;
            this._type_of_lesson = type_of_lesson;
            this._theme_of_lesson = theme_of_lesson;
            this._serial_number_of_theme = serial_number_of_theme;
            this._max_mark = max_mark;
        }

        public Task(Task task)//конструктор копирования
        {
            this.Name = task.Name;
            this.Discipline = task.Discipline;
            this.Term = task.Term;
            this.Type_of_Lesson = task.Type_of_Lesson;
            this.Theme_of_Lesson = task.Theme_of_Lesson;
            this.Serial_Number_of_Theme = task.Serial_Number_of_Theme;
            this.Max_Mark = task.Max_Mark;
        }
    }
}
