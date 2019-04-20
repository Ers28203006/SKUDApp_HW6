namespace SKUDApp_HW6.DataAccess
{
    using SKUDApp_HW6.Models;
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext") {}
       
        public DbSet<Controller> Controller { get; set; }
        public DbSet<IdentificationCard> IdentificationCards { get; set; }
        public DbSet<InputReader> InputReader { get; set; }
        public DbSet<OutputReader> OutputReader { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}