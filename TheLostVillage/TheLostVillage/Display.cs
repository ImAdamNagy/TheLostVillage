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
        private List<string> GameScreen = new List<string>();

        public string[] AviableCommands { get; set; }
        public Display()
        {
            Console.SetWindowSize(SCREENWIDTH, SCREENHEIGHT);
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
            line.Prepend('|'); //Waiting for fix
            line = string.Concat(line,'|');
            return line;
        }
        #endregion
        private void CreateCommandBar()
        {
            CommandBar.Add(Separator());
            CommandBar.Add(CreateBorder(Spacers(SCREENWIDTH - 2)));
            CommandBar.Add(Separator());     
        }

        private void Assembly()
        {
            CreateCommandBar();

            CommandBar.ForEach(x => FinalScreen.Add(x));
        }

        public void Screen()
        {
            Assembly();
            FinalScreen.ForEach(x => Console.WriteLine(x));
        }
        
    }
}
