using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Domain.Model.CompanyAggregate
{
    [Table("company")]
    public class Company
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
