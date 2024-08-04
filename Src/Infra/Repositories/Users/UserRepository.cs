/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Infrastructure.Repositories.Users;

/// <summary>
/// UserRepository class implement for all user related operations.
/// </summary>
public class UserRepository : BaseDataAccess, IUserRepository
{
    private Func<IDbConnection> Factory { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="factory">A function that returns an instance of <see cref="IDbConnection"/>.</param>
    public UserRepository(Func<IDbConnection> factory)
    {
        this.Factory = factory;
    }

    /// <summary>
    /// Inserts a new user asynchronously.
    /// </summary>
    /// <param name="user">The user to insert.</param>
    /// <returns>A <see cref="DBResponse"/> object representing the result of the insertion.</returns>
    public async Task<DBResponse?> InsertAsync(User user)
    {
        using (var uow = new UnitOfWork(this.Factory))
        {
            SetUserInsertParam(uow, user);
            return await ExecuteReaderWithSaveAsync(uow, ProcedureNames.UserInsert);
        }
    }

    /// <summary>
    /// Sets the parameters for inserting a user into the database.
    /// </summary>
    /// <param name="uow">The unit of work.</param>
    /// <param name="user">The user to be inserted.</param>
    public void SetUserInsertParam(UnitOfWork uow, User user)
    {
        var parameters = uow.DbCommand!.Parameters;
        parameters.Add(AddParameter("@FirstName", user.FirstName, DbType.String));
        parameters.Add(AddParameter("@LastName", user.LastName, DbType.String));
        parameters.Add(AddParameter("@DOB", user.DOB, DbType.DateTime));
        parameters.Add(AddParameter("@Gender", user.Gender, DbType.String));
        parameters.Add(AddParameter("@Result", 0, DbType.Int64, false));
    }

    /// <summary>
    /// Updates a user asynchronously.
    /// </summary>
    /// <param name="user">The user object to update.</param>
    /// <returns>A <see cref="DBResponse"/> object representing the result of the update operation.</returns>
    public async Task<DBResponse?> UpdateAsync(User user)
    {
        using (var uow = new UnitOfWork(this.Factory))
        {
            SetUserUpdateParam(uow, user);
            return await ExecuteReaderWithSaveAsync(uow, ProcedureNames.UserUpdate);
        }
    }

    /// <summary>
    /// Sets the update parameters for a user in the database.
    /// </summary>
    /// <param name="uow">The unit of work.</param>
    /// <param name="user">The user object containing the updated information.</param>
    public void SetUserUpdateParam(UnitOfWork uow, User user)
    {
        var parameters = uow.DbCommand!.Parameters;
        parameters.Add(AddParameter("@FirstName", user.FirstName, DbType.String));
        parameters.Add(AddParameter("@LastName", user.LastName, DbType.String));
        parameters.Add(AddParameter("@DOB", user.DOB, DbType.String));
        parameters.Add(AddParameter("@Gender", user.Gender, DbType.String));
        parameters.Add(AddParameter("@Result", 0, DbType.Int64, false));
    }

    /// <summary>
    /// Get user data by id.
    /// </summary>
    /// <param name="id">id params.</param>
    /// <returns>It will return the IEnumerable.<User></returns>
    public async Task<DBResponse?> GetByIdAsync(long id)
    {
        using (var uow = new UnitOfWork(this.Factory))
        {
            SetGetByIdParam(uow, id);
            return await GetExecuteReaderAsync(uow, ProcedureNames.UserGetById);
        }
    }

    /// <summary>
    /// Sets the parameters for the GetById method in the UserRepository.
    /// </summary>
    /// <param name="uow">The unit of work.</param>
    /// <param name="id">The ID of the user.</param>
    public void SetGetByIdParam(UnitOfWork uow, long id)
    {
        var parameters = uow.DbCommand!.Parameters;
        parameters.Add(AddParameter("@Id", id, DbType.Int64));
        parameters.Add(AddParameter("@Result", 0, DbType.Int16, false));
    }

    /// <summary>
    /// Get All user data.
    /// </summary>
    /// <returns>It will return the IEnumerable.<User> </returns>
    public async Task<DBResponse?> GetAllAsync()
    {
        using (var uow = new UnitOfWork(this.Factory))
        {
            return await GetExecuteReaderAsync(uow, ProcedureNames.UserGetAll);
        }
    }

    /// <summary>
    /// Deletes a user asynchronously from the database.
    /// </summary>
    /// <param name="id">The ID of the user to delete.</param>
    /// <returns>A task representing the asynchronous operation. The task result is a nullable <see cref="DBResponse"/>.</returns>
    public Task<DBResponse?> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }
}