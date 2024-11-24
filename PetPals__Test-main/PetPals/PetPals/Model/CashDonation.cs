

namespace PetPals.Model
    {
        internal class CashDonation : Donation
        {
            // Additional Attribute
            private DateTime donationDate;

            public DateTime DonationDate
            {
                get { return donationDate; }
                set
                {
                    if (value > DateTime.Now)
                        throw new ArgumentException("Donation date cannot be in the future.");
                    donationDate = value;
                }
            }

            // Constructor
            public CashDonation(string donorName, decimal amount, DateTime donationDate)
                : base(donorName, amount)
            {
                DonationDate = donationDate;
            }

            // Implementation of RecordDonation
            public override void RecordDonation()
            {
                Console.WriteLine($"Cash Donation Recorded: {this}");
            }

            // ToString override for detailed information
            public override string ToString()
            {
                return $"{base.ToString()}, Donation Date: {DonationDate:yyyy-MM-dd}";
            }
        }
    }


