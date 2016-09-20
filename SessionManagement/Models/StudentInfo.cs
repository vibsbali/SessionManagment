using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionManagement.Models
{
    public class StudentInfo
    {
        //Default Constructor
        public StudentInfo()
        {

        }
        /// <summary>
        /// Create object of student Class
        /// </summary>
        /// <param name="intRoll">Int RollNumber</param>
        /// <param name="strName">String Name</param>
        public StudentInfo(int intRoll, string strName)
        {
            this.Roll = intRoll;
            this.Name = strName;
        }

        private int intRoll;
        private string strName;
        public int Roll
        {
            get
            {
                return intRoll;
            }
            set
            {
                intRoll = value;
            }
        }

        public string Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }
    }
}