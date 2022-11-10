using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital_Management_Server__DOW_Hospital_
{
    class DrAbdulFaheemClass
    {
        private string Email;
        private string Name;
        private string Day;

        public string PateintEmail
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }

        public string PateintName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public string PateintDay
        {
            get
            {
                return Day;
            }
            set
            {
                Day = value;
            }
        }
    }
}
