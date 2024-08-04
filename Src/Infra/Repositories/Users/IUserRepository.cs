/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.Infrastructure.Repositories.Users;

/// <summary>
/// IUserRepository interface for all user related operations.
/// </summary>
public interface IUserRepository
{
    Task<DBResponse?> InsertAsync(User user);

    Task<DBResponse?> UpdateAsync(User user);

    Task<DBResponse?> GetByIdAsync(long id);

    Task<DBResponse?> GetAllAsync();

    Task<DBResponse?> DeleteAsync(long id);
}
