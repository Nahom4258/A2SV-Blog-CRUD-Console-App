using A2SV___Blog_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace Tests;

public class InMemoryDatabaseTestBase : IDisposable
{
        protected readonly DbContextOptions<A2svBackendLearningContext> _options;

        protected InMemoryDatabaseTestBase()
        {
            _options = new DbContextOptionsBuilder<A2svBackendLearningContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        public void Dispose()
        {
            // Clean up resources if needed
        }
}