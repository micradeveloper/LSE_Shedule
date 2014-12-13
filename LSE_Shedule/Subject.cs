using System.Collections.Generic;
using LSE_Shedule.Constants;

namespace LSE_Shedule
{
    public class Subject: ISheduleRestricrion
    {
        private KeyValuePair<int, string> _subject;
 
        public string GetValue()
        {
            return _subject.Value;
        }

        public int GetId()
        {
            return _subject.Key;
        }

        public Subject(KeyValuePair<int, string> subj)
        {
            _subject = subj;
        }

        public Subject(string subjName)
        {
            _subject = new KeyValuePair<int, string>(AvSubjects.GetObjList().Find(obj => obj.Value.Equals(subjName)).Key, subjName);
        }
    }
}