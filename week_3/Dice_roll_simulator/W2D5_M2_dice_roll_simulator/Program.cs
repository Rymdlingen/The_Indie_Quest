using System;
using System.Collections.Generic;

namespace W2D5_M2_dice_roll_simulator
{
    class Program
    {

        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {

            // orc 2d8+6
            // mage 9d8
            // troll 8d10+40

            var random = new Random();
            int diceNumber = 0;
            int sum = 0;

            for (var i = 0; i < numberOfRolls; i++)
            {
                diceNumber = random.Next(1, diceSides + 1);
                //Console.WriteLine(diceNumber);
                sum += diceNumber;
            }

            return sum + fixedBonus;
        }

        static void SimulateBattle(List<string> heroes, string monster)
        {

            //Three types of enemys:
            // orc 2d8+6 (DC12)
            // mage 9d8 (DC20)
            // troll 8d10+40 (DC18)


            var random = new Random();
            int monsterHP = 0;
            int savingThrowDC = 0;

            if (heroes.Count > 0)
            {
                Console.WriteLine();

                if (monster == "orc" || monster == "Orc")
                {
                    monster = "Orc";
                    monsterHP = DiceRoll(2, 8, 6);
                    savingThrowDC = 12;
                    Console.WriteLine($"A {monster.ToLower()} with {monsterHP} HP appears.");
                }

                if (monster == "mage" || monster == "Mage")
                {
                    monster = "Mage";
                    monsterHP = DiceRoll(9, 8);
                    savingThrowDC = 20;
                    Console.WriteLine($"A {monster.ToLower()} with {monsterHP} HP appears.");
                }

                if (monster == "troll" || monster == "Troll")
                {
                    monster = "Troll";
                    monsterHP = DiceRoll(8, 10, 40);
                    savingThrowDC = 18;
                    Console.WriteLine($"A {monster.ToLower()} with {monsterHP} HP appears.");
                }

                int greatsword;

                while (monsterHP > 0 && heroes.Count != 0)
                {
                    foreach (var heroe in heroes)
                    {
                        if (monsterHP > 0)
                        {
                            greatsword = DiceRoll(2, 6);

                            monsterHP -= greatsword;

                            if (monsterHP < 1)
                            {
                                monsterHP = 0;
                            }

                            Console.WriteLine($"{heroe} hits the {monster.ToLower()} for {greatsword} damage. {monster} has {monsterHP} HP left.");
                        }
                    }


                    int heroesIndex;
                    int constitution;
                    int DCThrow;

                    if (heroes.Count > 0 && monsterHP > 0)
                    {
                        constitution = 5;
                        heroesIndex = random.Next(0, heroes.Count);

                        Console.WriteLine($"The {monster.ToLower()} attacks {heroes[heroesIndex]}.");

                        DCThrow = DiceRoll(1, 20);
                        constitution += DCThrow;

                        Console.Write($"{heroes[heroesIndex]} rolls a {DCThrow} and ");
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

        static void Main(string[] args)
        {
            //Three types of enemys:
            // orc 2d8+6 (DC12)
            // mage 9d8 (DC20)
            // troll 8d10+40 (DC18)

            // greatsword 2d6

            // saving throws d20

            var heroes = new List<string> { "Johanna" };
            var heroesString = String.Join(", ", heroes);
            heroes.Add("Ahlgren");
            heroesString += " and " + heroes[heroes.Count - 1];
            var heroesStart = heroes.Count;

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Our brave warriors {heroesString} are on an adventure and they enter a dungeon.");

            SimulateBattle(heroes, "Orc");
            SimulateBattle(heroes, "mage");
            SimulateBattle(heroes, "Troll");


            //DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)

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

            //Console.WriteLine(DiceRoll(2, 6));
        }
    }
}