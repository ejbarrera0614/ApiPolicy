using InsurancePoliciesAPI.Models;
public class Vehicle
{
    public int ID { get; set; }
    public string? NumberPlate { get; set; }
    public int Model { get; set; }
    public Boolean HaveItInspection { get; set; }
    public int CustomerID { get; set; }
    public Customer? Customer { get; set; }
}
