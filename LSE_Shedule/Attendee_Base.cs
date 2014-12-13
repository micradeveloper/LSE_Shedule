using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LSE_Shedule.Constants;

namespace LSE_Shedule
{
    public class Attendee
    {
        protected int Id;
        protected string Name;
        protected List<Subject> Subjects;
        protected List<BusyTime> BusyTime;

        public Attendee(string name, int id, List<Subject> subjects, List<BusyTime> busyTime)
        {
            Name = name;
            Subjects = subjects;
            BusyTime = busyTime;
            Id = id;
        }

        public Attendee(string name, int id, int rndSubjCount, int rndBusyTimeCount)
        {
            var helper = new Student("1", 1000,
                                    new List<Subject>(),
                                    new List<BusyTime>());
           
            var subjects = new List<Subject>();
            for (var j = 0; j < rndSubjCount; j++)
            {
                var subj = helper.GetRandomSubjectValue();

                while (Tools.IsDuplicated(subj, subjects))
                {
                    subj = helper.GetRandomSubjectValue();
                }
                subjects.Add(new Subject(subj));
            }

            var times = new List<BusyTime>();
            for (var j = 0; j < rndBusyTimeCount; j++)
            {
                var time = helper.GetRandomTimeValue();
                while (Tools.IsDuplicated(time, times))
                {
                    time = helper.GetRandomTimeValue();
                }
                times.Add(new BusyTime(time));
            }

            Name = name;
            Subjects = subjects;
            BusyTime = times;
            Id = id;
        }

        public List<int> GetDesiredSubjectsList()
        {
            return Subjects.Select(subjects => subjects.GetId()).ToList();
        }

        public List<int> GetBusyTimeList()
        {
            return BusyTime.Select(freeTime => freeTime.GetId()).ToList();
        }

        public int[] GetTimeMap()
        {
            var timeMap = new int[AvTime.GetObjList().Count];
            foreach (var idx in GetBusyTimeList())
            {
                timeMap[idx - 1] = 1;
            }
            return timeMap;
        }

        public int[] GetSubjectMap()
        {
            var subjectMap = new int[AvSubjects.GetObjList().Count];
            foreach (var idx in GetDesiredSubjectsList())
            {
                subjectMap[idx - 1] = 1;
            }
            return subjectMap;
        }

        public bool CanAtTime(int timeId)
        {
            return !(GetBusyTimeList().Contains(timeId));
        }
        
        public string GetRandomSubjectValue()
        {
            return AvSubjects.GetRandomValue();
        }

        public string GetRandomTimeValue()
        {
            return AvTime.GetRandomValue();
        }
    }

    public class Student : Attendee
    {

        public Student(string name, int id, List<Subject> subjects, List<BusyTime> busyTime) : base(name, id, subjects, busyTime)
        {
            Name = name;
            Subjects = subjects;
            BusyTime = busyTime;
            Id = id;
        }

        public Student(string name, int id, int rndSubjCount, int rndBusyTimeCount)
            : base(name, id, rndSubjCount, rndBusyTimeCount)
        {
            var helper = new Student("1", 1000,
                                   new List<Subject>(),
                                   new List<BusyTime>());

            var subjects = new List<Subject>();
            for (var j = 0; j < rndSubjCount; j++)
            {
                var subj = helper.GetRandomSubjectValue();

                while (Tools.IsDuplicated(subj, subjects))
                {
                    subj = helper.GetRandomSubjectValue();
                }
                subjects.Add(new Subject(subj));
            }

            var times = new List<BusyTime>();
            for (var j = 0; j < rndBusyTimeCount; j++)
            {
                var time = helper.GetRandomTimeValue();
                while (Tools.IsDuplicated(time, times))
                {
                    time = helper.GetRandomTimeValue();
                }
                times.Add(new BusyTime(time));
            }

            Name = name;
            Subjects = subjects;
            BusyTime = times;
            Id = id;
        }

        public new List<Subject> Subjects { get; set; }
        public new List<BusyTime> BusyTime { get; set; }
        public new string Name { get; set; }
        public new int Id { get; set; }
    }

    public class Teacher : Attendee 
    {
        public Teacher(string name, int id, List<Subject> subjects, List<BusyTime> busyTime) : base(name, id, subjects, busyTime)
        {
            Name = name;
            Subjects = subjects;
            BusyTime = busyTime;
            Id = id;
        }

        public new List<Subject> Subjects { get; set; }
        public new List<BusyTime> BusyTime { get; set; }
        public new string Name { get; set; }
        public new int Id { get; set; }
    }
}
