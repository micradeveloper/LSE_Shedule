using System.Collections.Generic;
using LSE_Shedule.Constants;

namespace LSE_Shedule
{
    public interface ISheduleRestricrion
    {
        string GetValue();
        int GetId();
    }

    public class BusyTime : ISheduleRestricrion
    {
        private KeyValuePair<int, string> _time;
        
        public string GetValue()
        {
            return _time.Value;
        }

        public int GetId()
        {
            return _time.Key;
        }

        public BusyTime(KeyValuePair<int, string> time)
        {
            _time = time;
        }

        public BusyTime(string timeValue)
        {
            _time = AvTime.GetValueList().Contains(timeValue) ? 
                new KeyValuePair<int, string>(AvTime.GetObjList().Find(obj => obj.Value.Equals(timeValue)).Key, timeValue) 
                : 
                new KeyValuePair<int, string>(0, "0");
        }
    }
}