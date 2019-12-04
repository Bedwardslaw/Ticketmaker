using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace C_sharp_project
{
    class Project
    {
        private const string file = "issues.json";
        private List<Issue> _ticketList = new List<Issue>();
        private object issue;

        private string ShowMenu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1. New Issue");
            Console.WriteLine("2. List Issues");
            Console.WriteLine("3. Find Issue");
            Console.WriteLine("4. Remove Issue");
            Console.WriteLine("5. Exit");
            var option = Console.ReadLine();
            return option;
        }

        public void UserAction()
        {
            //loop
             if (File.Exists(file)) 
             {
                 var json = File.ReadAllText(file);
                 _ticketList = JsonConvert.DeserializeObject<List<Issue>>(json);
                 
                 Console.WriteLine($" issues.json loaded with {_ticketList.Count} issues");
             }

            // Menu to display options the user can choose. Using a While Loop 

            while (true)
            {
                var option = ShowMenu();
                switch (option)
                {
                    case "1":
                        {
                            var ticket = CreateIssue();
                            _ticketList.Add(ticket);

                            break;
                        }
                    case "2":
                        ShowIssues();
                        break;
                    case "3":
                        FindIssue();
                        break;

                    case "4":
                        RemoveIssue();
                        break;

                    case "5":

                        var json = JsonConvert.SerializeObject(_ticketList);
                        File.WriteAllText(file, json);
                        Console.WriteLine("issues.json written");
                        return;
                    default:
                        Console.WriteLine("Goodbye" + option);
                        break;
                }
            }
        }

        // display the issues in the console. The user can see 
        private void ShowIssues()
        {
            Console.WriteLine($"username | issuename | solution");

            foreach (Issue ticket in _ticketList)
            {
                Console.WriteLine($"{ticket.username}| {ticket.issuename} | {ticket.solution}");
            }
        }



        //for loop to serach or the find command;
        private void FindIssue()

        {
            Console.WriteLine("Enter issue to search for");
            string iSearch = Console.ReadLine();


            for (int counter = 0; counter < _ticketList.Count; counter++)

            {
                if (_ticketList[counter].issuename.Contains(iSearch))

                    Console.WriteLine(_ticketList[counter].issuename);


                else

                {
                    Console.WriteLine("Could not find that issue");
                }

            }
        }



        // Method to make the issueticket, that will later go to the tickelist. 

        private Issue CreateIssue()

        {
            Console.WriteLine("Name?");
            var userName = Console.ReadLine();

            Console.WriteLine("What is the issue?");
            var issueName = Console.ReadLine();

            // Console.WriteLine(" What is today's date"); //int;
            //var date = DateTimeOffset.Parse(Console.ReadLine());

            Console.WriteLine("What is a possible solution?");
            var solution = Console.ReadLine();

            //Console.WriteLine("Do you need to add another issue?");
            // Add ticket method var = Console.ReadLine();


            var issueTicket = new Issue();
            issueTicket.UserName = userName;
            issueTicket.IssueName = issueName;
            //issueTicket.Date = date;
            issueTicket.Solution = solution;
            return issueTicket;

        }

        private void RemoveIssue()

        {
            Console.WriteLine("Enter issue you want to remove");
            string iSearch = Console.ReadLine();
            var item = _ticketList.SingleOrDefault(x => x.issuename == iSearch);
            if (item != null)
              _ticketList.Remove(item);

        }

    }
}

