using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    class GameStart
    {
        public void Run()
        {
            MainMenu();
        }


        private void MainMenu()
        {
            string title = @"                   (                                                  
  *   )   )        )\ )           )             (  (                  
` )  /(( /(   (   (()/(        ( /(   (   (  (  )\ )\   ) (  (    (   
 ( )(_))\()) ))\   /(_)) (  (  )\())  )\  )\ )\((_|(_| /( )\))(  ))\  
(_(_()|(_)\ /((_) (_))   )\ )\(_))/  ((_)((_|(_)_  _ )(_)|(_))\ /((_) 
|_   _| |(_|_))   | |   ((_|(_) |_   \ \ / / (_) || ((_)_ (()(_|_))   
  | | | ' \/ -_)  | |__/ _ (_-<  _|   \ V /  | | || / _` / _` |/ -_)  
  |_| |_||_\___|  |____\___/__/\__|    \_/   |_|_||_\__,_\__, |\___|  
                                                         |___/        ";

            string[] options = { "Play", "About the game", "Exit" };
            Menu menu = new Menu(title, options);
            int selected = menu.Run();
        }
    }
}
