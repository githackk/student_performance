using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа.classes
{
    public class Current_Lesson: Lesson
    {
        Task _task;//какое задание будет отчитываться на данном занятии
        string _audience_number;//номер аудитории


        public Task Task { get => _task; set => _task = value; }
        public string Audience_Number { get => _audience_number; set => _audience_number = value; }


        public Current_Lesson()//конструктор по умолчанию
            :base()
        {
            this._task = null;
            this._audience_number = "";
        }

        public Current_Lesson(Task task, string audience_number, string id, DateTime date_of_lesson, Discipline discipline, Group group)//конструктор инициализации
            :base(id, date_of_lesson, discipline, group)
        {
            this._task = task;
            this._audience_number = audience_number;
        }

        public Current_Lesson(Current_Lesson current_Lesson)
            :base(current_Lesson)//конструктор копирования
        {
            this.Task = current_Lesson.Task;
            this.Audience_Number = current_Lesson.Audience_Number;
        }
    }
}
