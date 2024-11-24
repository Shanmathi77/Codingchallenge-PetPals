using PetPals.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Service
{
    internal interface IDonationService
    {

   
            void RecordCashDonation(CashDonation cashDonation);
            void RecordItemDonation(ItemDonation itemDonation);
        }
    }


