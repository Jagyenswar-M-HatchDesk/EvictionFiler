namespace EvictionFiler.Domian.Enums
{
    
    public enum StepHoldover
    {
        CaseAndclient = 0,
        Landlord = 1,
        Building = 2,
        Tenant = 3,
        Terms = 4,
        
        Review = 6,


    }

    public enum StepNonPayment
    {
        CaseAndclient = 0,
        Landlord = 1,
        Building = 2,
        Tenant = 3,
        
        Review = 4,
    }

    public enum StepHPD
    {
        CaseAndclient = 0,
        
        CaseInfo = 1,
        Building = 2,
        Party = 3,
        Petitioner = 4,
        Respondent = 5,
        Appearance = 6,
        Relief = 7,
        Billing = 8,
        Review = 9,

    }
    public enum StepPerDiem
    {
        CaseAndclient = 0,

        CaseInfo = 1,

        Background = 2,
        Document = 3,
        Reporting = 4,


    }
    public enum StepIllegalLockout
    {
        CaseAndclient = 0,
       
        CaseInfo = 1,
        Building = 2,
        Party = 3,
        Petitioner = 4,
        Respondent = 5,
        Appearance = 6,
        Relief = 7,
        Billing = 8,
        Review = 9,

    }

   
    public enum StepTenants
    {
        CaseAndclient = 0,
        CaseInfo = 1,
        Background = 2,
        Document = 3,
        Reporting = 4,

    }


}
