using Microsoft.Azure.Cosmos;
using System;

namespace CG.Sequences.CosmoDb
{
    /// <summary>
    /// This class represents a CosmoDb client for the Sequence library.
    /// </summary>
    /// <remarks>
    /// The idea, with this class, is to create a concrete client type that is
    /// distinctly registered for use with Sequence CosmoDb repository types. That 
    /// way, we (hopefully) prevent type clashes, in the DI container, that might 
    /// otherwise force us to resort to using factory classes in order to isolate 
    /// our CosmoDb client from anything else that might also be using CosmoDb 
    /// clients types. Ahh, the joys of DI ...
    /// </remarks>
    public class SequenceCosmosClient : CosmosClient
    {
        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="SequenceCosmosClient"/>
        /// class.
        /// </summary>
        /// <param name="connectionString">The connection string to use with 
        /// the client.</param>
        /// <param name="clientOptions">The options to use with the client.</param>
        public SequenceCosmosClient(
            string connectionString, 
            CosmosClientOptions clientOptions = null
            ) : base(
                connectionString,
                clientOptions
                )
        {

        }

        // *******************************************************************

        /// <summary>
        /// This constructor creates a new instance of the <see cref="SequenceCosmosClient"/>
        /// class.
        /// </summary>
        /// <param name="accountEndpoint">The endpoint to use with the client.</param>
        /// <param name="authKeyOrResourceToken">The auth key to use with the 
        /// client.</param>
        /// <param name="clientOptions">The options to use with the client.</param>
        public SequenceCosmosClient(
            string accountEndpoint, 
            string authKeyOrResourceToken, 
            CosmosClientOptions clientOptions = null
            ) : base(
                accountEndpoint,
                authKeyOrResourceToken,
                clientOptions
                )
        {

        }

        #endregion
    }
}
