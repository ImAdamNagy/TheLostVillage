using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    internal class Display
    {
        private const int SCREENWIDTH = 160;
        private const int SCREENHEIGHT = 45;
        private List<string> FinalScreen = new List<string>();
        private List<string> CommandBar = new List<string>();
        private List<string> StatBar = new List<string>();
        private List<string> StatandMap = new List<string>();
        
        public string[] AviableCommands { get; set; }
        public string[] Map { get; set; }
        public Display()
        {
            Console.SetWindowSize(SCREENWIDTH+1, SCREENHEIGHT+1);
        }

        #region FormatHelpers
        private string Separator()
        {
            string separator = "";
            for (int i = 0; i < SCREENWIDTH; i++)
            {
                separator += "-";
            }
            return separator;
        }
        private string Spacers(int amount)
        {
            string spacer = "";
            for (int i = 0; i < amount; i++)
            {
                spacer += " ";
            }
            return spacer;
        }
        private string CreateBorder(string content)
        {
            string line = content;
            line = line.Insert(0, "|");
            line = string.Concat(line,'|');
            return line;
        }
        #endregion
        private void CreateCommandBar() //Uses 3 lines
        {
            string[] commands = new string[] { "alma", "körte","asd", "láma","ló", "kerekesszék" };
            AviableCommands = commands;

            CommandBar.Add(Separator());
            #region Center Align
            string content = string.Join(" ", AviableCommands);
            int length = content.Length;
            int freespace = SCREENWIDTH - 2 - length;
            if (freespace%2==0)
            {
                content = Spacers(freespace / 2) + content + Spacers(freespace / 2);
            }
            else
            {
                freespace++;
                content = Spacers(freespace / 2) + content + Spacers(freespace / 2 - 1);
            }
            #endregion
            CommandBar.Add(CreateBorder(content));
            CommandBar.Add(Separator());     
        }
        private void CreateStatBar()
        {
            string[] stats = new string[] { "Eletero: 100", "Level: 5", "Name: Keldron", "Dialogue: ?", "Strengt: 10"};
            const int STATWIDTH = 15;
            StatBar.Add(CreateBorder(Spacers(STATWIDTH-2)));
            foreach (var item in stats)
            {
                string statline = item + Spacers(STATWIDTH-item.Length-2);
                StatBar.Add(CreateBorder(statline));
                StatBar.Add(CreateBorder(Spacers(STATWIDTH - 2))); //Leaving an empty line between stats
            }

            int remaininglines = SCREENHEIGHT - 3 - StatBar.Count-1; //max-commandbar-stats-bottom separator line
            for (int i = 0; i < remaininglines; i++)
            {
                StatBar.Add(CreateBorder(Spacers(STATWIDTH - 2)));
            }
            StatBar.Add(Separator());

        }

        private void MapMerge()
        {
            string[] helper = new string[StatBar.Count];
            for (int i = 0; i < StatBar.Count-1; i++)
            {
                helper[i] = $"{Spacers(i)}{i}";
            }
            Map = helper;


            for (int i = 0; i < StatBar.Count; i++)
            {
                StatandMap.Add(StatBar[i] + Map[i]);
            }
        }

        private void Assembly()
        {
            CreateCommandBar();
            CreateStatBar();
            MapMerge();
            CommandBar.ForEach(x => FinalScreen.Add(x));
            StatandMap.ForEach(x => FinalScreen.Add(x));
        }

        public void Screen()
        {
            Assembly();
            FinalScreen.ForEach(x => Console.WriteLine(x));
            Console.WriteLine(SCREENWIDTH - StatBar[5].Count());
        }
        
    }
}
