using Microsoft.EntityFrameworkCore;

namespace LudoKing.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<adminlogin> adminlogin { get; set; }
        public DbSet<adminincome> adminincome { get; set; }
        public DbSet<panaltyincome> panaltyincome { get; set; }
        public DbSet<game> game { get; set; }
        public DbSet<registration> registration { get; set; }
        public DbSet<wallet> wallet { get; set; }
        public DbSet<appsetting> appsetting { get; set; }
        public DbSet<slider> slider { get; set; }
        public DbSet<contactus> contactus { get; set; }
        public DbSet<withdraw> withdraw { get; set; }
        public DbSet<deposited> deposited { get; set; }
        public DbSet<paymenthistory> paymenthistory { get; set; }
        public DbSet<gamedetail> gamedetail { get; set; }
    }
}
