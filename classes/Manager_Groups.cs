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
    public class Manager_Groups
    {
        private static string file_path = "./xmls/Groups.xml";
        private List<Group> groups;

        public Manager_Groups()
        {
            this.groups = Manager_Groups.load_groups();
        }

        public List<Group> Groups { get => groups; }

        private static List<Group> load_groups()
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
            List<Group> groups = new List<Group>();
            XmlDocument doc = new XmlDocument();
            doc.Load(file_path);
            XmlElement list = doc.DocumentElement;
            foreach (XmlElement elem in list.ChildNodes)
            {
                Group group = new Group();
                foreach (XmlElement detale_elem in elem.ChildNodes)
                {
                    if (detale_elem.Name == "Id")
                    {
                        group.Id = Int32.Parse(detale_elem.FirstChild.Value);
                    }
                    else if (detale_elem.Name == "Name")
                    {
                        group.Name = detale_elem.FirstChild.Value;
                    }
                    else if (detale_elem.Name == "Speciality")
                    {
                        group.Speciality = detale_elem.FirstChild.Value;
                    }
                    else if (detale_elem.Name == "Course")
                    {
                        group.Course = Int32.Parse(detale_elem.FirstChild.Value);
                    }
                    else if (detale_elem.Name == "Faculty")
                    {
                        group.Faculty = detale_elem.FirstChild.Value;
                    }
                }
                groups.Add(group);
            }

            return groups;
        }

        public void add(object item)
        {
            Group Group = (Group)item;
            if (Group.Id == 0)
            {
                this.groups.Add(Group);
            }
            else
            {
                foreach (Group group in this.Groups)
                {
                    if (group.Id == Group.Id)
                    {
                        group.Name = Group.Name;
                        group.Speciality = Group.Speciality;
                        group.Course = Group.Course;
                        group.Faculty = Group.Faculty;
                    }
                }
            }
        }

        public void delete_by_id(int id)
        {
            for (int i = 0; i < this.Groups.Count; i++)
            {
                Group group = (Group)this.Groups[i];
                if (group.Id == id)
                {
                    this.Groups.RemoveAt(i);
                    return;
                }
            }

        }

        public void save()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Groups.file_path);
            XmlElement list = doc.DocumentElement;
            list.RemoveAll();
            foreach (Group group in this.Groups)
            {
                group.Id = group.Id == 0 ? this.getMaxId() + 1 : group.Id;
                XmlElement groupx = doc.CreateElement("group");
                XmlElement group_id = doc.CreateElement("Id");
                group_id.InnerText = Convert.ToString(group.Id);
                groupx.AppendChild(group_id);

                XmlElement group_name = doc.CreateElement("Name");
                group_name.InnerText = group.Name;
                groupx.AppendChild(group_name);

                XmlElement group_speciality = doc.CreateElement("Speciality");
                group_speciality.InnerText = group.Speciality;
                groupx.AppendChild(group_speciality);

                XmlElement group_course = doc.CreateElement("Course");
                group_course.InnerText = Convert.ToString(group.Course);
                groupx.AppendChild(group_course);

                XmlElement group_faculty = doc.CreateElement("Faculty");
                group_faculty.InnerText = group.Faculty;
                groupx.AppendChild(group_faculty);
                list.AppendChild(groupx);
            }

            doc.Save(Manager_Groups.file_path);
        }

        private int getMaxId()
        {
            int max_id = 0;
            XmlDocument doc = new XmlDocument();
            doc.Load(Manager_Groups.file_path);
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

        public Group SearchByID(int id)
        {
            for (int i = 0; i < this.Groups.Count; i++)
            {
                Group group = (Group)this.Groups[i];
                if (group.Id == id)
                {
                    return group;
                }
            }
            return null;
        }

        public Group SearchByName(string name)
        {
            foreach(Group group in Groups)
            {
                if (group.Name==name)
                {
                    return group;
                }
            }
            return null;
        }

        public bool check_same_name(string name)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                Group group = Groups[i];
                if (group.Name == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
