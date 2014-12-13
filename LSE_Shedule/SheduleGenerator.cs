using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LSE_Shedule.Constants;

namespace LSE_Shedule
{
    public static class SheduleGenerator
    {
        public static List<List<Student>> GenerateSubjPefer(List<Student> students)
        {
            var subjPreferenceList = new List<List<Student>>();

            for (var i = 0; i < AvSubjects.GetObjList().Count; ++i)
            {
                var currentSubjectPref = new List<Student>();
                foreach (var stdnt in students)
                {
                    var subjMap = stdnt.GetSubjectMap();
                    if (subjMap[i].Equals(1)) 
                        currentSubjectPref.Add(stdnt);
                }
                subjPreferenceList.Add(currentSubjectPref);
            }
            return subjPreferenceList;
        }

        public static int[,] GenerateSubjTimeTable(List<Student> students)
        {
            var subjPrefer = GenerateSubjPefer(students);
            var subjTimeTable = new int[AvSubjects.GetObjList().Count, AvTime.GetObjList().Count + 1];
            for (int i = 0; i < AvSubjects.GetObjList().Count; i++)
            {
                for (int k = 0; k < subjPrefer[i].Count; k++)
                {
                    for (int j = 1; j < AvTime.GetObjList().Count + 1; j++)
                    {
                        subjTimeTable[0, j] = subjPrefer[i].Count;
                        if(subjPrefer[i][k].CanAtTime(j))
                        {
                            ++subjTimeTable[i,j];
                        }
                    }
                }
            }
            return subjTimeTable;
        } 
    }
}
