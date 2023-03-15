namespace InsurancePoliciesAPI.Models;
public class Coverage
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<Policy>? Policies { get; set; }
}
