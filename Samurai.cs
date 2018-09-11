using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Samurai
{
    class Samurai
    {

        private string name;
        private string weapontype;
        private bool doubleweapon;
        private bool hasHorse;
        private bool hasArmor;
        private string type;
        private double stamina;
        private double life;

        //getters

        public string GetName() { return name; }
        public string GetWeapontype() { return weapontype; }
        public bool GetDoubleweapon() { return doubleweapon; }
        public bool GetHashorse() { return hasHorse; }
        public bool GetHasArmor() { return hasArmor; }
        public string GetType() { return type; }
        public double Getstamina() { return stamina; }
        public double GetLife() { return life; }

        //setters

        public void SetName(string name) { this.name = name; }
        public void SetWeapontype(string weapontype) { this.weapontype = weapontype; }
        public void SetDoubleWeapon(bool doubleweapon) { this.doubleweapon = doubleweapon; }
        public void SetHasHorse(bool hasHorse) { this.hasHorse = hasHorse; }
        public void SetHasArmor(bool hasArmor) { this.hasArmor = hasArmor; }
        public void SetType(string type) { this.type = type; }
        public void SetStamina(double stamina) { this.stamina = stamina; }
        public void SetLife(double life) { this.life = life; }

        //Samurai Constructor
        public Samurai(string name)
        {
            this.name = name;
            this.stamina = 100;
        }

        //Abilities

        //checks the weapon of the attacker 
        //and prints the corresponding weapon and adjective
        public string WeaponMessage(string weapon)
        {
            string message="";

            if (weapon == "Katana")
                message = "magnificent katana";
            else if (weapon == "Yumi")
                message = "well strung yumi";
            else if (weapon == "Naginata")
                message = "sharp naginata";
            else if (weapon == "Wakizashi")
                message = "accurate wakizashi";

            return message;
        }

        //order one fighter to attack another
        public void Attack(Samurai victim)
        {
            if (life == 0)
            {
                Console.WriteLine("{0} is dead and cannot attack.",name);
            }
            else
            {
                //victim's defense points
                int shield = 0;

                if ((victim.hasArmor == true) & (victim.hasHorse == true))
                {
                    shield = 15;
                }
                else if ((victim.hasArmor == true) & (victim.hasHorse == false))
                {
                    shield = 10;
                }
                else if ((victim.hasArmor == false) & (victim.hasHorse == true))
                {
                    shield = 5;
                }
 
                //attacker's damage points
                double weaponpower = 0;

                if (weapontype == "Katana" & doubleweapon == false) { weaponpower = 10; }

                else if (weapontype == "Katana" & doubleweapon == true) { weaponpower = 10 * 1.8; }

                else if (weapontype == "Yumi" & doubleweapon == false) { weaponpower = 15; }

                else if (weapontype == "Yumi" & doubleweapon == true) { weaponpower = 15 * 1.8; }

                else if (weapontype == "Naginata" & doubleweapon == false) { weaponpower = 20; }

                else if (weapontype == "Naginata" & doubleweapon == true) { weaponpower = 20 * 1.8; }

                else if (weapontype == "Wakizashi" & doubleweapon == false) { weaponpower = 5; }

                else if (weapontype == "Wakizashi" & doubleweapon == true) { weaponpower = 5 * 1.8; }


                //fighter type attack calculation
                if (type == "Soldier")
                {
                    if (victim.GetLife() > 0)
                    {
                        victim.SetLife((victim.GetLife() + shield) - ((stamina / 3 + 10 + weaponpower)));
                        Console.WriteLine("{0} {1} attacked {2} {3} with a(n) {4}", type, name, victim.GetType(), victim.GetName(), WeaponMessage(weapontype));
                        victim.CheckState();
                        //dealtdmg = stamina/3+ 10;
                    }
                    else if (victim.GetLife() <= 0)
                    {
                        Console.WriteLine("{0} hurt the soulless body of {1}..", name, victim.GetName());
                    }
                }

                if (type == "Ronin")
                {
                    if (victim.GetLife() > 0)
                    {
                        victim.SetLife((victim.GetLife() + shield) - ((stamina / 3 + 5 + (stamina / 4) + weaponpower)));
                        Console.WriteLine("{0} {1} attacked {2} {3} with a(n) {4}", type, name, victim.GetType(), victim.GetName(), WeaponMessage(weapontype));
                        victim.CheckState();
                        //dealtdmg = stamina/3 + 5 + (stamina/4);
                    }
                
                else if (victim.GetLife() <= 0)
                {
                    Console.WriteLine("{0} hurt the soulless body of {1}..", name, victim.GetName());
                }

                }

                //stamina falling due to attacking
                if (stamina >= 20)
                stamina -= 20;
                else
                {
                    stamina = 0;
                }
            }
        }

        //use it on a fighter to add 15 HP
        public void Bandage()
        {


            if ((GetLife() <= 85) & (GetLife() != 0))
            {
                Console.WriteLine("{0} applied a Bandage on a wound and recovered {1} HP!", name, (100 - life).ToString("#.##"));
                SetLife(GetLife()+15);
                CheckState();
            }

            else if (GetLife() == 100)
            {
                Console.WriteLine("{0} tried to apply a Bandage but didn't make it..", name);
            }

            else if (GetLife() == 0)
            {
                Console.WriteLine("A dead fighter cannot be healed");
            }

        }

        //use it on a fighter to fully heal
        public void Medkit()
        {

            if ((GetLife() != 100) & (GetLife() != 0))
            {
                Console.WriteLine("{0} applied a Medkit on a wound and recovered {1} HP!", name, (100-life).ToString("#.##"));
                SetLife(100);
                CheckState();
            }

            else if (GetLife() == 100)
            {
                Console.WriteLine("{0} tried to apply a Medkit but didn't make it..", name);
            }

            else if(GetLife() == 0)
            {
                Console.WriteLine("A dead fighter cannot be healed");
            }
        }

        //the fighter rests and fully recovers stamina
        public void Rest()
        {
            if (life == 0)
            {
                Console.WriteLine("{0} is dead and has all the time to rest..", name);
            }
            else
            {
                if (stamina == 100)
                {
                    Console.WriteLine("{0} has no reason to rest", name);
                }
                else
                {
                    Console.WriteLine("{0} {1} took a step back and relaxed.", type, name);
                    Console.WriteLine("Gained {0} point(s) of stamina!", 100 - stamina);
                    SetStamina(100);
                }
            }
        }

        //print a fighter's health if alive, or death message if dead
        public void CheckState()
        {
            if (life <= 0)
            {
                life = 0;
                Console.WriteLine("{0} died..", name);               
            }
            else
            {
                Console.WriteLine("{0} health: {1}", name, life.ToString("#.##"));
            }
        }

        //print a fighter's full stats
        public void Print()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Stats of {0}:",name);
            Console.WriteLine("Weapon Type: {0}", weapontype);
            Console.WriteLine("Double weapon: {0}", doubleweapon);
            Console.WriteLine("Armor: {0}", hasArmor);
            Console.WriteLine("Horse: {0}", hasHorse);
            Console.WriteLine("Type: {0}", type);
            Console.WriteLine("Stamina: {0}", stamina);
            Console.WriteLine("Life: {0}", life.ToString("#.##"));
            Console.WriteLine("--------------------------------");
        }

    }

    class SamuraiMain
    {

        static void Main(string[] args)
        {

            //Creation of Akechi Mitsuhide
            Samurai Akechi = new Samurai("Akechi Mitsuhide");
            Akechi.SetType("Soldier");
            Akechi.SetHasArmor(true);
            Akechi.SetHasHorse(false);
            Akechi.SetWeapontype("Katana");
            Akechi.SetDoubleWeapon(true);
            Akechi.SetLife(100);
            Akechi.Print();


            //Creation of Date Masamune
            Samurai Date = new Samurai("Date Masamune");
            Date.SetType("Soldier");
            Date.SetHasArmor(false);
            Date.SetHasHorse(true);
            Date.SetWeapontype("Yumi");
            Date.SetDoubleWeapon(false);
            Date.SetLife(35);
            Date.Print();

            //Creation of Hattori Hanzo
            Samurai Hattori = new Samurai("Hattori Hanzo");
            Hattori.SetType("Soldier");
            Hattori.SetHasArmor(true);
            Hattori.SetHasHorse(false);
            Hattori.SetWeapontype("Naginata");
            Hattori.SetDoubleWeapon(false);
            Hattori.SetLife(100);
            Hattori.Print();

            //Creation of Oda Nobunaga
            Samurai Oda = new Samurai("Oda Nobunaga");
            Oda.SetType("Ronin");
            Oda.SetHasArmor(true);
            Oda.SetHasHorse(true);
            Oda.SetWeapontype("Wakizashi");
            Oda.SetDoubleWeapon(true);
            Oda.SetLife(100);
            Oda.Print();

            //Creation of Takeda Nobunaga
            Samurai Takeda = new Samurai("Takeda Nobunaga");
            Takeda.SetType("Ronin");
            Takeda.SetHasArmor(true);
            Takeda.SetHasHorse(false);
            Takeda.SetWeapontype("Katana");
            Takeda.SetDoubleWeapon(true);
            Takeda.SetLife(100);
            Takeda.Print();

            //Creation of Mitsako Shinozaki
            Samurai Mitsako = new Samurai("Mitsako Shinozaki");
            Mitsako.SetType("Ronin");
            Mitsako.SetHasArmor(false);
            Mitsako.SetHasHorse(true);
            Mitsako.SetWeapontype("Katana");
            Mitsako.SetDoubleWeapon(true);
            Mitsako.SetLife(100);
            Mitsako.Print();

            //FIGHT BEGINS!

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---===FIGHT BEGINS===---");
            Console.WriteLine();
            Console.WriteLine();

            //Thread.Sleep(n); not the best delay option but.. it works..

            //Step 6: Takeda attacks Akechi and Date
            Thread.Sleep(2500);
            Takeda.Attack(Akechi);
            Thread.Sleep(1000);
            Takeda.Attack(Date);

            Thread.Sleep(2500);
            //Step 7: Oda attacks Hattori
            Oda.Attack(Hattori);

            Thread.Sleep(2500);
            //Step 8: Hattori counterattacks Oda
            Hattori.Attack(Oda);

            Thread.Sleep(2500);
            //Step 9: Date fires an arrow against Takeda
            Date.Attack(Takeda);

            Thread.Sleep(2500);
            //Step 10: Akechi attacks Takeda
            Akechi.Attack(Takeda);

            Thread.Sleep(2500);
            //Step 11: Takeda supports his brother so attacks Hattori twice
            Takeda.Attack(Hattori);
            Takeda.Attack(Hattori);

            Thread.Sleep(2500);
            //Oda attacks Akechi
            Oda.Attack(Akechi);

            Console.ReadLine();
        }
    } 
}
 