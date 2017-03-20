//Zachery Holderman
//CIS237
//Instructor: David Barnes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        private Droid[] droidCollection;
        //Private variable to hold the length of the Collection
        private int lengthOfCollection;
        //auxillary array to temporarily hold existing array components
        private Droid[] aux = new Droid [100];

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new Droid[sizeOfCollection];
            //set length of collection to 0
            lengthOfCollection = 0;
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }
        public void hardcodedDroids()
        {
            Add("Carbonite", "Protocol", "Bronze", 6);
            Add("Vanadium", "Utility", "Silver", true, true, false);
            Add("Quadranium", "Janitor", "Gold", false, true, false, true, true);
            Add("Vanadium", "Astromech", "Silver", true, false, true, false, 12);
            Add("Vanadium", "Utility", "Silver", true, false, true);
            Add("Vanadium", "Astromech", "Silver", false, false, true, false, 6);
            Add("Quadranium", "Janitor", "Gold", true, true, true, true, true);
            Add("Carbonite", "Protocol", "Bronze", 12);
            Add("Quadranium", "Astromech", "Gold", true, true, true, false, 6);
            Add("Vanadium", "Protocol", "Silver", 18);
            Add("Quadranium", "Janitor", "Bronze", false, false, false, false, true);
            Add("Carbonite", "Utility", "Bronze", true, true, true);
            
        }
        public void sortDroidTypes()
        {
            //Instanciate genericStacks & queue
            GenericStack<Droid> protocolStack = new GenericStack<Droid>();
            GenericStack<Droid> utilityStack = new GenericStack<Droid>();
            GenericStack<Droid> janitorStack = new GenericStack<Droid>();
            GenericStack<Droid> astromechStack = new GenericStack<Droid>();
            GenericQueue<Droid> droidQueue = new GenericQueue<Droid>();

            //loop through collection and put them into respective stacks based on their type
            for (int i = 0; i < lengthOfCollection; i++)
            {
                if (droidCollection[i].GetType() == typeof(ProtocolDroid))
                {
                    protocolStack.push(droidCollection[i]);
                }
                else if (droidCollection[i].GetType() == typeof(UtilityDroid))
                {
                    utilityStack.push(droidCollection[i]);
                }
                else if (droidCollection[i].GetType() == typeof(JanitorDroid))
                {
                    janitorStack.push(droidCollection[i]);
                }
                else if (droidCollection[i].GetType() == typeof(AstromechDroid))
                {
                    astromechStack.push(droidCollection[i]);
                }
            }
            //loop through while stack is not empty of each to put them in the queue and remove them from the stack
            while (astromechStack.Size > 0)
            {
                droidQueue.Enqueue(astromechStack.pop());
            }
            while (janitorStack.Size > 0)
            {
                droidQueue.Enqueue(janitorStack.pop());
            }
            while (protocolStack.Size > 0)
            {
                droidQueue.Enqueue(protocolStack.pop());
            }
            while (utilityStack.Size > 0)
            {
                droidQueue.Enqueue(utilityStack.pop());
            }
            //loop back through droids putting them back into the droid array that should now be sorted.
            for(int i = 0; i<lengthOfCollection; i++)
            {
                droidCollection[i] = droidQueue.Dequeue();
            } 
        }
        private void sort(Droid[] a, int lo, int hi)
        {
            if (hi < lo)
            {
                return;
            }
            else
            {
                int mid = lo + ((hi - lo) / 2);
                sort(a, lo, mid);
                sort(a, mid + 1, hi);
                merge(a, lo, mid, hi);
            }
        }
        private void merge(Droid[] a, int lo, int mid, int hi)
        {
            int i = lo;
            int j = mid + 1;
            //copy the droids to the auxillary
            for (int k = lo; k <= mid; k++)
            {
                aux[k] = a[k];
            }
            //loop through comparing points
            for (int k = lo; k <= hi; k++)
            {
                //lo is greater than mid save mid+1
                if (i > mid)
                {
                    a[k] = aux[j++];
                }
                //mid+1 is greater than hi save lo
                else if (j > hi)
                {
                    a[k] = aux[i++];
                }
                //shift right droid left if total cost is less than the one on the left
                else if (aux[j].CompareTo(aux[i]) < 0)
                {
                    a[k] = aux[j++];
                }
                //save lo 
                else
                {
                    a[k] = aux[i++];
                }
            }
        }
        public void sortDroidCost()
        {
            sort(droidCollection, 0, lengthOfCollection - 1);
        }

    }
}
