using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ListWork {
    class Person {
        public string name;
        public DateTime time;
        public bool status; // true - inside TC, false - outside TC
        public Person() {
            name = "Jonh Dow";
            time = DateTime.Now;
            status = true;
        }
    }
  class TradeCenter {
       /* public TradeCenter() {

        } */
        List<Person> person = new List<Person> { };
        public void EnterPerson(string name) {
            Person human = new Person { };
            human.name = name;
            person.Add(human);
            this.SaveStateToFile(human);
        }
        public void ExitPerson(Person human) {
            person.Remove(human);
        }
        public DateTime GetCurrentTime() {
            DateTime CurrentTime = DateTime.Now;
            return CurrentTime;
        }
        public void SaveStateToFile(Person human) {
            string status;
            if (human.status) {
                status = "inside";
            }
            else {
                status = "outside";
            }
            File.AppendAllText("dump_file.txt", this.GetCurrentTime() + " " + human.name + status + "\r\n");
        }
    }
    class Program {
        static void Main(string[] args) {
            TradeCenter Aurora = new TradeCenter();
            do {
                string Event, tmpName;
                Console.WriteLine("1 - Вход \n 2 - Выход");
                Event = Console.ReadLine();
                if (Event=="1") {
                    Console.WriteLine("Имя?");
                    tmpName = Console.ReadLine();
                    Aurora.EnterPerson(tmpName);
                }

            } while (true);
        }
    }
}// !!!ДОДЕЛАЙ ПРОГРАММУ!!!