using System;

namespace PetPals.Model
{
    internal class Dog : Pet
    {
        private string dogBreed;

        // Property for DogBreed
        public string DogBreed
        {
            get { return dogBreed; }
            set
            {  dogBreed = value; }
                
            
        }

        // Constructor
        public Dog(string name, int age, string breed, string dogBreed) : base(name, age, breed)
        {
            DogBreed = dogBreed;
        }

        // ToString override
        public override string ToString()
        {
            return ($"{base.ToString()}, Dog Breed: {DogBreed}");
        }
    }
}
