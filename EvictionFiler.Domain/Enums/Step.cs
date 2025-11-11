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
        Case = 5,
        Rent = 6,
        Notice =7,
        Attorney = 8,
        CaseInfo = 9,
        Party = 10,
        BuildingInfo = 11,
        PetitionerTenant = 12,
        RespondentLandlord = 13,
        Appearance = 14,
        Relief = 15,
        Billing = 16,

    }

    public enum StepHpd
    {
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
}
