using CsvHelper.Configuration;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

public class CensusRow {
    public string Changes { get; set; }
    public string CompanyName { get; set; }
    public string EID { get; set; }
    public string Location { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Relationship { get; set; }
    public string RelationshipCode { get; set; }
    public string SSN { get; set; }
    public string Sex { get; set; }
    public string BirthDate { get; set; }
    public string Race { get; set; }
    public string Citizenship { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string County { get; set; }
    public string Country { get; set; }
    public string PersonalPhone { get; set; }
    public string WorkPhone { get; set; }
    public string MobilePhone { get; set; }
    public string Email { get; set; }
    public string PersonalEmail { get; set; }
    public string EmployeeType { get; set; }
    public string EmployeeStatus { get; set; }
    public string HireDate { get; set; }
    public string TerminationDate { get; set; }
    public string Department { get; set; }
    public string Division { get; set; }
    public string JobClass { get; set; }
    public string JobTitle { get; set; }
    public string MaritalStatus { get; set; }
    public string MaritalDate { get; set; }
    public string MaritalLocation { get; set; }
    public string StudentStatus { get; set; }
    public string ScheduledHours { get; set; }
    public string SickHours { get; set; }
    public string PersonalHours { get; set; }
    public string W2Wages { get; set; }
    public string BenefitCompensationType { get; set; }
    public string BenefitCompensationAmount { get; set; }
    public string PayCycle { get; set; }
    public string PayPeriods { get; set; }
    public string CostFactor { get; set; }
    public string TobaccoUser { get; set; }
    public string Disabled { get; set; }
    public string MedicareADate { get; set; }
    public string MedicareBDate { get; set; }
    public string MedicareCDate { get; set; }
    public string MedicareDDate { get; set; }
    public string MedicalPCPName { get; set; }
    public string MedicalPCPID { get; set; }
    public string DentalPCPName { get; set; }
    public string DentalPCPID { get; set; }
    public string IPANumber { get; set; }
    public string OBGYN { get; set; }
    public string BenefitEligibleDate { get; set; }
    public string UnlockEnrollmentDate { get; set; }
    public string OriginalEffectiveDateInfo { get; set; }
    public string SubscriberKey { get; set; }
    public string PlanType { get; set; }
    public string PlanEffectiveStartDate { get; set; }
    public string PlanEffectiveEndDate { get; set; }
    public string PlanAdminName { get; set; }
    public string PlanDisplayName { get; set; }
    public string PlanImportID { get; set; }
    public string EffectiveDate { get; set; }
    public string ActivityDate { get; set; }
    public string CoverageDetails { get; set; }
    public string ElectionStatus { get; set; }
    public string ProcessedDate { get; set; }
    public string RiderCodes { get; set; }
    public string Action { get; set; }
    public string WaiveReason { get; set; }
    public string PolicyNumber { get; set; }
    public string SubgroupNumber { get; set; }
    public string AgeDetermination { get; set; }
    public string Carrier { get; set; }
    public string TotalRate { get; set; }
    public string EmployeeRate { get; set; }
    public string SpouseRate { get; set; }
    public string ChildrenRate { get; set; }
    public string EmployeeContribution { get; set; }
    public string EmployeePreTaxCost { get; set; }
    public string EmployeePostTaxCost { get; set; }
    public string EmployeeCostPerDeductionPeriod { get; set; }
    public string PlanDeductionCycle { get; set; }
    public string LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public string ESignDate { get; set; }
    //public string CalPERS_ID { get; set; }
    public string EnrolledBy { get; set; }
    public string NewBusiness { get; set; }
    public string VSPCode { get; set; }


    public bool Compare(CensusRow rhs) {
        bool matched = true;

        if (this.Changes == null)
            this.Changes = string.Empty;

        if (rhs.Changes == null)
            rhs.Changes = string.Empty;

        if (this.ToString() != rhs.ToString()) {

             matched = false;
            if (this.SSN != rhs.SSN) {
                rhs.Changes = this.Changes = this.Changes + "|SSN|";
            }
            if (this.Address1 != rhs.Address1) {
                rhs.Changes = this.Changes = this.Changes + "|Address1|";
            }
            if (this.Address2 != rhs.Address2) {
                rhs.Changes = this.Changes = this.Changes + "|Address2|";
            }
            if (this.City != rhs.City) {
                rhs.Changes = this.Changes = this.Changes + "|City|";
            }
            if (this.State != rhs.State) {
                rhs.Changes = this.Changes = this.Changes + "|State|";
            }
            if (this.Zip != rhs.Zip) {
                rhs.Changes = this.Changes = this.Changes + "|Zip|";
            }
            if (this.PersonalPhone != rhs.PersonalPhone) {
                rhs.Changes = this.Changes = this.Changes + "|PersonalPhone|";
            }
            if (this.WorkPhone != rhs.WorkPhone) {
                rhs.Changes = this.Changes = this.Changes + "|WorkPhone|";
            }
            if (this.MobilePhone != rhs.MobilePhone) {
                rhs.Changes = this.Changes = this.Changes + "|MobilePhone|";
            }
            if (this.EmployeeStatus != rhs.EmployeeStatus) {
                rhs.Changes = this.Changes = this.Changes + "|EmployeeStatus|";
            }
            if (this.HireDate != rhs.HireDate) {
                rhs.Changes = this.Changes = this.Changes + "|HireDate|";
            }
            if (this.TerminationDate != rhs.TerminationDate) {
                rhs.Changes = this.Changes = this.Changes + "|TerminationDate|";
            }
            if (this.JobClass != rhs.JobClass) {
                rhs.Changes = this.Changes = this.Changes + "|JobClass|";
            }
            if (this.Division != rhs.Division) {
                rhs.Changes = this.Changes = this.Changes + "|Division|";
            }
            if (this.MaritalStatus != rhs.MaritalStatus) {
                rhs.Changes = this.Changes = this.Changes + "|MaritalStatus|";
            }
            if (this.ScheduledHours != rhs.ScheduledHours) {
                rhs.Changes = this.Changes = this.Changes + "|ScheduledHours|";
            }
            if (this.PayCycle != rhs.PayCycle) {
                rhs.Changes = this.Changes = this.Changes + "|PayCycle|";
            }
            if (this.PlanDisplayName != rhs.PlanDisplayName) {
                rhs.Changes = this.Changes = this.Changes + "|PlanDisplayName|";
            }
            if (this.CoverageDetails != rhs.CoverageDetails) {
                rhs.Changes = this.Changes = this.Changes + "|CoverageDetails|";
            }
            if (this.EffectiveDate != rhs.EffectiveDate) {
                rhs.Changes = this.Changes = this.Changes + "|EffectiveDate|";
            }
            if (this.ElectionStatus != rhs.ElectionStatus) {
                rhs.Changes = this.Changes = this.Changes + "|ElectionStatus|";
            }
            if (this.TotalRate != rhs.TotalRate) {
                rhs.Changes = this.Changes = this.Changes + "|TotalRate|";
            }
            if (this.EmployeeCostPerDeductionPeriod != rhs.EmployeeCostPerDeductionPeriod) {
                rhs.Changes = this.Changes = this.Changes + "|EmployeeCostPerDeductionPeriod|";
            }
            if (this.ESignDate != rhs.ESignDate) {
                rhs.Changes = this.Changes = this.Changes + "|ESignDate|";
            }

            rhs.Changes = rhs.Changes.Replace("||", "|").Trim();
            if (rhs.Changes.StartsWith("|")) {
                rhs.Changes = rhs.Changes.Substring(1);
            }

            if (rhs.Changes.EndsWith("|")) {
                rhs.Changes = rhs.Changes.Substring(0, rhs.Changes.Length - 1);
            }
        }

        return matched;
    }

    // override to print all frields in a CensusRow
    public override string ToString() {
        if (this.BenefitCompensationType == null)
            BenefitCompensationType = string.Empty;
        if (this.BenefitCompensationAmount == null)
            BenefitCompensationAmount = string.Empty;

        //if (Sex == null)
           // Sex = "";

        //string retStr = this.CompanyName.Trim() + " | " + this.EID.Trim() + " | " + this.Location.Trim() + " | " + this.FirstName.Trim() + " | " +
        //    this.MiddleName.Trim() + " | " + this.LastName.Trim() + " | " + this.Relationship.Trim() + " | " + this.RelationshipCode.Trim() + " | " +
        //    this.SSN.Trim() + " | " + this.Sex.Trim() + " | " + this.BirthDate.Trim() + " | " + this.Race.Trim() + " | " + this.Citizenship.Trim() + " | " +
        //    this.Address1.Trim() + " | " + this.Address2.Trim() + " | " + this.City.Trim() + " | " + this.State.Trim() + " | " + this.Zip.Trim() + " | " +
        //    this.County.Trim() + " | " + this.Country.Trim() + " | " + this.PersonalPhone.Trim() + " | " + this.WorkPhone.Trim() + " | " +
        //    this.MobilePhone.Trim() + " | " + this.Email.Trim() + " | " + this.PersonalEmail.Trim() + " | " + this.EmployeeType + " | " +
        //    this.EmployeeStatus.Trim() + " | " + this.HireDate.Trim() + " | " + this.TerminationDate.Trim() + " | " + this.Department + " | " +
        //    this.Division.Trim() + " | " + this.JobClass.Trim() + " | " + this.JobTitle.Trim() + " | " + this.MaritalStatus.Trim() + " | " + this.MaritalDate + " | " +
        //    this.MaritalLocation.Trim() + " | " + this.StudentStatus.Trim() + " | " + this.ScheduledHours.Trim() + " | " + this.SickHours + " | " +
        //    this.PersonalHours.Trim() + " | " + this.W2Wages.Trim() + " | " + this.BenefitCompensationAmount.Trim() + " | " + this.BenefitCompensationType + " | " +
        //    this.PayCycle.Trim() + " | " + this.PayPeriods.Trim() + " | " + this.CostFactor.Trim() + " | " + this.TobaccoUser.Trim() + " | " + this.Disabled + " | " +
        //    this.MedicareADate.Trim() + " | " + this.MedicareBDate.Trim() + " | " + this.MedicareCDate.Trim() + " | " + this.MedicareDDate + " | " +
        //    this.MedicalPCPName.Trim() + " | " + this.MedicalPCPID.Trim() + " | " + this.DentalPCPName.Trim() + " | " + this.DentalPCPID + " | " +
        //    this.IPANumber.Trim() + " | " + this.OBGYN.Trim() + " | " + this.BenefitEligibleDate.Trim() + " | " + //this.UnlockEnrollmentDate + " | " +
        //    this.OriginalEffectiveDateInfo.Trim() + " | " + this.SubscriberKey.Trim() + " | " + this.PlanType.Trim() + " | " + this.PlanEffectiveStartDate + " | " +
        //    this.PlanEffectiveEndDate.Trim() + " | " + this.PlanAdminName.Trim() + " | " + this.PlanDisplayName.Trim() + " | " + this.PlanImportID + " | " +
        //    this.EffectiveDate.Trim() + " | " + this.CoverageDetails.Trim() + " | " + this.ElectionStatus.Trim() + " | " + this.RiderCodes + " | " +
        //    this.Action.Trim() + " | " + this.WaiveReason.Trim() + " | " + this.PolicyNumber.Trim() + " | " + this.SubgroupNumber + " | " +
        //    this.AgeDetermination.Trim() + " | " + this.Carrier.Trim() + " | " + this.TotalRate.Trim() + " | " + this.EmployeeRate + " | " +
        //    this.SpouseRate.Trim() + " | " + this.ChildrenRate.Trim() + " | " + this.EmployeeContribution.Trim() + " | " + this.EmployeePreTaxCost + " | " +
        //    this.EmployeePostTaxCost.Trim() + " | " + this.EmployeeCostPerDeductionPeriod.Trim() + " | " + this.PlanDeductionCycle.Trim() + " | " +
        //    this.ESignDate.Trim() + " | " + Changes.Trim() + " | " + VSPCode;
        string retStr = this.CompanyName.Trim() + " | " + this.EID.Trim() + " | " + this.Location.Trim() + " | " + this.FirstName.Trim() + " | ";
        retStr += this.MiddleName.Trim() + " | " + this.LastName.Trim() + " | " + this.Relationship.Trim() + " | " + this.RelationshipCode.Trim() + " | ";
        retStr += this.SSN.Trim() + " | " + this.Sex.Trim() + " | " + this.BirthDate.Trim() + " | " + this.Race.Trim() + " | " + this.Citizenship.Trim() + " | ";
        retStr += this.Address1.Trim() + " | " + this.Address2.Trim() + " | " + this.City.Trim() + " | " + this.State.Trim() + " | " + this.Zip.Trim() + " | ";
        retStr += this.County.Trim() + " | " + this.Country.Trim() + " | " + this.PersonalPhone.Trim() + " | " + this.WorkPhone.Trim() + " | ";
        retStr += this.MobilePhone.Trim() + " | " + this.Email.Trim() + " | " + this.PersonalEmail.Trim() + " | " + this.EmployeeType + " | ";
        retStr += this.EmployeeStatus.Trim() + " | " + this.HireDate.Trim() + " | " + this.TerminationDate.Trim() + " | " + this.Department + " | ";
        retStr += this.Division.Trim() + " | " + this.JobClass.Trim() + " | " + this.JobTitle.Trim() + " | " + this.MaritalStatus.Trim() + " | " + this.MaritalDate + " | ";
        retStr += this.MaritalLocation.Trim() + " | " + this.StudentStatus.Trim() + " | " + this.ScheduledHours.Trim() + " | " + this.SickHours + " | ";
        retStr += this.PersonalHours.Trim() + " | " + this.W2Wages.Trim() + " | " + this.BenefitCompensationAmount.Trim() + " | " + this.BenefitCompensationType + " | ";
        retStr += this.PayCycle.Trim() + " | " + this.PayPeriods.Trim() + " | " + this.CostFactor.Trim() + " | " + this.TobaccoUser.Trim() + " | " + this.Disabled + " | ";
        retStr += this.MedicareADate.Trim() + " | " + this.MedicareBDate.Trim() + " | " + this.MedicareCDate.Trim() + " | " + this.MedicareDDate + " | ";
        retStr += this.MedicalPCPName.Trim() + " | " + this.MedicalPCPID.Trim() + " | " + this.DentalPCPName.Trim() + " | " + this.DentalPCPID + " | ";
        retStr += this.IPANumber.Trim() + " | " + this.OBGYN.Trim() + " | " + this.BenefitEligibleDate.Trim() + " | "; //this.UnlockEnrollmentDate + " | " ;
        retStr += this.OriginalEffectiveDateInfo.Trim() + " | " + this.SubscriberKey.Trim() + " | " + this.PlanType.Trim() + " | " + this.PlanEffectiveStartDate + " | ";
        retStr += this.PlanEffectiveEndDate.Trim() + " | " + this.PlanAdminName.Trim() + " | " + this.PlanDisplayName.Trim() + " | " + this.PlanImportID + " | ";
        retStr += this.EffectiveDate.Trim() + " | " + this.CoverageDetails.Trim() + " | " + this.ElectionStatus.Trim() + " | " + this.RiderCodes + " | ";
        retStr += this.Action.Trim() + " | " + this.WaiveReason.Trim() + " | " + this.PolicyNumber.Trim() + " | " + this.SubgroupNumber + " | ";
        retStr += this.AgeDetermination.Trim() + " | " + this.Carrier.Trim() + " | " + this.TotalRate.Trim() + " | " + this.EmployeeRate + " | ";
        retStr += this.SpouseRate.Trim() + " | " + this.ChildrenRate.Trim() + " | " + this.EmployeeContribution.Trim() + " | " + this.EmployeePreTaxCost + " | ";
        retStr += this.EmployeePostTaxCost.Trim() + " | " + this.EmployeeCostPerDeductionPeriod.Trim() + " | " + this.PlanDeductionCycle.Trim() + " | ";
        retStr += this.ESignDate.Trim() + " | " + Changes.Trim() + " | " + VSPCode;

        return retStr.Replace("  ", " ").Trim();
    }
}

public class CensusRowClassMap : ClassMap<CensusRow> {
    public CensusRowClassMap() {
        this.Map(m => m.CompanyName).Name("Company Name").ToString().Trim();
        this.Map(m => m.EID).Name("EID").ToString().Trim();
        this.Map(m => m.Location).Name("Location").ToString().Trim();
        this.Map(m => m.FirstName).Name("First Name").ToString().Trim();
        this.Map(m => m.MiddleName).Name("Middle Name").ToString().Trim();
        this.Map(m => m.LastName).Name("Last Name").ToString().Trim();
        this.Map(m => m.Relationship).Name("Relationship").ToString().Trim();
        this.Map(m => m.RelationshipCode).Name("Relationship Code").ToString().Trim();
        this.Map(m => m.SSN).Name("SSN").ToString().Trim();
        this.Map(m => m.Sex).Name("Sex").ToString().Trim();
        this.Map(m => m.BirthDate).Name("Birth Date").ToString().Trim();
        this.Map(m => m.Race).Name("Race").ToString().Trim();
        this.Map(m => m.Citizenship).Name("Citizenship").ToString().Trim();
        this.Map(m => m.Address1).Name("Address 1").ToString().Trim();
        this.Map(m => m.Address2).Name("Address 2").ToString().Trim();
        this.Map(m => m.City).Name("City").ToString().Trim();
        this.Map(m => m.State).Name("State").ToString().Trim();
        this.Map(m => m.Zip).Name("Zip").ToString().Trim();
        this.Map(m => m.County).Name("County").ToString().Trim();
        this.Map(m => m.Country).Name("Country").ToString().Trim();
        this.Map(m => m.PersonalPhone).Name("Personal Phone").ToString().Trim();
        this.Map(m => m.WorkPhone).Name("Work Phone").ToString().Trim();
        this.Map(m => m.MobilePhone).Name("Mobile Phone").ToString().Trim();
        this.Map(m => m.Email).Name("Email").ToString().Trim();
        this.Map(m => m.PersonalEmail).Name("Personal Email").ToString().Trim();
        this.Map(m => m.EmployeeType).Name("Employee Type").ToString().Trim();
        this.Map(m => m.EmployeeStatus).Name("Employee Status").ToString().Trim();
        this.Map(m => m.HireDate).Name("Hire Date").ToString().Trim();
        this.Map(m => m.TerminationDate).Name("Termination Date").ToString().Trim();
        this.Map(m => m.Department).Name("Department").ToString().Trim();
        this.Map(m => m.Division).Name("Division").ToString().Trim();
        this.Map(m => m.JobClass).Name("Job Class").ToString().Trim();
        this.Map(m => m.JobTitle).Name("Job Title").ToString().Trim();
        this.Map(m => m.MaritalStatus).Name("Marital Status").ToString().Trim();
        this.Map(m => m.MaritalDate).Name("Marital Date").ToString().Trim();
        this.Map(m => m.MaritalLocation).Name("Marital Location").ToString().Trim();
        this.Map(m => m.StudentStatus).Name("Student Status").ToString().Trim();
        this.Map(m => m.ScheduledHours).Name("Scheduled Hours").ToString().Trim();
        this.Map(m => m.SickHours).Name("Sick Hours").ToString().Trim();
        this.Map(m => m.PersonalHours).Name("Personal Hours").ToString().Trim();
        this.Map(m => m.W2Wages).Name("W2 Wages").ToString().Trim();
        this.Map(m => m.BenefitCompensationAmount).Name("Benefit Compensation Amount").ToString().Trim();
        this.Map(m => m.BenefitCompensationType).Name("Benefit Compensation Type").ToString().Trim();
        this.Map(m => m.PayCycle).Name("Pay Cycle").ToString().Trim();
        this.Map(m => m.PayPeriods).Name("Pay Periods").ToString().Trim();
        this.Map(m => m.CostFactor).Name("Cost Factor").ToString().Trim();
        this.Map(m => m.TobaccoUser).Name("Tobacco User").ToString().Trim();
        this.Map(m => m.Disabled).Name("Disabled").ToString().Trim();
        this.Map(m => m.MedicareADate).Name("Medicare A Date").ToString().Trim();
        this.Map(m => m.MedicareBDate).Name("Medicare B Date").ToString().Trim();
        this.Map(m => m.MedicareCDate).Name("Medicare C Date").ToString().Trim();
        this.Map(m => m.MedicareDDate).Name("Medicare D Date").ToString().Trim();
        this.Map(m => m.MedicalPCPName).Name("Medical PCP Name").ToString().Trim();
        this.Map(m => m.MedicalPCPID).Name("Medical PCP ID").ToString().Trim();
        this.Map(m => m.DentalPCPName).Name("Dental PCP Name").ToString().Trim();
        this.Map(m => m.DentalPCPID).Name("Dental PCP ID").ToString().Trim();
        this.Map(m => m.IPANumber).Name("IPA Number").ToString().Trim();
        this.Map(m => m.OBGYN).Name("OBGYN").ToString().Trim();
        this.Map(m => m.BenefitEligibleDate).Name("Benefit Eligible Date").ToString().Trim();
        this.Map(m => m.UnlockEnrollmentDate).Name("Unlock Enrollment Date").ToString().Trim();
        this.Map(m => m.OriginalEffectiveDateInfo).Name("Original Effective Date Info").ToString().Trim();
        this.Map(m => m.SubscriberKey).Name("Subscriber Key").ToString().Trim();
        this.Map(m => m.PlanType).Name("Plan Type").ToString().Trim();
        this.Map(m => m.PlanEffectiveStartDate).Name("Plan Effective Start Date").ToString().Trim();
        this.Map(m => m.PlanEffectiveEndDate).Name("Plan Effective End Date").ToString().Trim();
        this.Map(m => m.PlanAdminName).Name("Plan Admin Name").ToString().Trim();
        this.Map(m => m.PlanDisplayName).Name("Plan Display Name").ToString().Trim();
        this.Map(m => m.PlanImportID).Name("Plan Import ID").ToString().Trim();
        this.Map(m => m.EffectiveDate).Name("Effective Date").ToString().Trim();
        this.Map(m => m.ActivityDate).Name("Activity Date").ToString().Trim();
        this.Map(m => m.CoverageDetails).Name("Coverage Details").ToString().Trim();
        this.Map(m => m.ElectionStatus).Name("Election Status").ToString().Trim();
        this.Map(m => m.ProcessedDate).Name("Processed Date").ToString().Trim();
        this.Map(m => m.RiderCodes).Name("Rider Codes").ToString().Trim();
        this.Map(m => m.Action).Name("Action").ToString().Trim();
        this.Map(m => m.WaiveReason).Name("Waive Reason").ToString().Trim();
        this.Map(m => m.PolicyNumber).Name("Policy Number").ToString().Trim();
        this.Map(m => m.SubgroupNumber).Name("Subgroup Number").ToString().Trim();
        this.Map(m => m.AgeDetermination).Name("Age Determination").ToString().Trim();
        this.Map(m => m.Carrier).Name("Carrier").ToString().Trim();
        this.Map(m => m.TotalRate).Name("Total Rate").ToString().Trim();
        this.Map(m => m.EmployeeRate).Name("Employee Rate").ToString().Trim();
        this.Map(m => m.SpouseRate).Name("Spouse Rate").ToString().Trim();
        this.Map(m => m.ChildrenRate).Name("Children Rate").ToString().Trim();
        this.Map(m => m.EmployeeContribution).Name("Employee Contribution").ToString().Trim();
        this.Map(m => m.EmployeePreTaxCost).Name("Employee Pre-Tax Cost").ToString().Trim();
        this.Map(m => m.EmployeePostTaxCost).Name("Employee Post-Tax Cost").ToString().Trim();
        this.Map(m => m.EmployeeCostPerDeductionPeriod).Name("Employee Cost Per Deduction Period").ToString().Trim();
        this.Map(m => m.PlanDeductionCycle).Name("Plan Deduction Cycle").ToString().Trim();
        this.Map(m => m.LastModifiedDate).Name("Last Modified Date").ToString().Trim();
        this.Map(m => m.LastModifiedBy).Name("Last Modified By").ToString().Trim();
        this.Map(m => m.ESignDate).Name("E-Sign Date").ToString().Trim();
        //this.Map(m => m.CalPERSID).Name("CalPERS ID").ToString().Trim();
        this.Map(m => m.EnrolledBy).Name("Enrolled By").ToString().Trim();
        this.Map(m => m.NewBusiness).Name("New Business").ToString().Trim();
        this.Map(m => m.VSPCode).Name("VSP Code").ToString().Trim();

        // Map(m => m.EnrolledBy).Name("Enrolled By");
        // Map(m => m.NewBusiness).Name("New Business");
    }

    public static void WriteHeader(ExcelWorksheet worksheet) {
        if (worksheet.Cells[1, 1].Value != null)
            worksheet.Cells[1, 1].Value = "Changes";
        if (worksheet.Cells[1, 2].Value != null)
            worksheet.Cells[1, 2].Value = "Company Name";
        if (worksheet.Cells[1, 3].Value != null)
            worksheet.Cells[1, 3].Value = "EID";
        if (worksheet.Cells[1, 4].Value != null)
            worksheet.Cells[1, 4].Value = "Location";
        if (worksheet.Cells[1, 5].Value != null)
            worksheet.Cells[1, 5].Value = "First Name";
        if (worksheet.Cells[1, 6].Value != null)
            worksheet.Cells[1, 6].Value = "Middle Name";
        if (worksheet.Cells[1, 7].Value != null)
            worksheet.Cells[1, 7].Value = "Last Name";
        if (worksheet.Cells[1, 8].Value != null)
            worksheet.Cells[1, 8].Value = "Relationship";
        if (worksheet.Cells[1, 9].Value != null)
            worksheet.Cells[1, 9].Value = "Relationship Code";
        if (worksheet.Cells[1, 10].Value != null)
            worksheet.Cells[1, 10].Value = "SSN";
        if (worksheet.Cells[1, 11].Value != null)
            worksheet.Cells[1, 11].Value = "Sex";
        if (worksheet.Cells[1, 12].Value != null)
            worksheet.Cells[1, 12].Value = "Birth Date";
        if (worksheet.Cells[1, 13].Value != null)
            worksheet.Cells[1, 13].Value = "Race";
        if (worksheet.Cells[1, 14].Value != null)
            worksheet.Cells[1, 14].Value = "Citizenship";
        if (worksheet.Cells[1, 15].Value != null)
            worksheet.Cells[1, 15].Value = "Address 1";
        if (worksheet.Cells[1, 16].Value != null)
            worksheet.Cells[1, 16].Value = "Address 2";
        if (worksheet.Cells[1, 17].Value != null)
            worksheet.Cells[1, 17].Value = "City";
        if (worksheet.Cells[1, 18].Value != null)
            worksheet.Cells[1, 18].Value = "State";
        if (worksheet.Cells[1, 19].Value != null)
            worksheet.Cells[1, 19].Value = "Zip";
        if (worksheet.Cells[1, 20].Value != null)
            worksheet.Cells[1, 20].Value = "County";
        if (worksheet.Cells[1, 21].Value != null)
            worksheet.Cells[1, 21].Value = "Country";
        if (worksheet.Cells[1, 22].Value != null)
            worksheet.Cells[1, 22].Value = "Personal Phone";
        if (worksheet.Cells[1, 23].Value != null)
            worksheet.Cells[1, 23].Value = "Work Phone";
        if (worksheet.Cells[1, 24].Value != null)
            worksheet.Cells[1, 24].Value = "Mobile Phone";
        if (worksheet.Cells[1, 25].Value != null)
            worksheet.Cells[1, 25].Value = "Email";
        if (worksheet.Cells[1, 26].Value != null)
            worksheet.Cells[1, 26].Value = "Personal Email";
        if (worksheet.Cells[1, 27].Value != null)
            worksheet.Cells[1, 27].Value = "Employee Type";
        if (worksheet.Cells[1, 28].Value != null)
            worksheet.Cells[1, 28].Value = "Employee Status";
        if (worksheet.Cells[1, 29].Value != null)
            worksheet.Cells[1, 29].Value = "Hire Date";
        if (worksheet.Cells[1, 30].Value != null)
            worksheet.Cells[1, 30].Value = "Termination Date";
        if (worksheet.Cells[1, 31].Value != null)
            worksheet.Cells[1, 31].Value = "Department";
        if (worksheet.Cells[1, 32].Value != null)
            worksheet.Cells[1, 32].Value = "Division";
        if (worksheet.Cells[1, 33].Value != null)
            worksheet.Cells[1, 33].Value = "Job Class";
        if (worksheet.Cells[1, 34].Value != null)
            worksheet.Cells[1, 34].Value = "Job Title";
        if (worksheet.Cells[1, 35].Value != null)
            worksheet.Cells[1, 35].Value = "Marital Status";
        if (worksheet.Cells[1, 36].Value != null)
            worksheet.Cells[1, 36].Value = "Marital Date";
        if (worksheet.Cells[1, 37].Value != null)
            worksheet.Cells[1, 37].Value = "Marital Location";
        if (worksheet.Cells[1, 38].Value != null)
            worksheet.Cells[1, 38].Value = "Student Status";
        if (worksheet.Cells[1, 39].Value != null)
            worksheet.Cells[1, 39].Value = "Scheduled Hours";
        if (worksheet.Cells[1, 40].Value != null)
            worksheet.Cells[1, 40].Value = "Sick Hours";
        if (worksheet.Cells[1, 41].Value != null)
            worksheet.Cells[1, 41].Value = "Personal Hours";
        if (worksheet.Cells[1, 42].Value != null)
            worksheet.Cells[1, 42].Value = "W2 Wages";
        if (worksheet.Cells[1, 43].Value != null)
            worksheet.Cells[1, 43].Value = "Compensation";
        if (worksheet.Cells[1, 44].Value != null)
            worksheet.Cells[1, 44].Value = "Compensation Type";
        if (worksheet.Cells[1, 45].Value != null)
            worksheet.Cells[1, 45].Value = "Pay Cycle";
        if (worksheet.Cells[1, 46].Value != null)
            worksheet.Cells[1, 46].Value = "Pay Periods";
        if (worksheet.Cells[1, 47].Value != null)
            worksheet.Cells[1, 47].Value = "Cost Factor";
        if (worksheet.Cells[1, 48].Value != null)
            worksheet.Cells[1, 48].Value = "Tobacco User";
        if (worksheet.Cells[1, 49].Value != null)
            worksheet.Cells[1, 49].Value = "Disabled";
        if (worksheet.Cells[1, 50].Value != null)
            worksheet.Cells[1, 50].Value = "Medicare A Date";
        if (worksheet.Cells[1, 51].Value != null)
            worksheet.Cells[1, 51].Value = "Medicare B Date";
        if (worksheet.Cells[1, 52].Value != null)
            worksheet.Cells[1, 52].Value = "Medicare C Date";
        if (worksheet.Cells[1, 53].Value != null)
            worksheet.Cells[1, 53].Value = "Medicare D Date";
        if (worksheet.Cells[1, 54].Value != null)
            worksheet.Cells[1, 54].Value = "Medical PCP Name";
        if (worksheet.Cells[1, 55].Value != null)
            worksheet.Cells[1, 55].Value = "Medical PCP ID";
        if (worksheet.Cells[1, 56].Value != null)
            worksheet.Cells[1, 56].Value = "Dental PCP Name";
        if (worksheet.Cells[1, 57].Value != null)
            worksheet.Cells[1, 57].Value = "Dental PCP ID";
        if (worksheet.Cells[1, 58].Value != null)
            worksheet.Cells[1, 58].Value = "IPA Number";
        if (worksheet.Cells[1, 59].Value != null)
            worksheet.Cells[1, 59].Value = "OBGYN";
        if (worksheet.Cells[1, 60].Value != null)
            worksheet.Cells[1, 60].Value = "Benefit Eligible Date";
        if (worksheet.Cells[1, 61].Value != null)
            worksheet.Cells[1, 61].Value = "Unlock Enrollment Date";
        if (worksheet.Cells[1, 62].Value != null)
            worksheet.Cells[1, 62].Value = "Original Effective Date Info";
        if (worksheet.Cells[1, 63].Value != null)
            worksheet.Cells[1, 63].Value = "Subscriber Key";
        if (worksheet.Cells[1, 64].Value != null)
            worksheet.Cells[1, 64].Value = "Plan Type";
        if (worksheet.Cells[1, 65].Value != null)
            worksheet.Cells[1, 65].Value = "Plan Effective Start Date";
        if (worksheet.Cells[1, 66].Value != null)
            worksheet.Cells[1, 66].Value = "Plan Effective End Date";
        if (worksheet.Cells[1, 67].Value != null)
            worksheet.Cells[1, 67].Value = "Plan Admin Name";
        if (worksheet.Cells[1, 68].Value != null)
            worksheet.Cells[1, 68].Value = "Plan Display Name";
        if (worksheet.Cells[1, 69].Value != null)
            worksheet.Cells[1, 69].Value = "Plan Import ID";
        if (worksheet.Cells[1, 70].Value != null)
            worksheet.Cells[1, 70].Value = "Effective Date";
        if (worksheet.Cells[1, 71].Value != null)
            worksheet.Cells[1, 71].Value = "Activity Date";
        if (worksheet.Cells[1, 72].Value != null)
            worksheet.Cells[1, 72].Value = "Coverage Details";
        if (worksheet.Cells[1, 73].Value != null)
            worksheet.Cells[1, 73].Value = "Election Status";
        if (worksheet.Cells[1, 74].Value != null)
            worksheet.Cells[1, 74].Value = "Processed Date";
        if (worksheet.Cells[1, 75].Value != null)
            worksheet.Cells[1, 75].Value = "Rider Codes";
        if (worksheet.Cells[1, 76].Value != null)
            worksheet.Cells[1, 76].Value = "Action";
        if (worksheet.Cells[1, 77].Value != null)
            worksheet.Cells[1, 77].Value = "Waive Reason";
        if (worksheet.Cells[1, 78].Value != null)
            worksheet.Cells[1, 78].Value = "Policy Number";
        if (worksheet.Cells[1, 79].Value != null)
            worksheet.Cells[1, 79].Value = "Subgroup Number";
        if (worksheet.Cells[1, 80].Value != null)
            worksheet.Cells[1, 80].Value = "Age Determination";
        if (worksheet.Cells[1, 81].Value != null)
            worksheet.Cells[1, 81].Value = "Carrier";
        if (worksheet.Cells[1, 82].Value != null)
            worksheet.Cells[1, 82].Value = "Total Rate";
        if (worksheet.Cells[1, 83].Value != null)
            worksheet.Cells[1, 83].Value = "Employee Rate";
        if (worksheet.Cells[1, 84].Value != null)
            worksheet.Cells[1, 84].Value = "Spouse Rate";
        if (worksheet.Cells[1, 85].Value != null)
            worksheet.Cells[1, 85].Value = "Children Rate";
        if (worksheet.Cells[1, 86].Value != null)
            worksheet.Cells[1, 86].Value = "Employee Contribution";
        if (worksheet.Cells[1, 87].Value != null)
            worksheet.Cells[1, 87].Value = "Employee Pre-Tax Cost";
        if (worksheet.Cells[1, 88].Value != null)
            worksheet.Cells[1, 88].Value = "Employee Post-Tax Cost";
        if (worksheet.Cells[1, 89].Value != null)
            worksheet.Cells[1, 89].Value = "Employee Cost Per Deduction Period";
        if (worksheet.Cells[1, 90].Value != null)
            worksheet.Cells[1, 90].Value = "Plan Deduction Cycle";
        if (worksheet.Cells[1, 91].Value != null)
            worksheet.Cells[1, 91].Value = "Last Modified Date";
        if (worksheet.Cells[1, 92].Value != null)
            worksheet.Cells[1, 92].Value = "Last Modified By";
        if (worksheet.Cells[1, 93].Value != null)
            worksheet.Cells[1, 93].Value = "E-Sign Date";
        if (worksheet.Cells[1, 94].Value != null)
            worksheet.Cells[1, 94].Value = "CalPERS ID";
        if (worksheet.Cells[1, 95].Value != null)
            worksheet.Cells[1, 95].Value = "Enrolled By";
        if (worksheet.Cells[1, 96].Value != null)
            worksheet.Cells[1, 96].Value = "New Business";
        if (worksheet.Cells[1, 97].Value != null)
            worksheet.Cells[1, 97].Value = "VSP Code";
    }
}
