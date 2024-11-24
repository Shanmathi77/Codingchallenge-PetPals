using PetPals.Model;
using System;
using System.Collections.Generic;

namespace PetPals.Model
{
    internal  class PetShelter
    {
        private List<Pet> availablePets = new();

        public void AddPet(Pet pet)
        {
            availablePets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            availablePets.Remove(pet);
        }

        public void ListAvailablePets()
        {
            if (availablePets.Count == 0)
                Console.WriteLine("No pets available for adoption.");
            else
                foreach (var pet in availablePets)
                    Console.WriteLine(pet.ToString());
        }
    }
}
