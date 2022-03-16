using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    public class Group
    {
        int _ID;//ID группы
        string _name;//название группы
        string _speciality;//специальность
        int _course;//курс
        string _faculty;//факультет


        public int Id { get => _ID; set => _ID = value; }
        public string Name { get => _name; set => _name = value; }
        public string Speciality { get => _speciality; set => _speciality = value; }
        public int Course { get => _course; set => _course = value; }
        public string Faculty { get => _faculty; set => _faculty = value; }

        public Group()//конструктор по умолчанию
        {
            this._ID = 0;
            this._name = "";
            this._speciality = "";
            this._course = 0;
            this._faculty = "";
        }

        public Group(int id, string name, string speciality, int course, string faculty)//конструктор инициализации
        {
            this._ID = id;
            this._name = name;
            this._speciality = speciality;
            this._course = course;
            this._faculty = faculty;
        }

        public Group(Group group)//конструктор копирования
        {
            this.Name = group.Name;
            this.Speciality = group.Speciality;
            this.Course = group.Course;
            this.Faculty = group.Faculty;
        }
    }
}
