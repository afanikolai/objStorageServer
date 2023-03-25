using Microsoft.EntityFrameworkCore;

namespace objStorageServer.Models
{
    public class StorageDbContext : DbContext
    {
        public DbSet<Table> Tables { get; set; } = null!;
        public DbSet<TableAttribute> TableAttributes { get; set; } = null!;
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<DocumentSetting> DocumentSettings { get; set; } = null!;
        public DbSet<DocumentFile> DocumentFiles { get; set; } = null!;
        public DbSet<Document> Documents { get; set; } = null!;
        public DbSet<Attribute> Attributes { get; set; } = null!;
        public DbSet<Documents_Table> Documents_Tables { get; set; } = null!;
        public DbSet<Tables_TableAttribute> Tables_TableAttributes { get; set; } = null!;
        public DbSet<Attributes_TableAttribute> Attributes_TableAttributes { get; set; } = null!;
        public DbSet<DocumentSettings_Attribute> DocumentSettings_Attributes { get; set; } = null!;

        public StorageDbContext(DbContextOptions<StorageDbContext> options)
        : base(options)
        {
            //Database.EnsureCreated();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=objStorage.db");
        //}

    }
}
