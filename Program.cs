// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;


namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Clear console screen
            Console.Clear();
            // Make the texts green
            Console.ForegroundColor = ConsoleColor.Green;
            bool endGame = false;
            void quit() 
            {
                endGame = true;
            }
            
            // Create characters
            Console.WriteLine("Choose the first name for your wizard:");
            string? wizName = Console.ReadLine();
            Wizard wizard = new Wizard(wizName);

            Console.WriteLine("Choose the first name for your knight:");
            string? knightName = Console.ReadLine();
            Knight knight = new Knight(knightName);

            Console.WriteLine("Choose the first name for your hunter:");
            string? huntName = Console.ReadLine();
            Hunter hunter = new Hunter(huntName);


            // Story
            // The player is a commander of a small team of wizard, knight, and hunter.
            // The player gets to control the team.
            // The objective is to reach an base that needs help.
            // The secondary objective is to survive x days.
            // The story is set in an alternate universe where magic is real.
            // The player can only order his team to do certain things. 
            // The player cannot interact with the world on his own.



            
            // Create inventory for this instance of the game.
            Inventory inventory = new Inventory();

            Random rand = new Random();

            // Function for seeing team stats
            void teamStats()
            {
                wizard.stats();
                knight.stats();
                hunter.stats();
            }

            // Heals
            void heal()
            {
                wizard.heal();
                knight.heal();
                hunter.heal();
            }
            

            // Creates a list of possible commands
            
            List<string> cmds = new List<string>();
            // Add quit command here
            cmds.Add("quit");       //1
            // General game commands
            cmds.Add("stats");      //2
            cmds.Add("rest");       //3
            cmds.Add("repair");     //4
            cmds.Add("hunt");       //5
            cmds.Add("heal");       //6
            cmds.Add("attack");     //7
            cmds.Add("inventory");  //8

            // Function for executing each command
            void execute(int action)
            {
                switch (action)
                {
                    default: 
                        Console.WriteLine("Error: Invalid input please try again.");
                        break;
                    
                    case 1: // Ends game loop
                        quit();
                        break;
                    case 2:
                        teamStats();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        wizard.executeSpell(1);
                        heal();
                        break;
                    case 7:
                        break;
                    case 8:
                        inventory.checkInventory();
                        break;

                }
            }

            // Prompts player to proceed the game
            void prompt()
            {
                
                Console.WriteLine("What would you like to do?");
                // Prints out the possible commands
                for (int i = 0; i < cmds.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + cmds[i]);
                }
                Console.Write("> ");
                
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    int action = Convert.ToInt32(input);
                    execute(action);
                } else 
                {
                    Console.WriteLine("Error: Invalid input please try again.");
                }
                // Waits until enter key is pressed
                Console.Write("Press <Enter> to continue... ");
                while (Console.ReadKey().Key != ConsoleKey.Enter) {}
                Console.Clear();

            }

            // Start game loop
            while (endGame != true)
            {
                prompt();
            }
            //Console.WriteLine("The End");

            // Lmao
            Console.WriteLine("################         #####      #####        ################");                
            Console.WriteLine("################         #####      #####        ################");                
            Console.WriteLine("      ####               #####      #####        ####            ");                
            Console.WriteLine("      ####               #####      #####        ####            ");                
            Console.WriteLine("      ####               ################        ########        ");                
            Console.WriteLine("      ####               ################        ########        ");                
            Console.WriteLine("      ####               #####      #####        ####            ");                
            Console.WriteLine("      ####               #####      #####        ####            ");                
            Console.WriteLine("      ####               #####      #####        ################");                
            Console.WriteLine("      ####               #####      #####        ################");                
            Console.WriteLine();
            Console.WriteLine("    ################        ######         ###       #######");
            Console.WriteLine("    ################        #######        ###       ###   ###");
            Console.WriteLine("    ####                    ###  ###       ###       ###     ###");
            Console.WriteLine("    ####                    ###   ###      ###       ###      ###");
            Console.WriteLine("    ########                ###    ###     ###       ###      ###");
            Console.WriteLine("    ########                ###     ###    ###       ###      ###");
            Console.WriteLine("    ####                    ###      ###   ###       ###      ###");
            Console.WriteLine("    ####                    ###       ###  ###       ###      ###");
            Console.WriteLine("    ################        ###        #######       ###    ###");
            Console.WriteLine("    ################        ###         ######       ########");

        }

    }

        
    class Wizard
    {

        public string name;
        public int maxHP;
        public int hp;
        private double exp;

        private int spellSlot;
        
        public List<string> spells = new List<string>();
        Random rng = new Random();

        public Wizard(string _name)
        {
            name = _name;
            maxHP = 75;
            hp = rng.Next(maxHP - 20, maxHP);
            exp = 0f;
            spellSlot = 2;
            spells.Add("frost bite");
            spells.Add("heal");
            
            
        }

        public void castSpell(string spellName)
        {   
            if (spellName != "")
            {
                executeSpell(spells.IndexOf(spellName));
            } else
            {
                Console.WriteLine("Choose a spell to cast: ");
                for (int i = 0; i < spells.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + spells[i]);
                }
                Console.Write("> ");
                int input = Convert.ToInt32(Console.ReadLine());
                executeSpell(input);
            }
            
        }
        // Decreases the spell slot number and executes the dialogue.
        private void decSpellSlot(int spellIndex)
        {
            spellSlot--;
            Console.WriteLine(name + " casts " + spells[spellIndex] + "!");
            Console.WriteLine(name + " has " + spellSlot + " spell slots remaining."); 
        }
        public void executeSpell(int spellIndex)
        {
            exp += Math.Round(rng.NextDouble(), 1);
            spellIndex--;
            // Checks if the wizard has enough spell slots.
            if (spellSlot > 0) {
                switch (spellIndex)
                {
                    // Regardless of the spot, dafault runs last.
                    // If input is invalid, default runs.
                    default: 
                        Console.WriteLine("Error: Invalid input \nPlease try again.");
                        break;
                    case 0: // Frost bite
                        decSpellSlot(spellIndex + 1);
                        break;
                    case 1: // Heal
                        decSpellSlot(spellIndex + 1);
                        break;
                }
            } else
            {
                Console.WriteLine(name + " is out of spells to use!");
            }
        }

        public void stats()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(name + ": ");
            Console.WriteLine("-" + hp + "/" + maxHP + " health");
            Console.WriteLine("-" + spellSlot + " spells remaining");
            Console.WriteLine("-" + exp + " experiences");
        }

        public void heal()
        {
            int healAmount = rng.Next(10, 15);
            hp += healAmount;
            if (hp > maxHP)
            {
                hp = maxHP;
            }
        }
    }

    class Knight
    {
        public string? name;
        public int maxHP;
        public int hp;
        private float exp;
        Random rng = new Random();

        public Knight(string _name)
        {
            name = _name;
            maxHP = 100;
            hp = rng.Next(maxHP - 20, maxHP);
            exp = 0f;
        }

        public void stats()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(name + ": ");
            Console.WriteLine("-" + hp + "/" + maxHP + " health");
            Console.WriteLine("-" + exp + " experiences");
        }

        public void heal()
        {
            int healAmount = rng.Next(10, 15);
            hp += healAmount;
            if (hp > maxHP)
            {
                hp = maxHP;
            }
        }

    }

    class Hunter
    {
        public string? name;
        public int maxHP;
        public int hp;
        private float exp;
        Random rng = new Random();
        
        public Hunter(string _name)
        {
            name = _name;
            maxHP = 80;
            hp = rng.Next(maxHP - 20, maxHP);
            exp = 0f;
        }

        public void stats()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine(name + ": ");
            Console.WriteLine("-" + hp + "/" + maxHP + " health");
            Console.WriteLine("-" + exp + " experiences");
        }

        public void heal()
        {
            int healAmount = rng.Next(10, 15);
            hp += healAmount;
            if (hp > maxHP)
            {
                hp = maxHP;
            }
        }
        
    }
    // Class to store items in inventory.
    class Inventory 
    {
        private int capacity;
        public int bandages;
        public int toolKit;
        public int food;
        public int money;
        List<string> items = new List<string>();
        object[,] uniqueItems = new object[5, 2];
        int[] randNum = new int[3];
        Random rand = new Random();

        // Determine which special items the user begins with.
        void startItem()
        {
            int num;
            for (int i = 0; i < 3; i++)
            {
                num = rand.Next(0, 5);
                randNum[i] = num;
            }
            Array.Sort(randNum);
        }
        void setToZero()
        {

        }

        
        // Instantiate an inventory
        public Inventory()
        {
            
            capacity = 1024;
            bandages = rand.Next((capacity / 4) - 64, (capacity / 4) + 1);
            toolKit = rand.Next((capacity / 4) - 64, (capacity / 4) + 1);
            food = rand.Next((capacity / 4) - 64, (capacity / 4) + 1);
            money = rand.Next(500, 1001);
            // Creates unique items that starts in the inventory.
            uniqueItems[0, 0] = "elk skin";
            uniqueItems[1, 0] = "beads";
            uniqueItems[2, 0] = "gems";
            uniqueItems[3, 0] = "potion";
            uniqueItems[4, 0] = "katana";
            // Default the numbers to 0
            
            startItem();
            for (int i = 0; i < randNum.Length; i++)
            {
                uniqueItems[randNum[i], 1] = rand.Next(1, 10);
            }
        }

        // Check the inventory upon request
        public void checkInventory()
        {
            Console.WriteLine("The inventory capacity is " + capacity + " kgs");
            Console.WriteLine("You have these rare items: ");
            for (int i = 0; i < uniqueItems.Length / 2; i++)
            {
                Console.WriteLine(uniqueItems[i, 0] + ": " + uniqueItems[i, 1]);
            }
            Console.WriteLine("You have these essential items: ");
            Console.WriteLine(bandages + " bandages");
            Console.WriteLine(toolKit + " tool kits");
            Console.WriteLine(food + " foods");
            Console.WriteLine(money + " quids");
            Console.WriteLine("You have these items: ");
            if (items.Count() != 0)
            {
                for (int i = 0; i < items.Count(); i++)
                {
                    Console.WriteLine("-" + items[i]);
                }
            } else
            {
                Console.WriteLine("You don't have any common items");
            }
            Console.WriteLine("--------------------------------");
        }
    }
}
