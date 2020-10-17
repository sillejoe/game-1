using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace game
{

    class Program
    {
        
        public class character
        {
            private string type;
            private string name;
            private int HP;
            public Random rnd = new Random();
            private int chargestatus;
            public character(string t)
            {
                this.type = t;
                this.HP = 100;
                this.chargestatus = 0;
                this.name = "";
                
            }
            public virtual string returnName()
            {
                return this.name;
            }
            public string getType()
            {
                return this.type;
            }
            public int displayHP()
            {
                return this.HP;
            }

            public void changeHP(int damage)
            {
                if (damage > this.HP)
                {
                    this.HP = 0;
                }
                else
                {
                    this.HP = this.HP - damage;

                }
            }

            public bool checkHP()
            {
                
                if (this.HP == 0)
                {
                    return false;
                }
                else return true;
            }
            public int punch()
            {
                int damage;
                int num = rnd.Next(0, 100) + 1;
                if (num <= 98)
                {
                    damage = rnd.Next(1, 11);
                }
                else
                {
                    damage = rnd.Next(11, 76);
                    Console.WriteLine("Critical Hit");
                }
                return damage;
            }
            public virtual int SM1(string p2type)
            {
                int damage = 0;
                return damage;
            }
            public virtual int SM2(string p2type, int chargestatus)
            {
                int damage = 0;
                return damage;
            }
            public bool Charge()
            {
                if (this.chargestatus < 3)
                {
                    this.chargestatus++;
                    return true;
                }
                else
                {
                    Console.WriteLine("MAX CHARGE");
                    return false;
                }
            }
            public void ChargeReset()
            {
                this.chargestatus = 0;
            }
            public void Displaychargestatus()
            {
                Console.WriteLine("You have charged {0} time(s)", this.chargestatus);
            }
            public int getCharge()
            {
                return this.chargestatus;
            }
        }
        public class firetype : character
        {
            string name = "Blaze";
            public firetype(string t) : base(t)
            {
                
            }
            

            public override string returnName()
            {
                return this.name;
            }
            public override int SM1(string p2type)
            {

                int damage = 0; double typemultiplyer = 0, tempdamage = 0;
                if (p2type == "earth")
                {
                    typemultiplyer = 2;
                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 60)
                    {
                        tempdamage = rnd.Next(1, 26) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                        return damage;
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * typemultiplyer; //1.6% chance of 100 damage.
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                        return damage;
                    }


                }

                else
                {
                    typemultiplyer = 1;
                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 80)
                    {
                        tempdamage = rnd.Next(1, 26) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                        return damage;
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                        return damage;
                    }

                }

            }
            public override int SM2(string p2type, int chargestatus)
            {
                //unfinished
                base.SM2(p2type, chargestatus);
                int damage; double tempdamage, typemultiplyer, chargemultiplyer;
                chargemultiplyer = 1 + (chargestatus / 10);
                if (p2type == "earth")
                {
                    typemultiplyer = 2;

                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 60)
                    {
                        tempdamage = rnd.Next(1, 26) * typemultiplyer * chargemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * typemultiplyer * chargemultiplyer;//max charge then 19.2% chance of getting 100+ damage, too high I think
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                    }
                    return damage;
                }
                else
                {
                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 60)
                    {
                        tempdamage = rnd.Next(1, 26) * chargemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * chargemultiplyer;
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                    }
                    return damage;
                }




            }

        }

        public class watertype : character
        {
            string name = "Aqua";
            public watertype(string t) : base(t)
            {

            }
            public override string returnName()
            {
                return this.name;
            }
            public override int SM1(string p2type)
            {

                int damage; double typemultiplyer, tempdamage;
                if (p2type == "fire")
                {
                    typemultiplyer = 2;
                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 60)
                    {
                        tempdamage = rnd.Next(1, 26) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                    }
                    return damage;
                }

                else
                {
                    typemultiplyer = 1;
                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 80)
                    {
                        tempdamage = rnd.Next(1, 26) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                    }
                    return damage;
                }


            }
            public override int SM2(string p2type, int chargestatus)
            {
                //unfinished
                base.SM2(p2type, chargestatus);
                int damage; double tempdamage, typemultiplyer, chargemultiplyer;
                chargemultiplyer = 1 + (chargestatus / 10);
                if (p2type == "fire")
                {
                    typemultiplyer = 2;

                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 60)
                    {
                        tempdamage = rnd.Next(1, 26) * typemultiplyer * chargemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * typemultiplyer * chargemultiplyer;//max charge then 19.2% chance of getting 100+ damage, too high I think
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                    }
                    return damage;
                }
                else
                {
                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 60)
                    {
                        tempdamage = rnd.Next(1, 26) * chargemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * chargemultiplyer;
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                    }
                    return damage;
                }


            }
        }
        public class earthtype : character
        {
            string name = "Geode";
            public earthtype(string t) : base(t)
            {

            }
            public override string returnName()
            {
                return this.name;
            }

            public override int SM1(string p2type)
            {

                int damage; double typemultiplyer, tempdamage;
                if (p2type == "water")
                {
                    typemultiplyer = 2;
                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 60)
                    {
                        tempdamage = rnd.Next(1, 26) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                    }
                    return damage;
                }

                else
                {
                    typemultiplyer = 1;
                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 80)
                    {
                        tempdamage = rnd.Next(1, 26) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * typemultiplyer;
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                    }
                    return damage;
                }

            }
            public override int SM2(string p2type, int chargestatus)
            {
                //unfinished
                base.SM2(p2type, chargestatus);
                int damage; double tempdamage, typemultiplyer, chargemultiplyer;
                chargemultiplyer = 1 + (chargestatus / 10);
                if (p2type == "fire")
                {
                    typemultiplyer = 2;

                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 60)
                    {
                        tempdamage = rnd.Next(1, 26) * typemultiplyer * chargemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * typemultiplyer * chargemultiplyer;//max charge then 19.2% chance of getting 100+ damage, too high I think
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                    }
                    return damage;
                }
                else
                {
                    int num = rnd.Next(0, 100) + 1;
                    if (num <= 60)
                    {
                        tempdamage = rnd.Next(1, 26) * chargemultiplyer;
                        damage = Convert.ToInt32(tempdamage);
                    }
                    else
                    {
                        tempdamage = rnd.Next(26, 51) * chargemultiplyer;
                        damage = Convert.ToInt32(tempdamage);

                        Console.WriteLine("Critical Hit");
                    }
                    return damage;
                }
            }

        }
        public static class characterFactory
        {
            public static character Create(string type)
            {
                if (type == "fire")
                {
                    return new firetype(type);
                }
                else if(type == "water")
                {
                    return new watertype(type);
                }
                else
                {
                    return new earthtype(type);
                }
            }
        }

        public static string SM1MoveName(string type)
        {
            if (type == "fire")
            {
                return "Flame Ball";
            }
            if (type == "water")
            {
                return "Drench";
            }
            else
            {
                return "Rock Throw";
            }
        }
        public static string SM2MoveName(string type)
        {
            if (type == "fire")
            {
                return "Lava Flow";
            }
            if (type == "water")
            {
                return "Tsunami";
            }
            else
            {
                return "Mudslide";
            }
        }

        class game
        {
            public void chooseCharacter(ref string character, ref string type, ref int characternum, game g)//Player gets to choose their character
            {
                firetype a = new firetype("fire");
                watertype b = new watertype("water");
                earthtype c = new earthtype("earth");
                Console.WriteLine("Please choose your character and enter the appropriate number \n 1) {0} - Fire Type \n 2) {1} - Water Type \n 3) {2} - Earth Type"
                , a.returnName(), b.returnName(), c.returnName()); 
               
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());

                    switch (number)
                    {
                        case 1:
                            characternum = 1;
                            character = a.returnName();
                            type = "fire";
                            break;
                        case 2:
                            characternum = 2;
                            character = b.returnName();
                            type = "water";
                            break;
                        case 3:
                            characternum = 3;
                            character = c.returnName(); ;
                            type = "earth";
                            break;
                        default:
                            Console.WriteLine("Try Again");
                            g.chooseCharacter(ref character, ref type, ref characternum, g);
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Try Again");
                    g.chooseCharacter(ref character, ref type, ref characternum, g);
                }
            }
            public void opponentNumber(int characterNum, ref int opponentNum)//generates opponent number to determine their character
            {
                Random oNumber = new Random();
                int randomNumber = oNumber.Next(0, 3) + 1;
                while (randomNumber == characterNum)
                {
                    randomNumber = oNumber.Next(0, 3) + 1;

                }
                opponentNum = randomNumber;


            }

            public void opponentChar(int opponentNum, ref string oppenentType, ref string opponentName)//sets the details for the opponent's character
            {
                firetype a = new firetype("fire");
                watertype b = new watertype("water");
                earthtype c = new earthtype("earth");
                switch (opponentNum)
                {
                    case 1:
                        opponentName = a.returnName();
                        oppenentType = "fire";
                        break;
                    case 2:
                        opponentName = b.returnName();
                        oppenentType = "water";
                        break;
                    case 3:
                        opponentName = c.returnName();
                        oppenentType = "earth";
                        break;
                }
            }

            public int whoGoesFirst()
            {
                Random number = new Random();
                int num = number.Next(0, 2) + 1;
                return num;
            }

            public int chooseMove(string type, game g)
            {
                int choice = 0;
                bool check = false;
                while(check == false)
                {
                    Console.WriteLine("\nWhat would you like to do?");
                    if (type == "fire")
                    {
                        Console.WriteLine(" 1) Punch - Basic attack \n 2) Flame Ball - Special move, more effective against 'Earth' types. \n " +
                        "3) Lava Flow - Another special move. Damage increases the more you charge. \n 4) Charge - Charging increases the damage when 'Lava Flow' is used");
                    }
                    else if (type == "water")
                    {
                        Console.WriteLine(" 1) Punch - Basic attack \n 2) Drench - Special move, more effective against 'Fire' types. \n " +
                        "3) Tsunami - Another special move. Damage increases the more you charge. \n 4) Charge - Charging increases the damage when 'Tsunami' is used");
                    }
                    else
                    {
                        Console.WriteLine(" 1) Punch - Basic attack \n 2) Rock Throw - Special move, more effective against 'Water' types. \n " +
                        "3) Mudslide - Another special move. Damage increases the more you charge. \n 4) Charge - Charging increases the damage when 'Mudslide' is used");
                    }
                    try
                    {
                        choice = Convert.ToInt32(Console.ReadLine());
                        if (choice > 0 && choice < 5)
                        {
                            check = true;
                        }
                        else Console.WriteLine("Please try again");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please try again");


                    }
                    
                }
                return choice;
                
               
            }
            public void moveExecution(int moveNum, character player, string oType, int chargeNum, character Opponent, game g, ref bool check)
            {
                
                while (check == false)
                {
                    switch (moveNum)
                    {
                        case 1:
                            Opponent.changeHP(player.punch());
                            check = true;
                            break;
                        case 2:
                            Opponent.changeHP(player.SM1(oType));
                            check = true;
                            break;
                        case 3:
                            Opponent.changeHP(player.SM2(oType, chargeNum));
                            check = true;
                            break;
                        case 4:
                            if (player.Charge() == false)
                            {
                                Console.WriteLine("Please enter something else"); int option = Convert.ToInt32(Console.ReadLine());
                                g.moveExecution(option, player, oType, chargeNum, Opponent, g, ref check);
                            }
                            else
                            {
                                player.Displaychargestatus();
                                check = true;
                            }
                            break;
                        

                    }
                }

            }
            public int opponentMoveNum()
            {
                Random number = new Random();
                int rnum = number.Next(0, 4) + 1;
                return rnum;
            }

                
        public void opponentMoveExecution(int moveNum, int chargeNum, character player, character opponent, string pType, string oType, game g, ref bool check)
            {
                
                while (check == false)
                {
                    switch (moveNum)
                    {
                        case 1:
                            Console.WriteLine("Opponent used Punch!");
                            player.changeHP(opponent.punch());
                            check = true;
                            break;
                        case 2:
                            Console.WriteLine("Opponent used {0}!", SM1MoveName(oType));
                            player.changeHP(opponent.SM1(pType));
                            check = true;
                            
                            break;
                        case 3:
                            Console.WriteLine("Opponent used {0}!", SM2MoveName(oType));
                            player.changeHP(opponent.SM2(pType, chargeNum));
                            check = true;

                            break;
                        case 4:
                            Console.WriteLine("Opponent used Charge!");
                            if (opponent.Charge() == false)
                            {
                                g.opponentMoveExecution(g.opponentMoveNum(), opponent.getCharge(), player, opponent, pType, oType, g, ref check);

                            }
                            else
                            {
                                check = true;
                            }
                            break;

                    }
                }
            }


            static void Main(string[] args)

            {
                /*character test = new character("fire");
                test.punch();
                test.displayHP();
                Console.ReadLine();*/
                string characterName = "", characterType = "", opponentType = "", opponentName = ""; int characterNumber = 0, opponentNumber = 0, first = 0; int choice = 0;
                bool p1XPCheck, oXPCheck, chargeCheck1 = false, chargeCheck2 = false;
                game test2 = new game();//creates a new game
                test2.chooseCharacter(ref characterName, ref characterType, ref characterNumber, test2);//user picks  character
                test2.opponentNumber(characterNumber, ref opponentNumber);//opponent's character is randomised
                test2.opponentChar(opponentNumber, ref opponentType, ref opponentName);//opponent's character details are set
                var P1 = characterFactory.Create(characterType);//player's character is created
                var Opponent = characterFactory.Create(opponentType);//opponent's character is created
                Console.WriteLine("The opponent has chosen to use {0}", Opponent.returnName());
                first = test2.whoGoesFirst();
                
                if (first == 1)
                {
                    Console.WriteLine("You get to take the first turn!");
                    do
                    {
                        oXPCheck = Opponent.checkHP(); p1XPCheck = P1.checkHP();
                        choice = test2.chooseMove(characterType, test2);
                        test2.moveExecution(choice, P1, opponentType, P1.getCharge(), Opponent, test2, ref chargeCheck1);
                        Console.WriteLine("Opponent's HP is now {0}", Opponent.displayHP());
                        oXPCheck = Opponent.checkHP(); p1XPCheck = P1.checkHP();
                        if (oXPCheck == false)
                        {
                            break;
                        }

                        test2.opponentMoveExecution(test2.opponentMoveNum(), Opponent.getCharge(), P1, Opponent, characterType, opponentType, test2, ref chargeCheck2);
                        Console.WriteLine("Players 1's HP is now {0}", P1.displayHP());
                        p1XPCheck = P1.checkHP();
                        chargeCheck1 = false; chargeCheck2 = false;
                    } while ((p1XPCheck == true) && (oXPCheck == true));

                }
                else
                {
                    Console.WriteLine("The computer will take the first turn");
                    do
                    {
                        test2.opponentMoveExecution(test2.opponentMoveNum(), Opponent.getCharge(), P1, Opponent, characterType, opponentType, test2, ref chargeCheck2);
                        Console.WriteLine("Players 1's HP is now {0}", P1.displayHP());
                        p1XPCheck = P1.checkHP();
                        if (p1XPCheck == false)
                        {
                            break;
                        }

                        choice = test2.chooseMove(characterType, test2);
                        test2.moveExecution(choice, P1, opponentType, P1.getCharge(), Opponent, test2, ref chargeCheck1);
                        Console.WriteLine("Opponent's HP is now {0}", Opponent.displayHP());
                        oXPCheck = Opponent.checkHP();
                        chargeCheck1 = false; chargeCheck2 = false;
                    } while ((p1XPCheck == true) && (oXPCheck == true));



                }
                if (p1XPCheck == false)
                {
                    Console.WriteLine("You Lose!");
                }
                else Console.WriteLine("You Win!");


                

                Console.ReadLine();

            }
        }
    }
}

