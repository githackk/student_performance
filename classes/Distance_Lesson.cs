using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа.classes
{
    public class Distance_Lesson: Lesson
    {
        Student _student;//какой студент будет отчитывать долги на дистанционном занятии
        string _conference_ID;//идентификационный номер конференции (например zoom)
        string _conference_password;//пароль для входа в конференцию


        public Student Student { get => _student; set => _student = value; }
        public string Conference_Id { get => _conference_ID; set => _conference_ID = value; }
        public string Conference_Password { get => _conference_password; set => _conference_password = value; }

        public Distance_Lesson()//конструктор по умолчанию
            :base()
        {
            this._student = null;
            this._conference_ID = "";
            this._conference_password = "";
        }

        public Distance_Lesson(Student student, string conference_id, string conference_password, string id, DateTime date_of_lesson, Discipline discipline, Group group)//конструктор инициализации
            :base(id, date_of_lesson, discipline, group)
        {
            this._student = student;
            this._conference_ID = conference_id;
            this._conference_password = conference_password;
        }

        public Distance_Lesson(Distance_Lesson distance_Lesson)
            :base(distance_Lesson)//конструктор копирования
        {
            this.Student = distance_Lesson.Student;
            this.Conference_Id = distance_Lesson.Conference_Id;
            this.Conference_Password = distance_Lesson.Conference_Password;
        }

    }
}
