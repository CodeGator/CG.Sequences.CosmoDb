using CG.Business.Models;
using CG.Linq.CosmoDb.Repositories;
using CG.Sequences.CosmoDb.Repositories.Options;
using CG.Sequences.Models;
using CG.Sequences.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace CG.Sequences.CosmoDb.Repositories
{
    /// <summary>
    /// This class is a CosmoDb implementation of the <see cref="ISequenceRepository{TModel, TKey}"/>
    /// interface.
    /// </summary>
    /// <typeparam name="TModel">The model type associated with the repository.</typeparam>
    /// <typeparam name="TKey">The key type associated with the model.</typeparam>
    public class CosmoDbSequenceRepository<TModel, TKey> : 
        CosmoDbCrudRepositoryBase<IOptions<CosmoDbSequenceRepositoryOptions>, TModel, TKey>,
        ISequenceRepository<TModel, TKey>
        where TModel : Sequence, IModel<TKey>
        where TKey : new()
    {
        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="CosmoDbSequenceRepository"/>
        /// class.
        /// </summary>
        /// <param name="options">The options to use with the repository.</param>
        /// <param name="client">the CosmoDb client to use with the repository.</param>
        public CosmoDbSequenceRepository(
            IOptions<CosmoDbSequenceRepositoryOptions> options,
            CosmosClient client
            ) : base(options, client)
        {

        }

        #endregion
    }
}
