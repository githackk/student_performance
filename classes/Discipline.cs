using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Курсовая_работа.classes
{
    public class Discipline
    {
        int _ID;//ID дисциплины
        string _name;//название дисциплины
        Group _group;//для какой группы дисциплина


        public int Id { get => _ID; set => _ID = value; }
        public string Name { get => _name; set => _name = value; }
        public Group Group { get => _group; set => _group = value; }

        public Discipline()//конструктор по умолчанию
        {
            this._ID = 0;
            this._name = "";
            this._group = null;
        }

        public Discipline(int id, string name, Group group_id)//конструктор инициализации
        {
            this._ID = id;
            this._name = name;
            this._group = group_id;
        }

        public Discipline(Discipline discipline)//конструктор копирования
        {
            this.Name = discipline.Name;
            this.Group = discipline.Group;
        }
    }
}
