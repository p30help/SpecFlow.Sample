using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using WepApp.Domain.Contracts;
using WepApp.Infra;
using WepApp.Infra.Repos;
using WepApp.Tests.Stubs;

namespace WepApp.Tests
{
    public class TestWebApplication : WebApplicationFactory<Program>
    {
        public MainContext DbContext { get; private set; }

        public IConfiguration Configuration { get; }

        public GenderizeServiceStub GenderizeService { get; private set; }

        public TestWebApplication(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseConfiguration(Configuration);

            builder.ConfigureServices(services =>
            {
                //////
                RemoveService(services, typeof(IGenderizeService));
                var genderizeService = new GenderizeServiceStub();
                services.AddTransient<IGenderizeService>(x => genderizeService);
                GenderizeService = genderizeService;

                #region Setup Database

                RemoveService(services, typeof(DbContextOptions<MainContext>));

                var loggerFactory = new LoggerFactory();
                loggerFactory.AddProvider(new DebugLoggerProvider());

                var connection = new SqliteConnection("DataSource=:memory:");

                var options = new DbContextOptionsBuilder<MainContext>()
                    .UseLoggerFactory(loggerFactory)
                    .UseSqlite(connection)
                    .EnableSensitiveDataLogging(true).Options;

                #region Create Temp Db

                connection.Open();

                using (var context = new MainContext(options))
                {
                    context.Database.EnsureCreated();
                }

                #endregion

                DbContext = new MainContext(options);

                services.AddSingleton(x => DbContext);

                // We can instead of register as singleton register as scope
                //services.AddDbContext<MainContext>(options =>
                //{
                //    //options.UseSqlite("DataSource=:memory:");
                //
                //    //options.UseInMemoryDatabase("InMemoryDbForTesting");
                //});

                #endregion
            });
        }

        private void RemoveService(IServiceCollection services, System.Type type)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == type);

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }
        }
    }
}
