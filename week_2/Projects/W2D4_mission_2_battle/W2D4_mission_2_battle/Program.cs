using System;
using System.Collections.Generic;

namespace W2D4_mission_2_battle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            var party = new List<string> { "Johanna", "Sandra", "Linn", "Sallie" };
            var partyString = String.Join(", ", party);

            Console.WriteLine($"Four brave warriors ({partyString}) are out on an adventure. When they have been wandering a while without much excitement they notice a cave. {party[0]} challanges the others to enter. 'I'm not scared!' says {party[1]}, 'Me neither!' {party[2]} agrees. '....voff' says {party[3]} and into the cave they go!");
            Console.WriteLine("The brave adventurers explore the cave for hours and in an unusally dark and big room they encounter a terrifying basilisk.");

            var random = new Random();
            int dice8 = 0;
            int HP = 16;

            for (var rolls = 0; rolls < 8; rolls++)
            {
                dice8 = random.Next(1, 9);
                //Console.WriteLine(dice8);
                HP += dice8;
            }

            Console.WriteLine($"The basilisk has {HP} HP.");
            Console.WriteLine($"The three sisters simultanusly draw their greatswords, {party[3]} growls and looks ready to attack.");
            Console.WriteLine();

            int dice6 = 0;
            int damage = 0;
            string lastHit = "";

            while (HP > 0)
            {
                for (var i = 0; i < 4; i++)
                {
                    if (HP > 0)
                    {
                        for (var rolls = 0; rolls < 2; rolls++)
                        {
                            dice6 = random.Next(1, 7);
                            //Console.WriteLine(dice6);
                            damage += dice6;
                        }

                        HP -= damage;

                        if (HP < 0)
                        {
                            HP = 0;
                            lastHit = String.Join(", ", party[i]);
                        }

                        Console.WriteLine($"{party[i]} hits the basilisk for {damage} damage. Basilisk has {HP} HP left.");

                        damage = 0;

                        
                    }
                }
            }

            Console.WriteLine($"{lastHit} hit the basilisk back to the deapths of the cave and all of our heroes safely make it out to the surface again. They were celebrated for weeks, becuse noone had before achived what they had, noone hade before faced the mighty basilisk and lived to tell about it! ... ");

            Console.WriteLine();
            Console.WriteLine($"{party[0]} wakes up from her daydream about defensless basilisks and greatswords. She heres {party[3]} barks and makes our adventurers aware of a sign that reads \"***Danger***\". With the daydreams fresh in her mind {party[0]} tells the others about all the glory that might await them and convinces them to venture into the cave.");

            HP = 16;

            for (var rolls = 0; rolls < 8; rolls++)
            {
                dice8 = random.Next(1, 9);
                //Console.WriteLine(dice8);
                HP += dice8;
            }

            Console.WriteLine($"The basilisk has {HP} HP.");

            int dice4 = 0;

            while (HP > 0)
            {
                for (var i = 0; i < 4; i++)
                {
                    if (HP > 0)
                    {

                        dice4 = random.Next(1, 5);
                        Console.WriteLine(dice4);
                        damage += dice4;

                        HP -= damage;

                        if (HP < 0)
                        {
                            HP = 0;
                            lastHit = String.Join(", ", party[i]);
                        }

                        Console.WriteLine($"{party[i]} hits the basilisk for {damage} damage. Basilisk has {HP} HP left.");

                        damage = 0;


                    }
                }
            }





        }
    }
}

//Johanna wakes up from her daydreams about defensless basilisks and greatswords...
//they are saved if they manage to run 12 or more steps away before the gaze hits
//något om att den fjärde är en hund?
//väldigt osanolik grej om att de hittar något blankt och basilisken förstenar sig själv?