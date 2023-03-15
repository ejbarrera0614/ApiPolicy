using InsurancePoliciesAPI.Models;
public class PolicyCoverage
{
    public int ID { get; set; }
    public int PolicyID { get; set; }
    public int CoverageID { get; set; }
    public Policy? Policy { get; set; }
    public Coverage? Coverage { get; set; }
}