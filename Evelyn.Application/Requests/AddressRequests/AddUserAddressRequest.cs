namespace Evelyn.Application.Requests.AddressRequest
{
    public class AddUserAddressRequest
    {
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public string MainAddress { get; set; }
        public string ZipCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}