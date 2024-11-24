

namespace PetPals.Model
    {
        internal class ItemDonation : Donation
        {
            // Additional Attribute
            private string itemType;

            public string ItemType
            {
                get { return itemType; }
            set { itemType = value; }
                
            }

            // Constructor
            public ItemDonation(string donorName, decimal amount, string itemType)
                : base(donorName, amount)
            {
                ItemType = itemType;
            }

            // Implementation of RecordDonation
            public override void RecordDonation()
            {
                Console.WriteLine($"Item Donation Recorded: {this}");
            }

            // ToString override for detailed information
            public override string ToString()
            {
                return ($"{base.ToString()}, Item Type: {ItemType}");
            }
        }
    }

