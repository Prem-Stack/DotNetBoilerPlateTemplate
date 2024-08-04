/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Infrastructure.StoredProcedure;

/// <summary>
/// Defining Stored Procedure names assigned to Constant which can be used in multiple places.
/// </summary>
public static class ProcedureNames
{
    #region User procedure names.
    public const string UserGetById = "USP_User_GetById";
    public const string UserGetAll = "USP_User_GetAll";
    public const string UserInsert = "USP_User_Insert";
    public const string UserUpdate = "USP_User_Update";
    public const string UserDelete = "USP_User_Delete";
    #endregion
}