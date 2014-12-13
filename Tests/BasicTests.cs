using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using NUnit.Framework;
using System.Collections.Generic;
using LSE_Shedule;
using LSE_Shedule.Constants;

namespace Tests
{
    [TestFixture]
    public class BasicTests
    {
        /*
        [TestCase]
        public void Creation_of_attendee()
        {
            var sbjList = new List<Subject>();
            
            for (var i = 0; i < 4; i++)
            {
                sbjList.Add(new Subject("Subject №" + i.ToString(CultureInfo.InvariantCulture)));
            }

            var freeTimeList = new List<BusyTime>();
               
            for (var i = 8; i < 11; i++)
            {
                freeTimeList.Add(new BusyTime((8 + i).ToString(CultureInfo.InvariantCulture) + ":00"));
            }

            var attendee  = new Attendee("ivan", 1, sbjList, freeTimeList);

            Assert.AreEqual(3, attendee.GetBusyTimeIndexes().Count);
            Assert.AreEqual(3, attendee.GetBusyTimeIndexes().Count);
        }
        */

        [TestCase]
        public void OneStudent()
        {
            var helper = new Student("1", 1000, 
                                    new List<Subject>(),
                                    new List<BusyTime>());

            var stdnt = new List<Student>();

            for (var i = 0; i < 3; i++)
            {
                stdnt.Add(new Student("stud" + i.ToString(CultureInfo.InvariantCulture), i, 2, 2));
            }
            
            var sh = SheduleGenerator.GenerateSubjTimeTable(stdnt);
            Assert.AreEqual(sh[0,0], 0);
        }
    }
}
