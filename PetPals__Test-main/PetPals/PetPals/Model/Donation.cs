

namespace PetPals.Model
    {
        internal abstract class Donation
        {
            // Attributes
            private string donorName;
            private decimal amount;

            public string DonorName
            {
                get { return donorName; }
                set { donorName = value; }
                
                   
                   
             }

            public decimal Amount
            {
                get { return amount; }
                set
                {
                    if (value <= 0)
                        throw new ArgumentException("Donation amount must be greater than zero.");
                    amount = value;
                }
            }

            // Constructor
            protected Donation(string donorName, decimal amount)
            {
                DonorName = donorName;
                Amount = amount;
            }

            // Abstract method to be implemented by derived classes
            public abstract void RecordDonation();

            // ToString override for displaying donation details
            public override string ToString()
            {
                return ($"Donor: {DonorName}, Amount: {Amount:C}");
            }
        }
    }


