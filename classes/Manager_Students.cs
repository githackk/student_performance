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
    public class Manager_Students
    {
        private static string file_path = "./xmls/Students.xml";
        private List<Student> students;

        public Manager_Students()
        {
            this.students = load_students();
        }
        public List<Student> Students { get => students; }

        public static List<Student> load_students()
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
            List<Student> students = new List<Student>();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);
            XmlElement list = doc.DocumentElement;
            Manager_Groups manager_Groups = new Manager_Groups();
            foreach (XmlElement elem in list.ChildNodes)
            {
                Student student = new Student();
                foreach (XmlElement detale_elem in elem.ChildNodes)
                {
                    if (detale_elem.Name == "Id")
                    {
                        student.Id = detale_elem.FirstChild.Value;
                    }
                    else if (detale_elem.Name == "Surname")
                    {
                        student.Surname = detale_elem.FirstChild.Value;
                    }
                    else if (detale_elem.Name == "Name")
                    {
                        student.Name = detale_elem.FirstChild.Value;
                    }
                    else if (detale_elem.Name == "Patronymic")
                    {
                        student.Patronymic = detale_elem.FirstChild.Value;
                    }
                    else if (detale_elem.Name == "Group_Id")
                    {
                        int group_id = Convert.ToInt32(detale_elem.FirstChild.Value);//в xml файле будет храниться id группы, с помощью него мы потом узнаем все остальные данные группы
                        student.Group = manager_Groups.SearchByID(group_id);
                    }
                }
                students.Add(student);
            }
            return students;
        }

        public void add(object item)
        {
            Student Student = (Student)item;
            if (Student.Id == "")
            {
                this.students.Add(Student);
            }
            else
            {
                foreach (Student student in this.students)
                {
                    if (student.Id == Student.Id)
                    {
                        student.Surname = Student.Surname;
                        student.Name = Student.Name;
                        student.Patronymic = Student.Patronymic;
                        student.Group = Student.Group;
                    }
                }
            }
        }

        public void delete(string id)
        {
            for (int i = 0; i < this.Students.Count; i++)
            {
                Student student = (Student)this.Students[i];
                if (student.Id == id)
                {
                    this.Students.RemoveAt(i);
                    return;
                }
            }

        }

        public void delete_by_group(Group group)//удаление всех студентов данной группы
        {
            for (int i = 0; i < Students.Count; i++)
            {
                Student student = Students[i];
                if (student.Group.Id == group.Id)
                {
                    this.Students.RemoveAt(i);
                    i--;
                }
            }
        }

        public void save()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Students.file_path);
            XmlElement list = doc.DocumentElement;
            list.RemoveAll();
            foreach (Student student in this.Students)
            {
                student.Id = student.Id == "" ? this.get_Id() : student.Id;
                XmlElement studentx = doc.CreateElement("student");
                XmlElement student_id = doc.CreateElement("Id");
                student_id.InnerText = Convert.ToString(student.Id);
                studentx.AppendChild(student_id);

                XmlElement student_surname = doc.CreateElement("Surname");
                student_surname.InnerText = student.Surname;
                studentx.AppendChild(student_surname);

                XmlElement student_name = doc.CreateElement("Name");
                student_name.InnerText = student.Name;
                studentx.AppendChild(student_name);

                XmlElement student_patronymic = doc.CreateElement("Patronymic");
                student_patronymic.InnerText = student.Patronymic;
                studentx.AppendChild(student_patronymic);

                XmlElement group_id = doc.CreateElement("Group_Id");
                group_id.InnerText = Convert.ToString(student.Group.Id);
                studentx.AppendChild(group_id);
                list.AppendChild(studentx);
            }
            doc.Save(Manager_Students.file_path);
        }

        private string get_Id()
        {
            const string str = "ST";
            int max_id = 20200000;
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Students.file_path);
            XmlElement list = doc.DocumentElement;//получили корневой тэг
            foreach (XmlElement elem in list.ChildNodes)
            {
                foreach (XmlElement detale_elem in elem.ChildNodes)
                {
                    if (detale_elem.Name == "Id")
                    {
                        int temp_id = Int32.Parse(detale_elem.FirstChild.Value.Substring(2));//берем только цифры
                        if (max_id < temp_id)
                        {
                            max_id = temp_id;
                        }
                    }
                }
            }
            return (str + (max_id + 1));
        }

        public Student SearchByID(string id)
        {
            for (int i = 0; i < this.Students.Count; i++)
            {
                Student student = (Student)this.Students[i];
                if (student.Id == id)
                {
                    return student;
                }
            }
            return null;
        }

        public Student SearchByName(string name)
        {
            foreach (Student student in Students)
            {
                string cut_name = "(" + student.Id+") " + student.Surname + " " + student.Name.Substring(0, 1) +
                    "." + student.Patronymic.Substring(0, 1) + ".";
                if (cut_name == name)
                {
                    return student;
                }
            }
            return null;
        }

        public List<Student> SearchByGroup(Group group)
        {
            List<Student> students_by_group = new List<Student>();
            foreach (Student student in Students)
            {
                if (student.Group.Id == group.Id)
                {
                    students_by_group.Add(student);
                }
            }
            return students_by_group;
        }

        public List<Student> students_with_debts(Group group)
        {
            List<Student> list = new List<Student>();
            Manager_Student_Progress manager_Student_Progress = new Manager_Student_Progress();
            for (int i = 0; i < Students.Count; i++)
            {
                Student student = Students[i];
                if (student.Group.Id == group.Id && manager_Student_Progress.check_term_delay(student) == true) 
                {
                    list.Add(student);
                }
            }
            return list;
        }

        public List<Student> best_students_of_group(Discipline discipline)
        {
            List<Student> list = new List<Student>();
            Manager_Student_Progress manager_Student_Progress = new Manager_Student_Progress();
            for (int i = 0; i < Students.Count; i++)
            {
                Student student = Students[i];
                if (discipline.Group.Id == student.Group.Id)
                {
                    if (manager_Student_Progress.check_best_student(student, discipline) == true)
                    {
                        list.Add(student);
                    }
                }
            }
            return list;
        }
    }
}
