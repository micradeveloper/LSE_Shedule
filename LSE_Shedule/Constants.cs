using System;
using System.Collections.Generic;
using System.Linq;
using Enumerable = System.Linq.Enumerable;

namespace LSE_Shedule
{
    namespace Constants
    {
        public static class Tools
        {
            //Function to get random number
            private static readonly Random Getrandom = new Random();
            private static readonly object SyncLock = new object();
            public static int GetRandomNumber(int min, int max)
            {
                lock (SyncLock)
                { // synchronize
                    return Getrandom.Next(min, max);
                }
            }

            public static bool IsDuplicated(string value, List<Subject> list)
            {
                return list.Any(item => item.GetValue().Equals(value));
            }

            public static bool IsDuplicated(string value, List<BusyTime> list)
            {
                return list.Any(item => item.GetValue().Equals(value));
            }

        }

        internal static class AvSubjects
        {
            private static readonly List<KeyValuePair<int, string>> SubjectList;

            static AvSubjects()
            {
                SubjectList = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "Subject №1"),
                    new KeyValuePair<int, string>(2, "Subject №2"),
                    new KeyValuePair<int, string>(3, "Subject №3"),
                    new KeyValuePair<int, string>(4, "Subject №4"),
                    /*new KeyValuePair<int, string>(5, "Subject №5"),
                    new KeyValuePair<int, string>(6, "Subject №6"),
                    new KeyValuePair<int, string>(7, "Subject №7"),
                    new KeyValuePair<int, string>(8, "Subject №8"),
                    new KeyValuePair<int, string>(9, "Subject №9"),*/

                };
            }

            public static string GetTag()
            {
                return "subject";
            }

            public static List<int> GetIdList()
            {
                var idList = Enumerable.ToList(Enumerable.Select(SubjectList, subject => subject.Key));
                return idList;
            }

            public static List<string> GetValueList()
            {
                var idList = Enumerable.ToList(Enumerable.Select(SubjectList, subject => subject.Value));
                return idList;
            }

            public static List<KeyValuePair<int, string>> GetObjList()
            {
                return SubjectList;
            }

            public static string GetRandomValue()
            {
                return SubjectList[Tools.GetRandomNumber(0, SubjectList.Count)].Value;
            }
        }

        internal static class AvTime
        {
            private static readonly List<KeyValuePair<int, string>> TimeList;

            static AvTime()
            {
                TimeList = new List<KeyValuePair<int, string>>
                {
                    new KeyValuePair<int, string>(1, "8:00"),
                    new KeyValuePair<int, string>(2, "9:00"),
                    new KeyValuePair<int, string>(3, "10:00"),
                    new KeyValuePair<int, string>(4, "11:00"),
                    /*new KeyValuePair<int, string>(5, "12:00"),
                    new KeyValuePair<int, string>(6, "13:00"),
                    new KeyValuePair<int, string>(7, "14:00"),
                    new KeyValuePair<int, string>(8, "15:00"),
                    new KeyValuePair<int, string>(9, "16:00"),
                    new KeyValuePair<int, string>(10, "17:00"),
                    new KeyValuePair<int, string>(11, "18:00"),
                    new KeyValuePair<int, string>(12, "19:00"),
                    new KeyValuePair<int, string>(13, "20:00")*/
                };
            }

            public static string GetTag()
            {
                return "time";
            }

            public static List<int> GetIdList()
            {
                var idList = Enumerable.ToList(Enumerable.Select(TimeList, time => time.Key));
                return idList;
            }

            public static List<string> GetValueList()
            {
                var idList = Enumerable.ToList(Enumerable.Select(TimeList, time => time.Value));
                return idList;
            }

            public static List<KeyValuePair<int, string>> GetObjList()
            {
                return TimeList;
            }

            public static string GetRandomValue()
            {
                return TimeList[Tools.GetRandomNumber(0, TimeList.Count)].Value;
            }
        }
    }
}