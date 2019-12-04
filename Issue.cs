using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
namespace C_sharp_project
{
    public class Issue
    {

        public string username;
        public string issuename;
        private DateTime date;
        public string solution;

        public Issue()
        {

        }


        public string UserName
        {
            get { return username; }
            set { username = value; }
        }

        public string IssueName
        {
            get { return issuename; }
            set { issuename = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public string Solution
        {
            get { return solution; }
            set { solution = value; }
        }


       
    }
}