using System;

namespace PetPals.Model
{
    internal class Pet
    {
        private string name;
        private int age;
        private string breed;

        // Properties
        public string Name
        {
            get { return name; }
            set
            {  name = value; }
                
            
        }

        public int Age
        {
            get { return age; }
            set {  age = value; }
           
            
        }

        public string Breed
        {
            get { return breed; }
            set{ breed = value;} 
                
        }

        public int PetID { get; internal set; }
        public int AvailableForAdoption { get; internal set; }

        // Default constructor
        public Pet() { }

        // Parameterized constructor
        public Pet(string name, int age, string breed)
        {
            Name = name;
            Age = age;
            Breed = breed;
        }

        // ToString override for display purposes
        public override string ToString()
        {
            return( $"Name: {Name}, Age: {Age}, Breed: {Breed}");
        }
    }
}
