namespace InsurancePolicyApp.API.Dtos
{
    public class PolicyForListDto
    {
         public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int CoveragePeriod { get; set; }

        public double Price { get; set; }
    }
}