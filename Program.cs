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
            member1.Name = Console.ReadLine();

            Console.Write("What is your team member's skill level? ");
            member1.SkillLevel = int.Parse(Console.ReadLine());

            Console.Write("What is your team member's courage factor? ");
            member1.CourageFactor = double.Parse(Console.ReadLine());

            Console.WriteLine(member1.MemberDescription());
        }
    }
}
