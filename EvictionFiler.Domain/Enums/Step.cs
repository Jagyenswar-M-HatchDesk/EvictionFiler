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
        CasebackGround = 17,
        DocumentInstructions = 18,
        Reporting = 19,
        Acknowledgment = 20,


    }

    public enum StepHoldover
    {
        CaseAndclient = 0,
        Landlord = 1,
        Building = 2,
        Tenant = 3,
        Terms = 4,
        Case = 5,
        Rent = 6,
        Notice = 7,
       

    }

    public enum StepNonPayment
    {
        CaseAndclient = 0,
        Landlord = 1,
        Building = 2,
        Tenant = 3,
        Terms = 4,
        Rent = 5,
        Notice = 6,
    }

    public enum StepHPD
    {
        CaseAndclient = 0,
        Attorney = 1,
        CaseInfo = 2,
        Party = 3,
        Building = 4,
        Petitioner = 5,
        Respondent= 6,
        Appearance = 7,
        Relief = 8,
        Billing = 9,

    }

    public enum StepPerDiem
    {
        CaseAndclient = 0,
        Attorney = 1,
        CaseInfo = 2,
        Party = 3,
        Appearance = 4,
        Background = 5,
        Document = 6,
        Reporting = 7,
        Billing = 8,
        Acknowledgment = 9,
    }


}
