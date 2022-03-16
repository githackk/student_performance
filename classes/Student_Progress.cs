using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа.classes
{
    public class Student_Progress
    {
        //поля
        int _ID;//ID оценки студента
        Student _student;//для какого студента оценка
        Task _task;//по какому заданию
        int _variant;//номер варианта
        int _amount_of_attemps;//количество попыток выполнить
        DateTime _completed_date;//дата сдачи задания
        bool _completed;//выполнено или нет
        int _mark;//оценка

        //свойства
        public int Id { get => _ID; set => _ID = value; }
        public Student Student { get => _student; set => _student = value; }
        public Task Task { get => _task; set => _task = value; }
        public int Variant { get => _variant; set => _variant = value; }
        public int Amount_of_Attemps { get => _amount_of_attemps; set => _amount_of_attemps = value; }
        public DateTime Completed_Date { get => _completed_date; set => _completed_date = value; }
        public bool Completed { get => _completed; set => _completed = value; }
        public int Mark { get => _mark; set => _mark = value; }

        public Student_Progress()//конструктор по умолчанию
        {
            this._ID = 0;
            this._student = null;
            this._task = null;
            this._variant = 0;
            this._amount_of_attemps = 0;
            this._completed_date = DateTime.Today;
            this._completed = false;
            this._mark = 0;
        }

        public Student_Progress(Student student, Task task)//конструктор инициализации №1 (без оценки)
        {
            this._ID = 0;
            this._student = student;
            this._task = task;
            this._variant = 0;
            this._amount_of_attemps = 0;
            this._completed_date = task.Term;
            this._completed = false;
            this._mark = 0;
        }

        public Student_Progress(int id, Student student, Task task, int number_of_variant, int amount_of_attemps, DateTime completed_date, bool completed, int mark)//конструктор инициализации №2(с оценкой)
        {
            this._ID = id;
            this._student = student;
            this._task = task;
            this._variant = number_of_variant;
            this._amount_of_attemps = amount_of_attemps;
            this._completed_date = completed_date;
            this._completed = completed;
            this._mark = mark;
        }

        public Student_Progress(Student_Progress mark)//конструктор копирования
        {
            this.Student = mark.Student;
            this.Task = mark.Task;
            this.Variant = mark.Variant;
            this.Amount_of_Attemps = mark.Amount_of_Attemps;
            this.Completed_Date = mark.Completed_Date;
            this.Completed = mark.Completed;
            this.Mark = mark.Mark;
        }
    }
}
