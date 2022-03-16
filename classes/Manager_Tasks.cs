using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Курсовая_работа.classes
{
    public class Manager_Tasks
    {
        private static string file_path = "./xmls/Tasks.xml";
        List<Task> tasks;

        public Manager_Tasks()
        {
            this.tasks = load_tasks();
        }

        public List<Task> Tasks { get => tasks; }

        public static List<Task> load_tasks()
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
            List<Task> tasks = new List<Task>();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);
            XmlElement list = doc.DocumentElement;
            Manager_Disciplines manager_Disciplines = new Manager_Disciplines();
            foreach (XmlElement elem in list.ChildNodes)
            {
                Task task = new Task();
                foreach (XmlElement detale_elem in elem.ChildNodes)
                {
                    if (detale_elem.Name == "Id")
                    {
                        task.Id = Int32.Parse(detale_elem.FirstChild.Value);
                    }
                    else if (detale_elem.Name == "Name")
                    {
                        task.Name = detale_elem.FirstChild.Value;
                    }
                    else if (detale_elem.Name == "Discipline_Id")
                    {
                        int discipline_id = Convert.ToInt32(detale_elem.FirstChild.Value);
                        task.Discipline = manager_Disciplines.SearchById(discipline_id);
                    }
                    else if (detale_elem.Name == "Term")
                    {
                        int day = 0; int month = 0; int year = 0; int hour = 0; int minute = 0;
                        foreach (XmlElement term_elem in detale_elem.ChildNodes)
                        {
                            if (term_elem.Name == "Day")
                            {
                                day = Convert.ToInt32(term_elem.FirstChild.Value);
                            }
                            else if (term_elem.Name == "Month")
                            {
                                month = Convert.ToInt32(term_elem.FirstChild.Value);
                            }
                            else if (term_elem.Name == "Year")
                            {
                                year = Convert.ToInt32(term_elem.FirstChild.Value);
                            }
                            else if (term_elem.Name == "Hour")
                            {
                                hour = Convert.ToInt32(term_elem.FirstChild.Value);
                            }
                            else if (term_elem.Name == "Minute")
                            {
                                minute = Convert.ToInt32(term_elem.FirstChild.Value);
                            }
                        }
                        task.Term = new DateTime(year, month, day, hour, minute, 0);
                    }
                    else if (detale_elem.Name == "Type_of_Lesson")
                    {
                        task.Type_of_Lesson = detale_elem.FirstChild.Value;
                    }
                    else if (detale_elem.Name == "Theme_of_Lesson")
                    {
                        task.Theme_of_Lesson = detale_elem.FirstChild.Value;
                    }
                    else if (detale_elem.Name == "Serial_Number_of_Theme")
                    {
                        task.Serial_Number_of_Theme = Convert.ToInt32(detale_elem.FirstChild.Value);
                    }
                    else if (detale_elem.Name == "Max_Mark")
                    {
                        task.Max_Mark = Convert.ToInt32(detale_elem.FirstChild.Value);
                    }
                }
                tasks.Add(task);
            }
            return tasks;
        }

        public void add(object item)
        {
            Task Task = (Task)item;
            if (Task.Id == 0)
            {
                this.tasks.Add(Task);
            }
            else
            {
                foreach (Task task in this.Tasks)
                {
                    if (task.Id == Task.Id)
                    {
                        task.Name = Task.Name;
                        task.Discipline = Task.Discipline;
                        task.Term = Task.Term;
                        task.Type_of_Lesson = Task.Type_of_Lesson;
                        task.Theme_of_Lesson = Task.Theme_of_Lesson;
                        task.Serial_Number_of_Theme = Task.Serial_Number_of_Theme;
                        task.Max_Mark = Task.Max_Mark;
                    }
                }
            }
        }

        public void delete_by_id(int id)//удаление задания по id
        {
            for (int i = 0; i < this.Tasks.Count; i++)
            {
                Task task = (Task)this.Tasks[i];
                if (task.Id == id)
                {
                    this.Tasks.RemoveAt(i);
                    return;
                }
            }

        }

        public void delete_by_discipline(Discipline discipline)//удаление всех заданий и оценок по ним по передаваемой дисциплине
        {
            Manager_Student_Progress manager_Student_Progress = new Manager_Student_Progress();
            for (int i = 0; i < Tasks.Count; i++)
            {
                Task task = Tasks[i];
                if (task.Discipline.Id == discipline.Id)
                {
                    manager_Student_Progress.delete_by_task(task);
                    manager_Student_Progress.save();
                    this.Tasks.RemoveAt(i);
                    i--;
                }
            }
        }

        public void save()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Tasks.file_path);
            XmlElement list = doc.DocumentElement;
            list.RemoveAll();
            foreach (Task task in this.Tasks)
            {
                task.Id = task.Id == 0 ? this.getMaxId() + 1 : task.Id;
                XmlElement taskx = doc.CreateElement("Task");
                XmlElement task_id = doc.CreateElement("Id");
                task_id.InnerText = Convert.ToString(task.Id);
                taskx.AppendChild(task_id);

                XmlElement task_name = doc.CreateElement("Name");
                task_name.InnerText = task.Name;
                taskx.AppendChild(task_name);

                XmlElement discipline_id = doc.CreateElement("Discipline_Id");
                discipline_id.InnerText = Convert.ToString(task.Discipline.Id);
                taskx.AppendChild(discipline_id);

                XmlElement task_term = doc.CreateElement("Term");
                XmlElement day = doc.CreateElement("Day");
                day.InnerText = Convert.ToString(task.Term.Day);
                task_term.AppendChild(day);
                XmlElement month = doc.CreateElement("Month");
                month.InnerText = Convert.ToString(task.Term.Month);
                task_term.AppendChild(month);
                XmlElement year = doc.CreateElement("Year");
                year.InnerText = Convert.ToString(task.Term.Year);
                task_term.AppendChild(year);
                XmlElement hour = doc.CreateElement("Hour");
                hour.InnerText = Convert.ToString(task.Term.Hour);
                task_term.AppendChild(hour);
                XmlElement minute = doc.CreateElement("Minute");
                minute.InnerText = Convert.ToString(task.Term.Minute);
                task_term.AppendChild(minute);
                taskx.AppendChild(task_term);

                XmlElement task_type_of_lesson = doc.CreateElement("Type_of_Lesson");
                task_type_of_lesson.InnerText = task.Type_of_Lesson;
                taskx.AppendChild(task_type_of_lesson);

                XmlElement task_theme_of_lesson = doc.CreateElement("Theme_of_Lesson");
                task_theme_of_lesson.InnerText = task.Theme_of_Lesson;
                taskx.AppendChild(task_theme_of_lesson);

                XmlElement task_serial_number_of_theme = doc.CreateElement("Serial_Number_of_Theme");
                task_serial_number_of_theme.InnerText = Convert.ToString(task.Serial_Number_of_Theme);
                taskx.AppendChild(task_serial_number_of_theme);

                XmlElement task_max_mark = doc.CreateElement("Max_Mark");
                task_max_mark.InnerText = Convert.ToString(task.Max_Mark);
                taskx.AppendChild(task_max_mark);
                list.AppendChild(taskx);
            }
            doc.Save(Manager_Tasks.file_path);
        }

        private int getMaxId()
        {
            int max_id = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Tasks.file_path);
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

        public Task SearchById(int id)
        {
            for (int i = 0; i < this.Tasks.Count; i++)
            {
                Task task = (Task)this.Tasks[i];
                if (task.Id == id)
                {
                    return task;
                }
            }
            return null;
        }

        public Task SearchByName(string name)
        {
            foreach (Task task in Tasks)
            {
                if (task.Name == name)
                {
                    return task;
                }
            }
            return null;
        }

        public List<Task> SearchByDiscipline(Discipline discipline)
        {
            List<Task> tasks_for_discipline = new List<Task>();
            foreach (Task task in Tasks)
            {
                if (task.Discipline.Id == discipline.Id)
                {
                    tasks_for_discipline.Add(task);
                }
            }
            return tasks_for_discipline;
        }

        public List<Task> list_debt_tasks(Discipline discipline)
        {
            List<Task> list = new List<Task>();
            for (int i = 0; i < tasks.Count; i++)
            {
                Task task = Tasks[i];
                if (task.Discipline.Id == discipline.Id && task.Term < DateTime.Now) 
                {
                    list.Add(task);
                }
            }
            return list;
        }

        public Task search_by_serial_number(int SN, Discipline discipline)
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                Task task = Tasks[i];
                if (task.Discipline.Id == discipline.Id && task.Serial_Number_of_Theme == SN)
                {
                    return task;
                }
            }
            return null;
        }

        public bool checking_serial_number(int SN, Discipline discipline)
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                Task task = Tasks[i];
                if (task.Discipline.Id == discipline.Id && task.Serial_Number_of_Theme == SN)
                {
                    return true;
                }
            }
            return false;
        }

        public int sum_max_mark(Discipline discipline)
        {
            int sum = 0;
            for (int i = 0; i < Tasks.Count; i++)
            {
                Task task = Tasks[i];
                if (task.Discipline.Id == discipline.Id)
                {
                    sum += task.Max_Mark;
                }
            }
            return sum;
        }
    }
}
