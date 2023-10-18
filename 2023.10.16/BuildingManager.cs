using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023._10._16
{
    internal class BuildingManager
    {

        public List<FarmBuilding> listOfFarmBuildings = new List<FarmBuilding>();





        public BuildingManager() //an empty constructor so that a player creates all buildings from scratch
        {

        }
        
        public void BuildingMenu()
        {
            bool status = true;
            while (status)          //Loop that runs until user is done with building menu as seen below
            {
                Console.Clear();
                Console.WriteLine("What would you like to do: \n\n" +
                                  "1. View Buildings\n" +              
                                  "2. AddBuilding\n" +                 
                                  "3. Remove Building\n" +             
                                  "4. Quit buildings - menu\n");
                try
                {
                    int answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:              //Function to see the buildings
                            Console.Clear();
                            ViewBuildings();
                            Console.WriteLine("Click to continue...");
                            Console.ReadLine();
                            break;
                        case 2:              //Function to add building
                            AddBuilding();
                            break;
                        case 3:              //Function to remov a building
                            Console.Clear();
                            Console.WriteLine("What Building would you like to remove?\n");
                            ViewBuildings();
                            try
                            {
                                int answer2 = int.Parse(Console.ReadLine());
                                bool building = RemoveBuilding(answer2);               //Här måste jag göra någonting med boolen?
                            }
                            catch
                            {
                                Console.WriteLine("Choose one of the farms Id.");
                            }
                            break;
                        case 4:              //Fuction to go back to Farm main menu
                            Console.Clear();
                            status = false;
                            break;

                        default:             //In case user writes wrong character
                            Console.WriteLine("Please write a number between 1 - 4.");
                            break;
                    }
                }                 
                catch                       //Extra caution in case int parse doesnt work.
                {
                    Console.WriteLine("Please write a number between 1 - 4.");
                }
            }

        }







        private void ViewBuildings() //Function to see all buildings in the list
        {
            foreach (FarmBuilding building in listOfFarmBuildings)
            {
                Console.WriteLine(building.GetDescription());
            }
            if (listOfFarmBuildings.Count == 0)
            {
                Console.WriteLine("There are not yet buildings to display\n");
            }
        }







        private void AddBuilding() //Function create and add building to the buildings list
        {
            Console.Clear();
            Console.WriteLine("What is the name of the building you want to add?");
            string name = Console.ReadLine();
            Console.WriteLine("What is the capacity of the building?");
            int capacity = int.Parse(Console.ReadLine());
            listOfFarmBuildings.Add(new FarmBuilding(capacity, name));
            Console.WriteLine("Click to continue...");
            Console.ReadLine();
        }







        private bool RemoveBuilding(int num)  //Function to remove building from list, but only if it's empty
        {
            foreach (FarmBuilding building in listOfFarmBuildings)
            {
                if (building.Id == num)
                {
                    bool status = building.IsEmpty(); //If building is empty, we remove
                    if (status)
                    {
                        listOfFarmBuildings.Remove(building);
                        Console.WriteLine($"The building with Id: {num} was removed.\n");
                        Console.WriteLine("Click to continue...");
                        Console.ReadLine();
                        return true;
                    }
                    else  //If building is full, we do not remove.
                    {
                        Console.WriteLine($"The building with Id: {num} was not removed.\n" +
                                          $"There are still animals in the building\n");
                        Console.WriteLine("Click to continue...");
                        Console.ReadLine();
                        return false;
                    }

                    
                }
            }
            return false;
        }





        public List<FarmBuilding> GetBuildings()    //This I'm not sure what it's supposed to do ???
        {
            return new List<FarmBuilding>();
        }
    }
}
