/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.Infrastructure;

/// <summary>
/// UnitofWorks interface class.
/// </summary>
public interface IUnitOfWork
{
    IDbConnection? DbConnection { get; set; }

    IDbCommand? DbCommand { get; set; }

    IDbTransaction? DbTransaction { get; set; }

    void ConnectionOpen();

    void SaveChanges();

    void Rollback();
}