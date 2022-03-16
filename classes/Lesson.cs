using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа.classes
{
    public class Lesson
    {
        protected string _ID;//ID занятия
        protected DateTime _date_of_lesson;//дата занятия
        protected Discipline _discipline;//дисциплина, по которой будет проводиться занятие
        protected Group _group;//для какой группы будет проводиться занятие

        //свойства
        public string Id { get => _ID; set => _ID = value; }
        public DateTime Date_of_Lesson { get => _date_of_lesson; set => _date_of_lesson = value; }
        public Discipline Discipline { get => _discipline; set => _discipline = value; }
        public Group Group { get => _group; set => _group = value; }

        public Lesson()//конструктор по умолчанию
        {
            this._ID = "";
            this._date_of_lesson = DateTime.Today;
            this._discipline = null;
            this._group = null;
        }

        public Lesson(string id, DateTime date_of_lesson, Discipline discipline, Group group)//конструктор инициализации №1 (с id)
        {
            this._ID = id;
            this._date_of_lesson = date_of_lesson;
            this._discipline = discipline;
            this._group = group;
        }

        public Lesson(DateTime date_of_lesson, Discipline discipline, Group group)//конструктор инициализации №2 (без id)
        {
            this._date_of_lesson = date_of_lesson;
            this._discipline = discipline;
            this._group = group;
        }

        public Lesson(Lesson lesson)//конструктор копирования
        {
            this.Date_of_Lesson = lesson.Date_of_Lesson;
            this.Discipline = lesson.Discipline;
            this.Group = lesson.Group;
        }
    }
}
