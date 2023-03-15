using System.Text.Json.Serialization;
using InsurancePoliciesAPI.Models;
public class Policy
{
    // public Policy(string? policyNumber, int? maxCoverage, DateTime? dateInit ) { }
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? PolicyNumber { get; set; }
    public int MaxCoverage { get; set; }
    public DateTime DateInit { get; set; }
    public DateTime DateEnd { get; set; }
    [JsonIgnore] 
    public ICollection<Coverage>? Coverages { get; set; }
    [JsonIgnore] 
    public ICollection<Customer>? Customers { get; set; }
}
