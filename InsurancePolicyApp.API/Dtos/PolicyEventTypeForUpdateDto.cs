namespace InsurancePolicyApp.API.Dtos
{
    public class PolicyEventTypeForUpdateDto
    {
        public double Percent { get; set; }
        
        public int PolicyId { get; set; }
        
        public int EventTypeId { get; set; }     
        
        public int RiskTypeId { get; set; }
    }
}