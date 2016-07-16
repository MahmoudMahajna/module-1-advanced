using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                dynamic planets = DynamicXElement.Create(XElement.Load(System.IO.Directory.GetCurrentDirectory() + "/../../planets.xml"));
                var mercury = planets.Planet;       // first planet
                Console.WriteLine(mercury);
                var venus = planets["Planet", 1];  // second planet 
                Console.WriteLine(venus);
                var ourMoon = planets["Planet", 2].Moons.Moon;
                Console.WriteLine(ourMoon);
                var marsMoon = planets["Planet", 3]["Moons", 0].Moon; // mars second moon
                Console.WriteLine(marsMoon);
                Console.WriteLine("********************");
            
                //the following code adds moons 
                var aa=planets.AddMoons;

                var moon1 = planets["Planet", 2]["Moons", 0].Moon;
                var moon2 = planets["Planet", 3]["Moons", 0].Moon;
                Console.WriteLine($"New Moons: {moon1} {moon2}");

                Console.WriteLine("*********The New Xml File**********");
                Console.WriteLine(aa);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
    
        }
    }
}
