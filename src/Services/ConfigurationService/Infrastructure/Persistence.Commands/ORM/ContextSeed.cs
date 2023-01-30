

namespace Persistence.Commands.ORM
{
    public static class ContextSeed
    {
        public static async Task SeedContextAsync(AppDBContext configContext)
        {
            //if (!configContext.DocumentConfigurations.Any())
            //{
            //    configContext.DocumentConfigurations.AddRange(GetPreconfiguredDocConfiguration());
            //    await configContext.SaveChangesAsync();
            //}
        }

        //private static IEnumerable<DocumentConfiguration> GetPreconfiguredDocConfiguration()
        //{
        //    return new List<DocumentConfiguration>
        //    {
        //        new DocumentConfiguration() {
        //             CreatedBy = "Application",
        //             Name = "Startup"
        //        }
        //    };
        //}
    }
}
