using System;

namespace Heist
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plan Your Heist!");

            Member member1 = new Member();

            Console.Write("What is your team member's name? ");
            try
            {
                string name = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Plase enter a name");
                }
                member1.Name = name;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("What is your team member's skill level? ");
            string skillLevelStr = Console.ReadLine();
            try
            {
                int skillLevelInt = int.Parse(skillLevelStr);
                if (skillLevelInt <= 0)
                {
                    throw new FormatException("Please enter a positive integer!");
                }
                member1.SkillLevel = skillLevelInt;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter a positive integer!");
            }

            Console.Write("What is your team member's courage factor? ");
            member1.CourageFactor = double.Parse(Console.ReadLine());

            Console.WriteLine(member1.MemberDescription());
        }
    }
}
