using System.Xml.Schema;
// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Collections.Generic;


namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create characters
            Console.WriteLine("Choose a name for your wizard:");
            string? wizName = Console.ReadLine();
            Wizard wizard = new Wizard(wizName);

            Console.WriteLine("Choose a name for your knight:");
            string? knightName = Console.ReadLine();
            Knight knight = new Knight(knightName);

            Console.WriteLine("Choose a name for your hunter:");
            string? huntName = Console.ReadLine();
            Hunter hunter = new Hunter(huntName);

            void stats()
            {
                wizard.stats();
                knight.stats();
                hunter.stats();
            }

            wizard.castSpell();
            stats();
    
            Console.ReadKey();
        }

    }

        // User chooses the class for the main character
    class Wizard
    {

        public string name;
        public int maxHP;
        public int hp;
        private float exp;

        private int spellSlot = 2;
        
        public List<string> spells = new List<string>();

        public Wizard(string _name)
        {
            name = _name;
            maxHP = 75;
            Random rng = new Random();
            hp = rng.Next(maxHP - 20, maxHP);
            exp = 0f;
            spells.Add("frost byte");
            spells.Add("Heal");
            
            
        }
        public void castSpell()
        {
            Console.WriteLine("Choose a spell to cast: ");
            for (int i = 0; i < spells.Count; i++)
            {
                Console.WriteLine("- " + spells[i]);
            }
            Console.WriteLine();
            string? input = Console.ReadLine();
            
            if (spells.Contains(input.ToLower()))
            {
                int index = spells.IndexOf(input.ToLower());
                switch (index)
                {
                    case 0:
                        break;
                    case 1:

                        break;
                }
                Console.WriteLine(name + " casts " + spells[index] + "!");
                spellSlot--;
                Console.WriteLine(name + " has " + spellSlot + " spell slots remaining.");
            } else 
            {
                Console.WriteLine("Error: Invalid input\n Please try again.");
                castSpell();
            }
        }

        public void stats()
        {

        }
    }

    class Knight
    {
        public string? name;
        public int maxHP;
        public int hp;
        private float exp;

        public Knight(string _name)
        {
            name = _name;
            maxHP = 100;
            Random rng = new Random();
            hp = rng.Next(maxHP - 20, maxHP);
            exp = 0f;
        }

        public void stats()
        {

        }
    }

    class Hunter
    {
        public string? name;
        public int maxHP;
        public int hp;
        private float exp;
        
        public Hunter(string _name)
        {
            name = _name;
            maxHP = 80;
            Random rng = new Random();
            hp = rng.Next(maxHP - 20, maxHP);
            exp = 0f;
        }

        public void stats()
        {

        }
    }
}
