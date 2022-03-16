using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа.classes
{
    public class Additional_Lesson: Lesson
    {
        string _audience_number;//номер аудитории


        public string Audience_Number { get => _audience_number; set => _audience_number = value; }

        public Additional_Lesson()//конструктор по умолчанию
            :base()
        {
            this._audience_number = "";
        }

        public Additional_Lesson(string audience_number, string id, DateTime date_of_lesson, Discipline discipline, Group group)//конструктор инициализации
            :base(id, date_of_lesson, discipline, group)
        {
            this._audience_number = audience_number;
        }

        public Additional_Lesson(Additional_Lesson additional_Lesson)
            :base(additional_Lesson)//конструктор копирования
        {
            this.Audience_Number = additional_Lesson.Audience_Number;
        }
    }
}
