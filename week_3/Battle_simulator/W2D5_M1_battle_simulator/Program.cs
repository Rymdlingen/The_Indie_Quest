using System;
using System.Collections.Generic;

namespace W2D5_M1_battle_simulator
{
    class Program
    {
        static void SimulateBattle(List<string> heroes, string monster, int monsterHP, int savingThrowDC)
        {

            //Three types of enemys:
            //Orc (15 HP) (DC12)
            //Mage (40 HP) (DC20)
            //Troll ( 84 HP) (DC18)

            var random = new Random();
            var heroesString = String.Join(", ", heroes);

            if (heroes.Count > 0)
            {
                Console.WriteLine();
            Console.WriteLine($"A {monster.ToLower()} with {monsterHP} HP appears.");

            int dice6 = 0;
            int damage = 0;

                while (monsterHP > 0 && heroes.Count != 0)
                {
                    for (var i = 0; i < heroes.Count; i++)
                    {
                        if (monsterHP > 0)
                        {
                            for (var rolls = 0; rolls < 2; rolls++)
                            {
                                dice6 = random.Next(1, 7);
                                //Console.WriteLine(dice6);
                                damage += dice6;
                            }

                            monsterHP -= damage;

                            if (monsterHP < 1)
                            {
                                monsterHP = 0;
                            }

                            Console.WriteLine($"{heroes[i]} hits the {monster.ToLower()} for {damage} damage. {monster} has {monsterHP} HP left.");

                            damage = 0;

                            int heroesIndex;
                            int dice20;
                            int constitution;

                            if (heroes.Count > 0 && monsterHP > 0)
                            {
                                constitution = 5;
                                heroesIndex = random.Next(0, heroes.Count);

                                Console.WriteLine($"The {monster.ToLower()} attacks {heroes[heroesIndex]}.");

                                dice20 = random.Next(1, 21);
                                constitution += dice20;

                                Console.Write($"{heroes[heroesIndex]} rolls a {dice20} and ");
                                if (constitution < savingThrowDC)
                                {
                                    Console.WriteLine($"fails to be saved. {heroes[heroesIndex]} is killed.");
                                    heroes.Remove(heroes[heroesIndex]);
                                }
                                else
                                {
                                    Console.WriteLine("is saved from the attack.");
                                }
                                //Console.WriteLine(party.Count);
                            }
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //Three types of enemys:
            //Orc (15 HP) (DC12)
            //Mage (40 HP) (DC20)
            //Troll (84 HP) (DC18)

            var heroes = new List<string> {"Johanna", "Michal", "Sallie", "Doris", "Majken", "Zombie", "Luke", "Nala"};
            var heroesString = String.Join(", ", heroes);
            heroes.Add("Ahlgren");
            heroesString += " and " + heroes[heroes.Count - 1];
            var heroesStart = heroes.Count;

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Our brave warriors {heroesString} are on an adventure and they enter a dungeon.");

            SimulateBattle(heroes, "Orc", 15, 12);
            SimulateBattle(heroes, "Mage", 40, 20);
            SimulateBattle(heroes, "Troll", 84, 18);

            //Console.WriteLine(heroes.Count);

            heroesString = "";

            if (heroes.Count > 0)
            {
                heroesString += heroes[0];
            }

            if (heroes.Count > 1)
            {
                for (var i = 1; i < heroes.Count - 1; i++)
                {
                    heroesString += ", " + heroes[i];
                }

                heroesString += " and " + heroes[heroes.Count - 1];
            }


            if (heroes.Count == 0)
            {
                Console.WriteLine("All our warriors are dead.");
            }
            else
            {
                Console.WriteLine($"{heroesString} return from the dungeon.");
            }

            if (heroes.Count < heroesStart && heroes.Count > 0)
            {
                Console.WriteLine("Sadly all of our warriors did not make it out.");
            }



        }
    }
}
