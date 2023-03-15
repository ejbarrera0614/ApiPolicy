
public class PolicyVehicle
{
    public int ID { get; set; }
    public int VehicleID { get; set; }
    public int PolicyID { get; set; }
    public DateTime DateGot { get; set; }
    public Vehicle? Vehicle { get; set; }
    public Policy? Policy { get; set; }
}
