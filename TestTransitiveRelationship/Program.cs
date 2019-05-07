using System;
using System.Collections.Generic;

namespace TestTransitiveRelationship
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //For each interhcnage,  validate if it already belongs to a group (both values are already in the group) 
            //or if it extends the relation of a group (only one of the values belong to the group).

            //In the case they both do not belong in any group, it becomes a new group.

            //In the case both values belong in different groups then merge them.

            while (true)
            {
                List<Interchange> interchanges = new List<Interchange>();
                interchanges.Add(new Interchange("A", "B"));
                interchanges.Add(new Interchange("A", "C"));
                interchanges.Add(new Interchange("B", "C"));
                interchanges.Add(new Interchange("C", "D"));
                interchanges.Add(new Interchange("E", "F"));
                interchanges.Add(new Interchange("F", "G"));
                interchanges.Add(new Interchange("H", "I"));
                interchanges.Add(new Interchange("I", "K"));
                interchanges.Add(new Interchange("L", "M"));
                interchanges.Add(new Interchange("M", "N"));
                interchanges.Add(new Interchange("O", "P"));
                interchanges.Add(new Interchange("Q", "R"));
                interchanges.Add(new Interchange("E", "A"));
                interchanges.Add(new Interchange("A", "R"));



                List<HashSet<string>> sets = new List<HashSet<string>>();

                foreach (Interchange interchange in interchanges)
                {
                    int value1Set = -1;
                    int value2Set = -1;

                    for (int i = 0; i < sets.Count; i++)
                    {
                        HashSet<string> set = sets[i];

                        if (set.Contains(interchange.value1))
                            value1Set = i;
                        if (set.Contains(interchange.value2))
                            value2Set = i;
                    }

                    if (value1Set == -1 && value2Set == -1)
                    {
                        // we have a new set
                        sets.Add(new HashSet<string> { interchange.value1, interchange.value2 });
                    }
                    else if (value1Set == -1)
                    {
                        sets[value2Set].Add(interchange.value1);
                    }
                    else if (value2Set == -1)
                    {
                        sets[value1Set].Add(interchange.value2);
                    }
                    else
                    {
                        if (value1Set == value2Set)
                        {
                            // duplicate entry, skip the add
                            continue;
                        }

                        // merge the sets at value1Set and value2Set
                        foreach (string value in sets[value2Set])
                        {
                            sets[value1Set].Add(value);
                        }
                        sets.RemoveAt(value2Set);
                    }
                }

                Console.WriteLine("All Groups:");
                for (int i = 0; i < sets.Count; i++)
                {

                    Console.WriteLine(String.Join(",", sets[i]));
                }

                Console.WriteLine("Input letter to determine interchange.");
                var userInput = Console.ReadLine();
                Boolean foundGroup = true;
                int counter = 0;
                while (foundGroup)
                {
                    var group = String.Join(",", sets[counter]);
                    if (group.Contains(userInput))
                    {
                        Console.WriteLine("Interchange for " + userInput + " = " + group);
                        foundGroup = false;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
            
        }
    }
}
