using System.Text.Json.Serialization;

namespace Evelyn.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int CityId { get; set; }
        public int ProvinceId { get; set; }
        public string MainAddress { get; set; }
        public string ZipCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        #region Relations
        public User User { get; set; }
        
        [JsonIgnore]
        public ICollection<Project> Projects { get; set; }

        #endregion
    }
}