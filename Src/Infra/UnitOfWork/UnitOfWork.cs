/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Infrastructure;

/// <summary>
/// Unit of Work is like a DB transaction. This will merge all CRUD transactions of Repositories into a single transaction. All changes will be committed only once.
/// </summary>
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private Func<IDbConnection> Factory { get; }

    public IDbConnection? DbConnection { get; set; }

    public IDbCommand? DbCommand { get; set; }

    public IDbTransaction? DbTransaction { get; set; }

    /// <summary>
    /// Initializes a new instance of the UnitOfWorks class with the specified factory.
    /// </summary>
    /// <param name="factory">A function that returns an IDbConnection.</param>
    public UnitOfWork(Func<IDbConnection> factory)
    {
        this.Factory = factory;
        RetryHelper.RetryAndCircuitBreakerPolicy(() =>
        {
            ConnectionOpen();
        });
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases the resources used by the unit of work.
    /// </summary>
    /// <param name="disposing">A boolean value indicating whether the method is being called from the Dispose method or the finalizer.</param>
    public virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Checking Connection is not null
            if (DbConnection == null)
            {
                return;
            }

            DbCommand?.Dispose();
            DbConnection?.Close();
            DbConnection?.Dispose();
            DbTransaction?.Dispose();
        }
    }

    /// <summary>
    /// Method which open DB connection.
    /// </summary>
    public void ConnectionOpen()
    {
        DbConnection = this.Factory.Invoke();

        // Checking Connection is not null and Connection Current State is Closed
        if (DbConnection != null && DbConnection.State == ConnectionState.Closed)
        {
            DbConnection.Open();
        }

        DbCommand = DbConnection!.CreateCommand();
        DbTransaction = DbConnection!.BeginTransaction();
        DbCommand.Transaction = DbTransaction;
    }

    /// <summary>
    /// Method which save database changes.
    /// </summary>
    public void SaveChanges()
    {
        DbTransaction!.Commit();
        DbTransaction?.Dispose();
    }

    /// <summary>
    /// Method which rollback database changes.
    /// </summary>
    public void Rollback()
    {
        DbTransaction!.Rollback();
        DbTransaction?.Dispose();
    }
}