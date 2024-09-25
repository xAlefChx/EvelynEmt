namespace Evelyn.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductSerial { get; set; }
        public string ProductModel { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int ProjectId { get; set; }

        #region Relations
        public Project Project { get; set; }
        #endregion
    }
}