using System.Text.Json.Serialization;

namespace InsurancePoliciesAPI.Models;
public class Customer
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string DocumentIdentity { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
    [JsonIgnore] 
    public ICollection<Policy>? Policies { get; set; }
    [JsonIgnore] 
    public ICollection<Vehicle>? Vehicles { get; set; }
}