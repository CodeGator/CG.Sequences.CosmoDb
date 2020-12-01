using CG.Sequences.CosmoDb;
using CG.Sequences.CosmoDb.Repositories;
using CG.Sequences.CosmoDb.Repositories.Options;
using CG.Sequences.Models;
using CG.Sequences.Repositories;
using CG.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IServiceCollection"/>
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        public static IServiceCollection AddCosmoDbRepositories(
            this IServiceCollection serviceCollection,
            IConfiguration configuration
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(serviceCollection, nameof(serviceCollection))
                .ThrowIfNull(configuration, nameof(configuration));

            // Register a factory for CosmoDb client objects.
            serviceCollection.AddScoped<SequenceCosmosClient>(serviceProvider =>
            {
                // Get the repository options.
                var repositoryOptions = serviceProvider.GetRequiredService<
                    IOptions<CosmoDbSequenceRepositoryOptions>
                    >();

                // Create the client.
                var client = new SequenceCosmosClient(
                    repositoryOptions.Value.ConnectionString
                    );

                // Ensure the database exists.
                client.CreateDatabaseIfNotExistsAsync(
                    repositoryOptions.Value.DatabaseId
                    ).Wait();

                // Return the client.
                return client;
            });

            // Register the repositories.
            serviceCollection.AddScoped<
                ISequenceRepository<Sequence, int>, 
                CosmoDbSequenceRepository
                >();

            // Return the service collection.
            return serviceCollection;
        }

        #endregion
    }
}
