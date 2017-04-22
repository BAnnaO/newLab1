using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeam MyTeam = new ResearchTeam();
            Console.WriteLine(string.Format("{0} {1} {2}",MyTeam[TimeFrame.Long].ToString(),MyTeam[TimeFrame.Year].ToString(),MyTeam[TimeFrame.TwoYears].ToString()));
            MyTeam.Organisation = "SomeOrg";
            MyTeam.RegistrNumber = 7;
            MyTeam.Theme = "Stupid theme";
            MyTeam.TimeDuration = TimeFrame.Year;
            MyTeam.getPaper = new Paper[3] { new Paper("Cool paper", new Person(), new DateTime(2016, 11, 21)),new Paper(),new Paper()};
            Paper[] Additive = new Paper[2] { new Paper("Cool paper 2", new Person(), new DateTime(2017, 05, 11)), new Paper() };
            MyTeam.AddPapers(Additive);
            Console.WriteLine(MyTeam.LastPaper);
            Paper[] OneDim = new Paper[6] { new Paper(), new Paper(), new Paper(), new Paper(), new Paper(), new Paper() };
            Paper[,] TwoDim = new Paper[2,3] { { new Paper(), new Paper(), new Paper() }, { new Paper(), new Paper(), new Paper() } };
            Paper[][] Jagged = new Paper[2][];
            Jagged[0] = new Paper[2] {new Paper(), new Paper() };
            Jagged[1] = new Paper[3] { new Paper(), new Paper(), new Paper() };
            int OneDimTime = Environment.TickCount;
            foreach (Paper sp in OneDim) {
                int k = 0;
                while (k < 100000)
                {
                    sp._Author = new Person("Ann", "Boguslavska", new DateTime(1992, 01, 13));
                    k++;
                }
            }
            Console.WriteLine((Environment.TickCount-OneDimTime).ToString());

            int TwoDimTime = Environment.TickCount;
            for (int i = 0; i < 2; i++) {
                for (int j = 0; j < 3; j++) {
                    int k = 0;
                    while (k < 100000)
                    {
                        TwoDim[i, j]._Author = new Person("Ann", "Boguslavska", new DateTime(1992, 01, 13));
                        k++;
                    }
                }
            }
            Console.WriteLine((Environment.TickCount - OneDimTime).ToString());
            int JaggedTime = Environment.TickCount;
            for (int i = 0; i < Jagged.GetLength(0); i++)
            {
                for (int j = 0; j <Jagged[i].Length; j++)
                {
                    int k = 0;
                    while ( k < 100000) {
                        Jagged[i][j]._Author = new Person("Ann", "Boguslavska", new DateTime(1992, 01, 13));
                        k++;
                    }
                    
                }
            }
            Console.WriteLine((Environment.TickCount - JaggedTime).ToString());
            Console.ReadKey();
        }
    }
}
