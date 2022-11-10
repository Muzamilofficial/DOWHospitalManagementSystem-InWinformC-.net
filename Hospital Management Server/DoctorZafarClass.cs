using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital_Management_Server__DOW_Hospital_
{
    class DoctorZafarClass
    {
        public string Monday;
        public string Tuesday;
        public string Wednesday;
        public string Friday;

        public void Booked(string Mon)
        {
            this.Monday = Mon;
        }

        public void Booked2(string Tue)
        {
            this.Tuesday = Tue;
        }

        public void Booked3(string Wed)
        {
            this.Wednesday = Wed;
        }

        public void Booked4(string Fri)
        {
            this.Friday = Fri;
        }

    }
}
