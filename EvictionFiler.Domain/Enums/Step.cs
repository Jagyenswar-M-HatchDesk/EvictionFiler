using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domian.Enums
{
    public enum Step
    {
        CaseAndclient = 0,
        Landlord = 1,
        Building = 2,
        Tenant = 3,
        Terms = 4,
        Rent = 6,
        Case = 5,
        Notice = 7,

    }

    public enum StepHpd
    {
        CaseAndclient = 0,
        Attorney = 0,
        Case = 1,
        Party = 2,
        Building = 3,
        PetitionerTenant = 4,
        RespondentLandlord = 5,
        Appearance = 6,
        Relief = 7,
        Billing = 8,

    }

    public enum StepPerdiem
    {
        Attorney = 0,
        Case = 1,
        Party = 2,
        Appearance = 3,
        CaseBackground=4,
        DocumentIntractions = 5,
        Reporting = 6, 
        Billing = 7,
        Acknowledgment=8,




    }
}
