using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Курсовая_работа.classes
{
    public class Manager_Disciplines
    {
        private static string file_path = "./xmls/Disciplines.xml";
        List<Discipline> disciplines;

        public Manager_Disciplines()
        {
            this.disciplines = load_disciplines();
        }

        public List<Discipline> Disciplines { get => disciplines; }

        public static List<Discipline> load_disciplines()
        {
            if (!File.Exists(file_path))
            {
                string path = "./xmls";
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }

                XmlDocument xml = new XmlDocument();
                XmlDeclaration declaration = xml.CreateXmlDeclaration("1.0", "utf-8", null);
                xml.AppendChild(declaration);
                XmlElement list1 = xml.CreateElement("list");
                xml.AppendChild(list1);
                xml.Save(file_path);
            }
            List<Discipline> disciplines = new List<Discipline>();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);
            XmlElement list = doc.DocumentElement;
            Manager_Groups manager_Groups = new Manager_Groups();
            foreach (XmlElement elem in list.ChildNodes)
            {
                Discipline discipline = new Discipline();
                foreach (XmlElement detale_elem in elem.ChildNodes)
                {
                    if (detale_elem.Name == "Id")
                    {
                        discipline.Id = Int32.Parse(detale_elem.FirstChild.Value);
                    }
                    else if (detale_elem.Name == "Name")
                    {
                        discipline.Name = detale_elem.FirstChild.Value;
                    }
                    else if (detale_elem.Name == "Group_Id")
                    {
                        int group_id = Convert.ToInt32(detale_elem.FirstChild.Value);//в xml файле будет храниться id группы, с помощью него мы потом узнаем все остальные данные группы
                        discipline.Group = manager_Groups.SearchByID(group_id);
                    }
                }
                disciplines.Add(discipline);
            }
            return disciplines;
        }

        public void add(object item)
        {
            Discipline Discipline = (Discipline)item;
            if (Discipline.Id == 0)
            {
                this.disciplines.Add(Discipline);
            }
            else
            {
                foreach (Discipline discipline in this.Disciplines)
                {
                    if (discipline.Id == Discipline.Id)
                    {
                        discipline.Name = Discipline.Name;
                        discipline.Group = Discipline.Group;
                    }
                }
            }
        }

        public void delete(int id)
        {
            for (int i = 0; i < this.Disciplines.Count; i++)
            {
                Discipline discipline = (Discipline)this.Disciplines[i];
                if (discipline.Id == id)
                {
                    this.Disciplines.RemoveAt(i);
                    return;
                }
            }

        }

        public void delete_by_group(Group group)//удаление всех студентов данной группы
        {
            for (int i = 0; i < Disciplines.Count; i++)
            {
                Discipline discipline = Disciplines[i];
                if (discipline.Group.Id == group.Id)
                {
                    //удаляем все занятия относящиеся к данной дисциплине
                    Manager_Lessons manager_Lessons = new Manager_Lessons();
                    manager_Lessons.delete_by_discipline(discipline);
                    manager_Lessons.save();

                    //удаляем все задания по данной дисциплине
                    Manager_Tasks manager_Tasks = new Manager_Tasks();
                    manager_Tasks.delete_by_discipline(discipline);
                    manager_Tasks.save();

                    //удаляем саму дисциплину
                    this.Disciplines.RemoveAt(i);
                    i--;
                }
            }
        }

        public void save()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Disciplines.file_path);
            XmlElement list = doc.DocumentElement;
            list.RemoveAll();
            foreach (Discipline discipline in this.Disciplines)
            {
                discipline.Id = discipline.Id == 0 ? this.getMaxId() + 1 : discipline.Id;
                XmlElement disciplinex = doc.CreateElement("Discipline");
                XmlElement discipline_id = doc.CreateElement("Id");
                discipline_id.InnerText = Convert.ToString(discipline.Id);
                disciplinex.AppendChild(discipline_id);

                XmlElement discipline_name = doc.CreateElement("Name");
                discipline_name.InnerText = discipline.Name;
                disciplinex.AppendChild(discipline_name);

                XmlElement group_id = doc.CreateElement("Group_Id");
                group_id.InnerText = Convert.ToString(discipline.Group.Id);
                disciplinex.AppendChild(group_id);
                list.AppendChild(disciplinex);
            }
            doc.Save(Manager_Disciplines.file_path);
        }

        private int getMaxId()
        {
            int max_id = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Disciplines.file_path);
            XmlElement list = doc.DocumentElement;//получили корневой тэг
            foreach (XmlElement elem in list.ChildNodes)
            {
                foreach (XmlElement detale_elem in elem.ChildNodes)
                {
                    if (detale_elem.Name == "Id")
                    {
                        int temp_id = Int32.Parse(detale_elem.FirstChild.Value);
                        if (max_id < temp_id)
                        {
                            max_id = temp_id;
                        }
                    }
                }
            }
            return max_id;
        }

        public Discipline SearchById(int id)
        {
            for (int i = 0; i < this.Disciplines.Count; i++)
            {
                Discipline discipline = (Discipline)this.Disciplines[i];
                if (discipline.Id == id)
                {
                    return discipline;
                }
            }
            return null;
        }

        public Discipline SearchByName(string name)
        {
            foreach (Discipline discipline in Disciplines)
            {
                if (discipline.Name + " (" + discipline.Group.Name + ")" == name)
                {
                    return discipline;
                }
            }
            return null;
        }

        public List<Discipline> SearchByGroup(Group group)
        {
            List<Discipline> disciplines_by_group = new List<Discipline>();
            foreach (Discipline discipline in Disciplines)
            {
                if (discipline.Group.Id == group.Id)
                {
                    disciplines_by_group.Add(discipline);
                }
            }
            return disciplines_by_group;
        }
    }
}
