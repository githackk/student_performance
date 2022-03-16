using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    public class Student
    {
        //поля
        string _ID;//номер зачетной книжки
        string _surname;//фамилия
        string _name;//имя
        string _patronymic;//отчество
        Group _group;//группа

        //свойства
        public string Id { get => _ID; set => _ID = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public string Name { get => _name; set => _name = value; }
        public string Patronymic { get => _patronymic; set => _patronymic = value; }
        public Group Group { get => _group; set => _group = value; }

        public Student()//конструктор по умолчанию
        {
            this._ID = "";
            this._surname = "";
            this._name = "";
            this._patronymic = "";
            this._group = null;
        }

        public Student(string id, string surname, string name, string patronymic, Group group)//конструктор инициализации
        {
            this._ID = id;
            this._surname = surname;
            this._name = name;
            this._patronymic = patronymic;
            this._group = group;
        }

        public Student(Student student)//конструктор копирования
        {
            this.Surname = student.Surname;
            this.Name = student.Name;
            this.Patronymic = student.Patronymic;
            this.Group = student.Group;
        }
    }
}
