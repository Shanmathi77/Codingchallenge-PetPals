namespace PetPals.Model
    {
        internal class Cat : Pet
        {
            private string catColor;
            public string CatColor
            {
                get { return catColor; }
                set { catColor = value; }
            
               
            }
            public Cat(string name, int age, string breed, string catColor) : base(name, age, breed)
            {
                CatColor = catColor;
            }

            // ToString override
            public override string ToString()
            {
                return ($"{base.ToString()}, Cat Color: {CatColor}");
            }
        }
    }

