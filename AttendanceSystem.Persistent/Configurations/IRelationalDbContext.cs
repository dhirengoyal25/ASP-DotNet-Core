using AttendanceSystem.Persistent.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace AttendanceSystem.Persistent.Configurations
{
	/// <summary>
	/// Created this contract so that I can use this DBContext contract for all other types of relational database
	/// Same contract and different db implementations.
	/// </summary>
	public interface IRelationalDbContext
	{
		DatabaseFacade Database { get; }

		DbSet<UserAccountEntity> Users { get; set; }

		DbSet<AttendanceRecordEntity> AttendanceRecords { get; set; }

		DbSet<EmployeeDetailsEntity> Employees { get; set; }

		EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		
		int SaveChanges();
		
		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
	}
}
