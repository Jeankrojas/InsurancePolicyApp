namespace InsurancePolicyApp.API.Dtos
{
    public class PolicyEventTypeForDetailedDto
    {
        public int Id { get; set; }

        public double Percent { get; set; }
        
        public string Policy { get; set; }
        
        public string EventType { get; set; }     
        
        public string RiskType { get; set; }
    }
}