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
    public class Manager_Student_Progress
    {
        private static string file_path = "./xmls/Marks.xml";
        List<Student_Progress> marks;

        public Manager_Student_Progress()
        {
            this.marks = load_marks();
        }

        public List<Student_Progress> Marks { get => marks; }

        public static List<Student_Progress> load_marks()
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
            List<Student_Progress> marks = new List<Student_Progress>();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);
            XmlElement list = doc.DocumentElement;
            Manager_Students manager_Students = new Manager_Students();
            Manager_Tasks manager_Tasks = new Manager_Tasks();
            foreach (XmlElement elem in list.ChildNodes)
            {
                Student_Progress mark = new Student_Progress();
                foreach (XmlElement detale_elem in elem.ChildNodes)
                {
                    if (detale_elem.Name == "Id")
                    {
                        mark.Id = Int32.Parse(detale_elem.FirstChild.Value);
                    }
                    else if (detale_elem.Name == "Student_Id")
                    {
                        string student_id = detale_elem.FirstChild.Value;
                        mark.Student = manager_Students.SearchByID(student_id);
                    }
                    else if (detale_elem.Name == "Task_Id")
                    {
                        int task_id = Convert.ToInt32(detale_elem.FirstChild.Value);
                        mark.Task = manager_Tasks.SearchById(task_id);
                    }
                    else if (detale_elem.Name == "Variant")
                    {
                        mark.Variant = Convert.ToInt32(detale_elem.FirstChild.Value);
                    }
                    else if (detale_elem.Name == "Amount_of_Attemps")
                    {
                        mark.Amount_of_Attemps = Convert.ToInt32(detale_elem.FirstChild.Value);
                    }
                    else if (detale_elem.Name == "Completed_Date")
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
                        mark.Completed_Date = new DateTime(year, month, day, hour, minute, 0);
                    }
                    else if (detale_elem.Name == "Completed")
                    {
                        mark.Completed = Convert.ToBoolean(detale_elem.FirstChild.Value);
                    }
                    else if (detale_elem.Name == "Mark")
                    {
                        mark.Mark = Convert.ToInt32(detale_elem.FirstChild.Value);
                    }
                }
                marks.Add(mark);
            }
            return marks;
        }

        public void add(object item)
        {
            Student_Progress Mark = (Student_Progress)item;
            if (Mark.Id == 0)
            {
                //присваиваем вариант
                Mark.Variant = getVariant(Mark.Task);
                //присваиваем id
                Mark.Id = getMaxId();
                this.marks.Add(Mark);
            }
            else
            {
                foreach (Student_Progress mark in this.Marks)
                {
                    if (mark.Id == Mark.Id)
                    {
                        mark.Student = Mark.Student;
                        mark.Task = Mark.Task;
                        mark.Variant = Mark.Variant;
                        mark.Amount_of_Attemps = Mark.Amount_of_Attemps;
                        mark.Completed_Date = Mark.Completed_Date;
                        mark.Completed = Mark.Completed;
                        mark.Mark = Mark.Mark;
                    }
                }
            }
        }

        public void delete_by_task(Task task)//удаление всех оценок по передаваемому заданию
        {
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Task.Id == task.Id)
                {
                    this.Marks.RemoveAt(i);
                    i--;
                }
            }
        }

        public void delete_by_student(Student student)
        {
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Id == student.Id)
                {
                    this.Marks.RemoveAt(i);
                    i--;
                }
            }
        }

        public void save()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Student_Progress.file_path);
            XmlElement list = doc.DocumentElement;
            list.RemoveAll();
            foreach (Student_Progress mark in this.Marks)
            {
                XmlElement markx = doc.CreateElement("Mark");
                XmlElement mark_id = doc.CreateElement("Id");
                mark_id.InnerText = Convert.ToString(mark.Id);
                markx.AppendChild(mark_id);

                XmlElement student_id = doc.CreateElement("Student_Id");
                student_id.InnerText = Convert.ToString(mark.Student.Id);
                markx.AppendChild(student_id);

                XmlElement task_id = doc.CreateElement("Task_Id");
                task_id.InnerText = Convert.ToString(mark.Task.Id);
                markx.AppendChild(task_id);

                XmlElement task_variant = doc.CreateElement("Variant");
                task_variant.InnerText = Convert.ToString(mark.Variant);
                markx.AppendChild(task_variant);

                XmlElement amount_of_attemps = doc.CreateElement("Amount_of_Attemps");
                amount_of_attemps.InnerText = Convert.ToString(mark.Amount_of_Attemps);
                markx.AppendChild(amount_of_attemps);

                XmlElement completed_date = doc.CreateElement("Completed_Date");
                XmlElement day = doc.CreateElement("Day");
                day.InnerText = Convert.ToString(mark.Completed_Date.Day);
                completed_date.AppendChild(day);
                XmlElement month = doc.CreateElement("Month");
                month.InnerText = Convert.ToString(mark.Completed_Date.Month);
                completed_date.AppendChild(month);
                XmlElement year = doc.CreateElement("Year");
                year.InnerText = Convert.ToString(mark.Completed_Date.Year);
                completed_date.AppendChild(year);
                XmlElement hour = doc.CreateElement("Hour");
                hour.InnerText = Convert.ToString(mark.Completed_Date.Hour);
                completed_date.AppendChild(hour);
                XmlElement minute = doc.CreateElement("Minute");
                minute.InnerText = Convert.ToString(mark.Completed_Date.Minute);
                completed_date.AppendChild(minute);
                markx.AppendChild(completed_date);

                XmlElement completed = doc.CreateElement("Completed");
                completed.InnerText = Convert.ToString(mark.Completed);//ПРОВЕРИТЬ TRUE/FALSE
                markx.AppendChild(completed);

                XmlElement markel = doc.CreateElement("Mark");
                markel.InnerText = Convert.ToString(mark.Mark);
                markx.AppendChild(markel);

                list.AppendChild(markx);
            }
            doc.Save(Manager_Student_Progress.file_path);
        }

        private int getMaxId()
        {
            int max_id = 0;
            foreach (Student_Progress mark in Marks)
            {
                if (mark.Id > max_id)
                {
                    max_id = mark.Id;
                }
            }
            return (max_id + 1);
        }

        private int getVariant(Task task)
        {
            int max_variant = 0;
            foreach (Student_Progress mark in Marks)
            {
                if (mark.Task.Id == task.Id)
                {
                    if (mark.Variant > max_variant)
                    {
                        max_variant = mark.Variant;
                    }
                }
            }
            return (max_variant + 1);
        }

        public Student_Progress SearchByID(int id)
        {
            for (int i = 0; i < this.Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Id == id)
                {
                    return mark;
                }
            }
            return null;
        }

        public Student_Progress search_by_student_task(Student student, Task task)
        {
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Id == student.Id && mark.Task.Id == task.Id)
                {
                    return mark;
                }
            }
            return null;
        }

        public int count_debts_student(Discipline discipline, Student student)//количество долгов у определенного студента по определенной дисциплине
        {
            int count_debts = 0;
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Id == student.Id && mark.Task.Discipline.Id == discipline.Id && mark.Completed == false && mark.Task.Term < DateTime.Now)
                {
                    count_debts++;
                }
            }
            return count_debts;
        }

        public int count_attemps_student(Discipline discipline, Student student)//общее количество попыток сдачи заданий определенного студента по определенной дисциплине
        {
            int count_attemps = 0;
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Id == student.Id && mark.Task.Discipline.Id == discipline.Id)
                {
                    count_attemps += mark.Amount_of_Attemps;
                }
            }
            return count_attemps;
        }

        public int sum_mark(Student student, Discipline discipline)
        {
            int sum = 0;
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Id == student.Id && mark.Task.Discipline.Id == discipline.Id)
                {
                    sum += mark.Mark;
                }
            }
            return sum;
        }

        public List<Student_Progress> list_student_debt_tasks(Task task)//список студентов, у которых по передаваемому заданию есть задолженность
        {
            List<Student_Progress> list = new List<Student_Progress>();
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Task.Id == task.Id && mark.Completed == false)
                {
                    list.Add(mark);
                }
            }
            return list;
        }

        public List<Student_Progress> list_student_debts_time(Student student, Discipline discipline)//список долгов (просрочка) студента по определенной дисциплине
        {
            List<Student_Progress> list = new List<Student_Progress>();
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Id == student.Id && mark.Task.Discipline.Id == discipline.Id && mark.Completed == false && mark.Task.Term < DateTime.Now) 
                {
                    list.Add(mark);
                }
            }
            return list;
        }

        public List<Student_Progress> list_student_debts(Student student, Discipline discipline)//список долгов (в т.ч. у которых срок сдачи еще не истек) студента по определенной дисциплине
        {
            List<Student_Progress> list = new List<Student_Progress>();
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Id == student.Id && mark.Task.Discipline.Id == discipline.Id && mark.Completed == false)
                {
                    list.Add(mark);
                }
            }
            return list;
        }

        public bool check_term_delay(Student student)
        {
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Id == student.Id)
                {
                    if (mark.Completed == false && DateTime.Now > mark.Task.Term)
                        return true;
                }
            }
            return false;
        }

        public List<Student_Progress> list_student_marks(Student student, Discipline discipline)
        {
            List<Student_Progress> list = new List<Student_Progress>();
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Id == student.Id && mark.Task.Discipline.Id == discipline.Id)
                {
                    list.Add(mark);
                }
            }
            return list;
        }

        public bool check_best_student(Student student, Discipline discipline)
        {
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Id == student.Id && mark.Task.Discipline.Id == discipline.Id) 
                {
                    if (mark.Completed_Date > mark.Task.Term || mark.Completed == false)
                        return false;
                }
            }
            return true;
        }

        public List<Student_Progress> list_marks_by_group_task(Group group, Task task)
        {
            List<Student_Progress> list = new List<Student_Progress>();
            for (int i = 0; i < Marks.Count; i++)
            {
                Student_Progress mark = Marks[i];
                if (mark.Student.Group.Id == group.Id && mark.Task.Id == task.Id)
                {
                    list.Add(mark);
                }
            }
            return list;
        }

        public void assign_null_marks(Task task)//присваивание нуль оценок по передаваемому заданию студентам, которые к нему относятся
        {
            Manager_Students manager_Students = new Manager_Students();
            List<Student> students_for_task = manager_Students.SearchByGroup(task.Discipline.Group);
            foreach (Student student in students_for_task)
            {
                Student_Progress student_Progress = new Student_Progress(student, task);
                add(student_Progress);
            }
            save();
        }

        public void assign_null_mark_student(Student student)//при добавлении студента в группу ставим ему по всем заданиям, к которым он причастен, нули
        {
            Manager_Tasks manager_Tasks = new Manager_Tasks();
            foreach(Task task in manager_Tasks.Tasks)
            {
                if (task.Discipline.Group.Id == student.Group.Id)
                {
                    Student_Progress student_Progress = new Student_Progress(student, task);
                    add(student_Progress);
                }
            }
            save();
        }
    }
}
