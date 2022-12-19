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
    public class Display
    {
        private const int SCREENWIDTH = 160;
        private const int SCREENHEIGHT = 40;
        private const int STATWIDTH = 17;
        private List<string> FinalScreen = new List<string>();
        private List<string> CommandBar = new List<string>();
        private List<string> StatBar = new List<string>();
        private List<string> StatAndGameArea = new List<string>();
        private List<string> Inventory = new List<string>();


        public LevelHandler LevelHandler { get; set; }
        public string[] AviableCommands { get; set; }
        public List<Item> OwnedItems { get; set; }
        public string[] Stats { get; set; }

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
        public string Spacers(int amount)
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
            AviableCommands = LevelHandler.Commands;

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
            string[] stats = Stats;
            
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
        
        private void InsertMap(string url)
        {
            List<string> sv = new List<string>();
            foreach (var item in File.ReadAllLines(@"Art\"+url+".txt"))
            {
                sv.Add(AlignCenter(item).Remove(0, STATWIDTH));
            }
            for (int i = 0; i < sv.Count; i++)
            {
                StatBar[i] += sv[i];
            }
            StatAndGameArea = StatBar;
        }

        public void ShowInventory()
        {
            foreach (var item in OwnedItems)
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
            StatAndGameArea = StatBar;
        }

        private void Assembly()
        {
            #region ClearPreviousScreen
            CommandBar.Clear();
            StatBar.Clear();
            StatAndGameArea.Clear();
            FinalScreen.Clear();
            Console.Clear();      
            #endregion
            CreateCommandBar();
            CreateStatBar();
            InsertMap(LevelHandler.MapUrl);
            CommandBar.ForEach(x => FinalScreen.Add(x));
            StatAndGameArea.ForEach(x => FinalScreen.Add(x));
        }
        private void InvAssembly()
        {
            #region ClearPreviousScreen
            CommandBar.Clear();
            StatBar.Clear();
            StatAndGameArea.Clear();
            FinalScreen.Clear();
            Inventory.Clear();
            Console.Clear();
            #endregion
            CreateCommandBar();
            CreateStatBar();
            ShowInventory();
            CommandBar.ForEach(x => FinalScreen.Add(x));
            StatAndGameArea.ForEach(x => FinalScreen.Add(x));
        }
        public void Screen(bool i)
        {
            Console.SetWindowSize(SCREENWIDTH + 1, SCREENHEIGHT + 1);
            if (i)
            {
                InvAssembly();
                FinalScreen.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Assembly();
                FinalScreen.ForEach(x => Console.WriteLine(x));
            }                   
        }       
    }
}
