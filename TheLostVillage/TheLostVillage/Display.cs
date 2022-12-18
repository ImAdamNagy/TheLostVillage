using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TheLostVillage
{
    internal class Display
    {
        private const int SCREENWIDTH = 160;
        private const int SCREENHEIGHT = 40;
        private const int STATWIDTH = 17;
        private List<string> FinalScreen = new List<string>();
        private List<string> CommandBar = new List<string>();
        private List<string> StatBar = new List<string>();
        private List<string> StatAndGameArea = new List<string>();
        private List<string> Inventory = new List<string>();


        public string[] AviableCommands { get; set; }
        public string[] Map { get; set; }
        public List<Item> OwnedItems { get; set; } = new List<Item>();
        public string[] Stats { get; set; }
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

        public string AlignCenter(string content)
        {
            int length = content.Length;
            int freespace = SCREENWIDTH - 2 - length;
            if (freespace % 2 == 0)
            {
                content = Spacers(freespace / 2) + content + Spacers(freespace / 2);
            }
            else
            {
                freespace++;
                content = Spacers(freespace / 2) + content + Spacers(freespace / 2 - 1);
            }
            return content;
        }
        #endregion
        private void CreateCommandBar() //Uses 3 lines
        {
            string[] commands = new string[] { "alma", "körte","asd", "láma","ló", "kerekesszék" };
            AviableCommands = commands;

            CommandBar.Add(Separator());
            #region Center Align
            string content = string.Join(" ", AviableCommands);
            content = AlignCenter(content);
            #endregion
            CommandBar.Add(CreateBorder(content));
            CommandBar.Add(Separator());     
        }

        public void CreateStatBar()
        {
            Player player = new Player("Lovag");
            string[] stats = player.stats;
            
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
                StatAndGameArea.Add(StatBar[i] + Map[i]);
            }
        }

        public void ShowInventory()
        {
            Player player = new Player("Lovag");
            foreach (var item in player.Inventory)
            {
                Inventory.Add("");
                string tab = Spacers(5);
                string itemline = $"{item.Name}{tab}{item.Count}x{tab}{item.Consumable}{tab}{item.Attack_Damage}{tab}{item.Armor}{tab}{item.Value}";
                Inventory.Add(AlignCenter(itemline).Remove(0, STATWIDTH));
                Inventory.Add("");
            }
            for (int i = 0; i < Inventory.Count; i++)
            {
                StatBar[i] += Inventory[i];
            }
        }

        public void IntroductionArts(){
            List<string> s = new List<string>();
            foreach (var item in File.ReadAllLines(@"Art\Hut.txt"))
            {
                s.Add(AlignCenter(item).Remove(0, STATWIDTH));
            }
            foreach (var item in File.ReadAllLines(@"Art\Characters, monsters\WitchCauldronBrew.txt"))
            {
                s.Add(AlignCenter(item).Remove(0, STATWIDTH));
            }
            for (int i = 0; i < s.Count; i++)
            {
                StatBar[i] += s[i];
            }
            StatAndGameArea = StatBar;
        }

        public void LavaDogFight()
        {
            List<string> lavadog = new List<string>();
            foreach (var item in File.ReadAllLines(@"Art\Characters, monsters\Zombie.txt"))
            {
                lavadog.Add(AlignCenter(item).Remove(0, STATWIDTH));
            }
            
            for (int i = 0; i < lavadog.Count; i++)
            {
                StatBar.Add(lavadog[i]);
            }
            StatAndGameArea = StatBar;
        }

        private void Assembly()
        {
            CreateCommandBar();
            CreateStatBar();
            IntroductionArts();
            CommandBar.ForEach(x => FinalScreen.Add(x));
            StatAndGameArea.ForEach(x => FinalScreen.Add(x));
        }
        public void Screen()
        {
            Assembly();
            FinalScreen.ForEach(x => Console.WriteLine(x));
        }
        
    }
}
