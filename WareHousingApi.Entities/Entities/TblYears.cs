using System.ComponentModel.DataAnnotations;

namespace WareHousingApi.Entities.Entities
{
    public class TblYears
    {
        [Key]
        public int Id { get; set; }
        public int YearName { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly DateTo { get; set; }

    }
}
