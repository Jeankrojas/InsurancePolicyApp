namespace InsurancePolicyApp.API.Dtos
{
    public class PolicyDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CoveragePeriod { get; set; }

        public double Price { get; set; }
    }
}