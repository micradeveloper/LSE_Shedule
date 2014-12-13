/*using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using LSE_Shedule.Constants;

namespace LSE_Shedule
{
    public class Settings
    {
        private XmlDocument _settingsFile;

        private string _defaultSettingsPath;

        public Settings()
        {
            Init("%APP_DATA%/t.xml");
        }

        public Settings(string path)
        {
            Init(path);
        }

        private void Init(string path)
        {
            _defaultSettingsPath = path;

            _settingsFile = new XmlDocument();

            if (!File.Exists(_defaultSettingsPath))
            {
                var txtWriter = new XmlTextWriter(_defaultSettingsPath, Encoding.UTF8);
                txtWriter.WriteStartDocument();
                txtWriter.WriteStartElement("Settings");
                txtWriter.WriteEndElement();
                txtWriter.Close();

                _settingsFile.Load(_defaultSettingsPath);
                XmlNode availableTime = _settingsFile.CreateElement("AvailableTime");
                if (_settingsFile.DocumentElement != null) _settingsFile.DocumentElement.AppendChild(availableTime);
                InsertDefaultAv(availableTime, AvTime.GetTimeList(), "time");

                XmlNode availableSubjects = _settingsFile.CreateElement("AvailableSubjects");
                if (_settingsFile.DocumentElement != null) _settingsFile.DocumentElement.AppendChild(availableSubjects);
                InsertDefaultAv(availableSubjects, AvSubjects.GetSubjectList(), "subject");

                XmlNode teachers = _settingsFile.CreateElement("Teachers");
                if (_settingsFile.DocumentElement != null) _settingsFile.DocumentElement.AppendChild(teachers);

                XmlNode students = _settingsFile.CreateElement("Students");
                if (_settingsFile.DocumentElement != null) _settingsFile.DocumentElement.AppendChild(students);

                _settingsFile.Save(_defaultSettingsPath);
            }
            _settingsFile.Load(_defaultSettingsPath);
        }

        private void InsertDefaultAv(XmlNode xmlNode, IEnumerable<string> elementsList, string tag)
        {
            var i = 1;
            foreach (var elementName in elementsList)
            {
                var currentTag = MakeTag(tag, i.ToString(CultureInfo.InvariantCulture), elementName);
                xmlNode.AppendChild(currentTag);
                ++i;
            }
        }

        private XmlNode MakeTag(string tagName, string attValue, string tagValue)
        {
            XmlNode currentNode = _settingsFile.CreateElement(tagName);
            if (attValue != string.Empty)
            {
                var attr = _settingsFile.CreateAttribute("idx");
                attr.Value = attValue;
                if (currentNode.Attributes != null) currentNode.Attributes.Append(attr);
            }
            currentNode.InnerText = tagValue;
            return currentNode;
        }
    }
}
*/