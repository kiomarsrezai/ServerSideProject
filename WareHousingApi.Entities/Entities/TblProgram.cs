namespace WareHousingApi.Entities.Entities
{
    public partial class TblProgram
    {
        public int Id { get; set; }

        public string ProgramName { get; set; }

        public virtual ICollection<TblProgramOperation> TblProgramOperations { get; } = new List<TblProgramOperation>();
    }
}
