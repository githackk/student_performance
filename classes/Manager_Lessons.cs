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
    public class Manager_Lessons
    {
        private static string file_path = "./xmls/Lessons.xml";
        private List<Additional_Lesson> additional_lessons;
        private List<Current_Lesson> current_lessons;
        private List<Distance_Lesson> distance_lessons;

        public Manager_Lessons()
        {
            this.additional_lessons = Manager_Lessons.load_additional_lessons();
            this.current_lessons = Manager_Lessons.load_current_lessons();
            this.distance_lessons = Manager_Lessons.load_distance_lessons();
        }

        public List<Additional_Lesson> Additional_Lessons { get => additional_lessons; }
        public List<Current_Lesson> Current_Lessons { get => current_lessons; }
        public List<Distance_Lesson> Distance_Lessons { get => distance_lessons; }

        private static List<Additional_Lesson> load_additional_lessons()
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
            List<Additional_Lesson> additional_lessons = new List<Additional_Lesson>();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);
            XmlElement list = doc.DocumentElement;
            Manager_Disciplines manager_Disciplines = new Manager_Disciplines();
            Manager_Groups manager_Groups = new Manager_Groups();

            foreach (XmlElement sublist in list.ChildNodes)
            {
                if (sublist.Name == "Additional_Lessons")
                {
                    foreach (XmlElement elem in sublist.ChildNodes)
                    {
                        Additional_Lesson additional_lesson = new Additional_Lesson();
                        foreach (XmlElement detale_elem in elem.ChildNodes)
                        {
                            if (detale_elem.Name == "Id")
                            {
                                additional_lesson.Id = detale_elem.FirstChild.Value;
                            }
                            else if (detale_elem.Name == "Date_of_Lesson")
                            {
                                int day = 0; int month = 0; int year = 0; int hour = 0; int minute = 0;
                                foreach (XmlElement date_of_lesson in detale_elem.ChildNodes)
                                {
                                    if (date_of_lesson.Name == "Day")
                                    {
                                        day = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Month")
                                    {
                                        month = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Year")
                                    {
                                        year = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Hour")
                                    {
                                        hour = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Minute")
                                    {
                                        minute = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                }
                                additional_lesson.Date_of_Lesson = new DateTime(year, month, day, hour, minute, 0);
                            }
                            else if (detale_elem.Name == "Discipline_Id")
                            {
                                int discipline_id = Convert.ToInt32(detale_elem.FirstChild.Value);
                                additional_lesson.Discipline = manager_Disciplines.SearchById(discipline_id);
                            }
                            else if (detale_elem.Name == "Group_Id")
                            {
                                int group_id = Convert.ToInt32(detale_elem.FirstChild.Value);//в xml файле будет храниться id группы, с помощью него мы потом узнаем все остальные данные группы
                                additional_lesson.Group = manager_Groups.SearchByID(group_id);
                            }
                            else if (detale_elem.Name == "Audience_Number") 
                            {
                                additional_lesson.Audience_Number = detale_elem.FirstChild.Value;
                            }
                        }
                        additional_lessons.Add(additional_lesson);
                    }
                    
                }
                
            }

            return additional_lessons;
        }

        private static List<Current_Lesson> load_current_lessons()
        {
            List<Current_Lesson> current_lessons = new List<Current_Lesson>();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);
            XmlElement list = doc.DocumentElement;
            Manager_Disciplines manager_Disciplines = new Manager_Disciplines();
            Manager_Groups manager_Groups = new Manager_Groups();
            Manager_Tasks manager_Tasks = new Manager_Tasks();
            foreach (XmlElement sublist in list.ChildNodes)
            {
                if (sublist.Name == "Current_Lessons")
                {
                    foreach (XmlElement elem in sublist.ChildNodes)
                    {
                        Current_Lesson current_lesson = new Current_Lesson();
                        foreach (XmlElement detale_elem in elem.ChildNodes)
                        {
                            if (detale_elem.Name == "Id")
                            {
                                current_lesson.Id = detale_elem.FirstChild.Value;
                            }
                            else if (detale_elem.Name == "Date_of_Lesson")
                            {
                                int day = 0; int month = 0; int year = 0; int hour = 0; int minute = 0;
                                foreach (XmlElement date_of_lesson in detale_elem.ChildNodes)
                                {
                                    if (date_of_lesson.Name == "Day")
                                    {
                                        day = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Month")
                                    {
                                        month = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Year")
                                    {
                                        year = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Hour")
                                    {
                                        hour = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Minute")
                                    {
                                        minute = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                }
                                current_lesson.Date_of_Lesson = new DateTime(year, month, day, hour, minute, 0);
                            }
                            else if (detale_elem.Name == "Discipline_Id")
                            {
                                int discipline_id = Convert.ToInt32(detale_elem.FirstChild.Value);
                                current_lesson.Discipline = manager_Disciplines.SearchById(discipline_id);
                            }
                            else if (detale_elem.Name == "Group_Id")
                            {
                                int group_id = Convert.ToInt32(detale_elem.FirstChild.Value);//в xml файле будет храниться id группы, с помощью него мы потом узнаем все остальные данные группы
                                current_lesson.Group = manager_Groups.SearchByID(group_id);
                            }
                            else if (detale_elem.Name == "Task_Id")
                            {
                                int task_id = Convert.ToInt32(detale_elem.FirstChild.Value);
                                current_lesson.Task = manager_Tasks.SearchById(task_id);
                            }
                            else if (detale_elem.Name == "Audience_Number")
                            {
                                current_lesson.Audience_Number = detale_elem.FirstChild.Value;
                            }
                        }
                        current_lessons.Add(current_lesson);
                    }
                }
            }
            return current_lessons;
        }

        private static List<Distance_Lesson> load_distance_lessons()
        {
            List<Distance_Lesson> distance_lessons = new List<Distance_Lesson>();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);
            XmlElement list = doc.DocumentElement;
            foreach (XmlElement sublist in list.ChildNodes)
            {
                if (sublist.Name == "Distance_Lessons")
                {
                    foreach (XmlElement elem in sublist.ChildNodes)
                    {
                        Distance_Lesson distance_lesson = new Distance_Lesson();
                        foreach (XmlElement detale_elem in elem.ChildNodes)
                        {
                            if (detale_elem.Name == "Id")
                            {
                                distance_lesson.Id = detale_elem.FirstChild.Value;
                            }
                            else if (detale_elem.Name == "Date_of_Lesson")
                            {
                                int day = 0; int month = 0; int year = 0; int hour = 0; int minute = 0;
                                foreach (XmlElement date_of_lesson in detale_elem.ChildNodes)
                                {
                                    if (date_of_lesson.Name == "Day")
                                    {
                                        day = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Month")
                                    {
                                        month = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Year")
                                    {
                                        year = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Hour")
                                    {
                                        hour = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                    else if (date_of_lesson.Name == "Minute")
                                    {
                                        minute = Convert.ToInt32(date_of_lesson.FirstChild.Value);
                                    }
                                }
                                distance_lesson.Date_of_Lesson = new DateTime(year, month, day, hour, minute, 0);
                            }
                            else if (detale_elem.Name == "Discipline_Id")
                            {
                                int discipline_id = Convert.ToInt32(detale_elem.FirstChild.Value);
                                Manager_Disciplines manager_Disciplines = new Manager_Disciplines();
                                distance_lesson.Discipline = manager_Disciplines.SearchById(discipline_id);
                            }
                            else if (detale_elem.Name == "Group_Id")
                            {
                                int group_id = Convert.ToInt32(detale_elem.FirstChild.Value);//в xml файле будет храниться id группы, с помощью него мы потом узнаем все остальные данные группы
                                Manager_Groups manager_Groups = new Manager_Groups();
                                distance_lesson.Group = manager_Groups.SearchByID(group_id);
                            }
                            else if (detale_elem.Name == "Student_Id")
                            {
                                string student_id = detale_elem.FirstChild.Value;
                                Manager_Students manager_Students = new Manager_Students();
                                distance_lesson.Student = manager_Students.SearchByID(student_id);
                            }
                            else if (detale_elem.Name == "Conference_Id")
                            {
                                distance_lesson.Conference_Id = detale_elem.FirstChild.Value;
                            }
                            else if (detale_elem.Name == "Conference_Password")
                            {
                                distance_lesson.Conference_Password = detale_elem.FirstChild.Value;
                            }
                        }
                        distance_lessons.Add(distance_lesson);
                    }
                }
            }
            return distance_lessons;
        }

        public void add_AdLe(object item)
        {
            Additional_Lesson Additional_Lesson = (Additional_Lesson)item;
            if (Additional_Lesson.Id == "")
            {
                this.additional_lessons.Add(Additional_Lesson);
            }
            else
            {
                foreach (Additional_Lesson additional_Lesson in this.Additional_Lessons)
                {
                    if (additional_Lesson.Id == Additional_Lesson.Id)
                    {
                        additional_Lesson.Date_of_Lesson = Additional_Lesson.Date_of_Lesson;
                        additional_Lesson.Discipline = Additional_Lesson.Discipline;
                        additional_Lesson.Group = Additional_Lesson.Group;
                        additional_Lesson.Audience_Number = Additional_Lesson.Audience_Number;
                    }
                }
            }
        }

        public void add_CuLe(object item)
        {
            Current_Lesson Current_Lesson = (Current_Lesson)item;
            if (Current_Lesson.Id == "")
            {
                this.current_lessons.Add(Current_Lesson);
            }
            else
            {
                foreach (Current_Lesson current_Lesson in this.Current_Lessons)
                {
                    if (current_Lesson.Id == Current_Lesson.Id)
                    {
                        current_Lesson.Date_of_Lesson = Current_Lesson.Date_of_Lesson;
                        current_Lesson.Discipline = Current_Lesson.Discipline;
                        current_Lesson.Group = Current_Lesson.Group;
                        current_Lesson.Task = Current_Lesson.Task;
                        current_Lesson.Audience_Number = Current_Lesson.Audience_Number;
                    }
                }
            }
        }

        public void add_DiLe(object item)
        {
            Distance_Lesson Distance_Lesson = (Distance_Lesson)item;
            if (Distance_Lesson.Id == "")
            {
                this.distance_lessons.Add(Distance_Lesson);
            }
            else
            {
                foreach (Distance_Lesson distance_Lesson in this.Distance_Lessons)
                {
                    if (distance_Lesson.Id == Distance_Lesson.Id)
                    {
                        distance_Lesson.Date_of_Lesson = Distance_Lesson.Date_of_Lesson;
                        distance_Lesson.Discipline = Distance_Lesson.Discipline;
                        distance_Lesson.Group = Distance_Lesson.Group;
                        distance_Lesson.Student = Distance_Lesson.Student;
                        distance_Lesson.Conference_Id = Distance_Lesson.Conference_Id;
                        distance_Lesson.Conference_Password = Distance_Lesson.Conference_Password;
                    }
                }
            }
        }

        public void delete_by_id(string id)//удаляет занятие по id
        {
            if (id.Substring(0, 2) == "AL")
            {
                for (int i = 0; i < this.Additional_Lessons.Count; i++)
                {
                    Additional_Lesson additional_Lesson = (Additional_Lesson)this.Additional_Lessons[i];
                    if (additional_Lesson.Id == id)
                    {
                        this.Additional_Lessons.RemoveAt(i);
                        return;
                    }
                }
            }
            else if (id.Substring(0, 2) == "CL")
            {
                for (int i = 0; i < this.Current_Lessons.Count; i++)
                {
                    Current_Lesson current_Lesson = (Current_Lesson)this.Current_Lessons[i];
                    if (current_Lesson.Id == id)
                    {
                        this.Current_Lessons.RemoveAt(i);
                        return;
                    }
                }
            }
            else if (id.Substring(0, 2) == "DL")
            {
                for (int i = 0; i < this.Distance_Lessons.Count; i++)
                {
                    Distance_Lesson distance_Lesson = (Distance_Lesson)this.Distance_Lessons[i];
                    if (distance_Lesson.Id == id)
                    {
                        this.Distance_Lessons.RemoveAt(i);
                        return;
                    }
                }
            }
        }

        public void delete_by_discipline(Discipline discipline)//удаляет занятия по передаваемой дисциплине
        {
            for (int i = 0; i < Current_Lessons.Count; i++)
            {
                Current_Lesson current_Lesson = Current_Lessons[i];
                if (current_Lesson.Discipline.Id == discipline.Id)
                {
                    this.Current_Lessons.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < Additional_Lessons.Count; i++)
            {
                Additional_Lesson additional_Lesson = Additional_Lessons[i];
                if (additional_Lesson.Discipline.Id == discipline.Id)
                {
                    this.Additional_Lessons.RemoveAt(i);
                    i--;
                }
            }
            for (int i = 0; i < Distance_Lessons.Count; i++)
            {
                Distance_Lesson distance_Lesson = Distance_Lessons[i];
                if (distance_Lesson.Discipline.Id == discipline.Id)
                {
                    this.Distance_Lessons.RemoveAt(i);
                    i--;
                }
            }
        }

        public void delete_by_task(Task task)//удаляет занятия по передаваемому заданию (только текущие)
        {
            for (int i = 0; i < Current_Lessons.Count; i++)
            {
                Current_Lesson current_Lesson = Current_Lessons[i];
                if (current_Lesson.Task.Id == task.Id)
                {
                    this.Current_Lessons.RemoveAt(i);
                    i--;
                }
            }
        }

        public void delete_by_student(Student student)//удаляет занятия с передаваемым студентом (только дистанционные)
        {
            for (int i = 0; i < Distance_Lessons.Count; i++) 
            {
                Distance_Lesson distance_Lesson = Distance_Lessons[i];
                if (distance_Lesson.Student.Id == student.Id)
                {
                    this.Distance_Lessons.RemoveAt(i);
                    i--;
                }
            }
        }

        public void save()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Lessons.file_path);
            XmlElement list = doc.DocumentElement;
            list.RemoveAll();
            XmlElement sublist1 = doc.CreateElement("Additional_Lessons");
            foreach (Additional_Lesson additional_lesson in this.Additional_Lessons)
            {
                additional_lesson.Id = additional_lesson.Id == "" ? this.get_Id_AdLe() : additional_lesson.Id;
                
                XmlElement additional_lessonx = doc.CreateElement("Additional_Lesson");
                XmlElement lesson_id = doc.CreateElement("Id");
                lesson_id.InnerText = additional_lesson.Id;
                additional_lessonx.AppendChild(lesson_id);

                XmlElement lesson_date = doc.CreateElement("Date_of_Lesson");
                XmlElement day = doc.CreateElement("Day");
                day.InnerText = Convert.ToString(additional_lesson.Date_of_Lesson.Day);
                lesson_date.AppendChild(day);
                XmlElement month = doc.CreateElement("Month");
                month.InnerText = Convert.ToString(additional_lesson.Date_of_Lesson.Month);
                lesson_date.AppendChild(month);
                XmlElement year = doc.CreateElement("Year");
                year.InnerText = Convert.ToString(additional_lesson.Date_of_Lesson.Year);
                lesson_date.AppendChild(year);
                XmlElement hour = doc.CreateElement("Hour");
                hour.InnerText = Convert.ToString(additional_lesson.Date_of_Lesson.Hour);
                lesson_date.AppendChild(hour);
                XmlElement minute = doc.CreateElement("Minute");
                minute.InnerText = Convert.ToString(additional_lesson.Date_of_Lesson.Minute);
                lesson_date.AppendChild(minute);
                additional_lessonx.AppendChild(lesson_date);

                XmlElement discipline_id = doc.CreateElement("Discipline_Id");
                discipline_id.InnerText = Convert.ToString(additional_lesson.Discipline.Id);
                additional_lessonx.AppendChild(discipline_id);

                XmlElement group_id = doc.CreateElement("Group_Id");
                group_id.InnerText = Convert.ToString(additional_lesson.Group.Id);
                additional_lessonx.AppendChild(group_id);

                XmlElement audience_number = doc.CreateElement("Audience_Number");
                audience_number.InnerText = additional_lesson.Audience_Number;
                additional_lessonx.AppendChild(audience_number);
                sublist1.AppendChild(additional_lessonx);
            }
            list.AppendChild(sublist1);

            XmlElement sublist2 = doc.CreateElement("Current_Lessons");
            foreach (Current_Lesson current_lesson in this.Current_Lessons)
            {
                current_lesson.Id = current_lesson.Id == "" ? this.get_Id_CuLe() : current_lesson.Id;

                XmlElement current_lessonx = doc.CreateElement("Current_Lesson");
                XmlElement lesson_id = doc.CreateElement("Id");
                lesson_id.InnerText = current_lesson.Id;
                current_lessonx.AppendChild(lesson_id);

                XmlElement lesson_date = doc.CreateElement("Date_of_Lesson");
                XmlElement day = doc.CreateElement("Day");
                day.InnerText = Convert.ToString(current_lesson.Date_of_Lesson.Day);
                lesson_date.AppendChild(day);
                XmlElement month = doc.CreateElement("Month");
                month.InnerText = Convert.ToString(current_lesson.Date_of_Lesson.Month);
                lesson_date.AppendChild(month);
                XmlElement year = doc.CreateElement("Year");
                year.InnerText = Convert.ToString(current_lesson.Date_of_Lesson.Year);
                lesson_date.AppendChild(year);
                XmlElement hour = doc.CreateElement("Hour");
                hour.InnerText = Convert.ToString(current_lesson.Date_of_Lesson.Hour);
                lesson_date.AppendChild(hour);
                XmlElement minute = doc.CreateElement("Minute");
                minute.InnerText = Convert.ToString(current_lesson.Date_of_Lesson.Minute);
                lesson_date.AppendChild(minute);
                current_lessonx.AppendChild(lesson_date);

                XmlElement discipline_id = doc.CreateElement("Discipline_Id");
                discipline_id.InnerText = Convert.ToString(current_lesson.Discipline.Id);
                current_lessonx.AppendChild(discipline_id);

                XmlElement group_id = doc.CreateElement("Group_Id");
                group_id.InnerText = Convert.ToString(current_lesson.Group.Id);
                current_lessonx.AppendChild(group_id);

                XmlElement task_id = doc.CreateElement("Task_Id");
                task_id.InnerText = Convert.ToString(current_lesson.Task.Id);
                current_lessonx.AppendChild(task_id);

                XmlElement audience_number = doc.CreateElement("Audience_Number");
                audience_number.InnerText = current_lesson.Audience_Number;
                current_lessonx.AppendChild(audience_number);
                sublist2.AppendChild(current_lessonx);
            }
            list.AppendChild(sublist2);

            XmlElement sublist3 = doc.CreateElement("Distance_Lessons");
            foreach (Distance_Lesson distance_lesson in this.Distance_Lessons)
            {
                distance_lesson.Id = distance_lesson.Id == "" ? this.get_Id_DiLe() : distance_lesson.Id;

                XmlElement distance_lessonx = doc.CreateElement("Distance_Lesson");
                XmlElement lesson_id = doc.CreateElement("Id");
                lesson_id.InnerText = distance_lesson.Id;
                distance_lessonx.AppendChild(lesson_id);

                XmlElement lesson_date = doc.CreateElement("Date_of_Lesson");
                XmlElement day = doc.CreateElement("Day");
                day.InnerText = Convert.ToString(distance_lesson.Date_of_Lesson.Day);
                lesson_date.AppendChild(day);
                XmlElement month = doc.CreateElement("Month");
                month.InnerText = Convert.ToString(distance_lesson.Date_of_Lesson.Month);
                lesson_date.AppendChild(month);
                XmlElement year = doc.CreateElement("Year");
                year.InnerText = Convert.ToString(distance_lesson.Date_of_Lesson.Year);
                lesson_date.AppendChild(year);
                XmlElement hour = doc.CreateElement("Hour");
                hour.InnerText = Convert.ToString(distance_lesson.Date_of_Lesson.Hour);
                lesson_date.AppendChild(hour);
                XmlElement minute = doc.CreateElement("Minute");
                minute.InnerText = Convert.ToString(distance_lesson.Date_of_Lesson.Minute);
                lesson_date.AppendChild(minute);
                distance_lessonx.AppendChild(lesson_date);

                XmlElement discipline_id = doc.CreateElement("Discipline_Id");
                discipline_id.InnerText = Convert.ToString(distance_lesson.Discipline.Id);
                distance_lessonx.AppendChild(discipline_id);

                XmlElement group_id = doc.CreateElement("Group_Id");
                group_id.InnerText = Convert.ToString(distance_lesson.Group.Id);
                distance_lessonx.AppendChild(group_id);

                XmlElement student_id = doc.CreateElement("Student_Id");
                student_id.InnerText = Convert.ToString(distance_lesson.Student.Id);
                distance_lessonx.AppendChild(student_id);

                XmlElement conference_id = doc.CreateElement("Conference_Id");
                conference_id.InnerText = distance_lesson.Conference_Id;
                distance_lessonx.AppendChild(conference_id);

                XmlElement conference_password = doc.CreateElement("Conference_Password");
                conference_password.InnerText = distance_lesson.Conference_Password;
                distance_lessonx.AppendChild(conference_password);
                sublist3.AppendChild(distance_lessonx);
            }
            list.AppendChild(sublist3);
            doc.Save(Manager_Lessons.file_path);
        }

        private string get_Id_AdLe()//выдает id для дополнительных занятий
        {
            const string str = "AL";
            int max_id = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Lessons.file_path);
            XmlElement list = doc.DocumentElement;
            foreach (XmlElement sublist in list.ChildNodes)
            {
                if (sublist.Name == "Additional_Lessons")
                {
                    foreach (XmlElement elem in sublist.ChildNodes)
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
                }
            }
            return (str + (max_id + 1));
        }

        private string get_Id_CuLe()//выдает id для текущих занятий
        {
            const string str = "CL";
            int max_id = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Lessons.file_path);
            XmlElement list = doc.DocumentElement;
            foreach (XmlElement sublist in list.ChildNodes)
            {
                if (sublist.Name == "Current_Lessons")
                {
                    foreach (XmlElement elem in sublist.ChildNodes)
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
                }
            }
            return (str + (max_id + 1));
        }

        private string get_Id_DiLe()//выдает id для дистанционных занятий
        {
            const string str = "DL";
            int max_id = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Lessons.file_path);
            XmlElement list = doc.DocumentElement;
            foreach (XmlElement sublist in list.ChildNodes)
            {
                if (sublist.Name == "Distance_Lessons")
                {
                    foreach (XmlElement elem in sublist.ChildNodes)
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
                }
            }
            return (str + (max_id + 1));
        }

        public Additional_Lesson SearchByIdAL(string id)
        {
            for (int i = 0; i < this.Additional_Lessons.Count; i++)
            {
                Additional_Lesson additional_Lesson = (Additional_Lesson)this.Additional_Lessons[i];
                if (additional_Lesson.Id == id)
                {
                    return additional_Lesson;
                }
            }
            return null;
        }

        public Current_Lesson SearchByIdCL(string id)
        {
            for (int i = 0; i < this.Current_Lessons.Count; i++)
            {
                Current_Lesson current_Lesson = (Current_Lesson)this.Current_Lessons[i];
                if (current_Lesson.Id == id)
                {
                    return current_Lesson;
                }
            }
            return null;
        }

        public Distance_Lesson SearchByIdDL(string id)
        {
            for (int i = 0; i < this.Distance_Lessons.Count; i++)
            {
                Distance_Lesson distance_Lesson = (Distance_Lesson)this.Distance_Lessons[i];
                if (distance_Lesson.Id == id)
                {
                    return distance_Lesson;
                }
            }
            return null;
        }

    }
}
