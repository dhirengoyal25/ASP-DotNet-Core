using AttendanceSystem.Persistent.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceSystem.Persistent.Configurations
{
	public class SqlDbContext : DbContext, IRelationalDbContext
	{
		public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
		
		{ }

		public DbSet<UserAccountEntity> Users { get; set; }
		public DbSet<AttendanceRecordEntity> AttendanceRecords { get; set; }
		public DbSet<EmployeeDetailsEntity> Employees { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Fluent Api way:
			
			//Configure Keys
			modelBuilder.Entity<UserAccountEntity>().HasKey(UserAccountEntity.GetKeys());
			modelBuilder.Entity<AttendanceRecordEntity>().HasKey(AttendanceRecordEntity.GetKeys());
			modelBuilder.Entity<EmployeeDetailsEntity>().HasKey(EmployeeDetailsEntity.GetKeys());

			//modelBuilder.Entity<UserAccountEntity>().ToTable("Users");
			//modelBuilder.Entity<AttendanceRecordEntity>().ToTable("AttendanceReports");
			//modelBuilder.Entity<EmployeeEntity>().ToTable("Employees");
		}
	}
}
