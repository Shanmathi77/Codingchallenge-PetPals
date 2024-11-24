using PetPals.Model;


namespace Petpals.Repository
{
    internal interface IDonationRepository
    {
       
            void AddDonation(Donation donation);
            Donation GetDonationById(int donationId);
            List<Donation> GetAllDonations();
        }
    }


