namespace WareHousingApi.Entities.Entities
{
    public partial class TblBudgetProcess
    {
        public int Id { get; set; }

        public string ProcessName { get; set; }

        public virtual ICollection<TblCoding> TblCodings { get; } = new List<TblCoding>();
    }
}
