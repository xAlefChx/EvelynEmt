namespace Evelyn.Application.Requests.ProductRequests
{
    public class UpdateProductRequest
    {
        public string ProductSerial { get; set; }
        public string ProductModel { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public int ProjectId { get; set; }
    }
}
