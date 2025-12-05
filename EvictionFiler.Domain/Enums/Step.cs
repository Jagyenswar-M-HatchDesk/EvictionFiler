using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvictionFiler.Domian.Enums
{
    
    public enum StepHoldover
    {
        CaseAndclient = 0,
        Landlord = 1,
        Building = 2,
        Tenant = 3,
        Terms = 4,
        Case = 5,
        Rent = 6,
        //Notice = 8,
        Review = 7,


    }

    public enum StepNonPayment
    {
        CaseAndclient = 0,
        Landlord = 1,
        Building = 2,
        Tenant = 3,
        Lease = 4,
        //Arrears = 5,
        Notice = 5,
        GoodCause = 6,
        //Filing = 8,
        Review = 7,
    }

    public enum StepHPD
    {
        CaseAndclient = 0,
        //Attorney = 1,
        CaseInfo = 1,
        Party = 2,
        Building = 3,
        Petitioner = 4,
        Respondent= 5,
        Appearance = 6,
        Relief = 7,
        Billing = 8,

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
