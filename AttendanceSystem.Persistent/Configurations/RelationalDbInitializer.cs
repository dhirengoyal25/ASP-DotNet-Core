using System;
using System.Threading.Tasks;

namespace AttendanceSystem.Persistent.Configurations
{
	public sealed class RelationalDbInitializer
	{
        #region Properties
        private static RelationalDbInitializer _instance;
        public static RelationalDbInitializer Instance => _instance ?? (_instance = new RelationalDbInitializer());
        #endregion

        #region Constructor
        private RelationalDbInitializer() { }
        #endregion

        public async Task InitializeAsync(IRelationalDbContext context)
		{
			await context.Database.EnsureCreatedAsync();

            //await SeedDatabase(context);
		}

		private Task SeedDatabase(IRelationalDbContext context)
		{
			return default;
		}
	}
}
