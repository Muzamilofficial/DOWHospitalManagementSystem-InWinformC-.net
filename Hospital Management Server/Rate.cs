using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital_Management_Server__DOW_Hospital_
{
    // Class For Rating Form

    class Rate
    {
        public string Dislike;
        public string Good;
        public string Love;
        public string Awesome;

        // Display The Rating Form 
        public void display(string d, string g, string l, string a)
        {
            this.Dislike = d;
            this.Good = g;
            this.Love = l;
            this.Awesome = a;
        }
    }
}