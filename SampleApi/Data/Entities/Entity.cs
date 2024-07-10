namespace SampleApi.Data.Entities
{
    public abstract record Entity
    {
        public int Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsDelete { get; set; }
    }
}
