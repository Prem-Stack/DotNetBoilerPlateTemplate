/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Application.Wrappers;

/// <summary>
///  Generic resonse model.
/// </summary>
/// <typeparam name="T">Generic Response model.</typeparam>
public interface IResponseData<T>
    where T : class
{
    T? Deserialize(string? successModel = null);

    List<T>? DeserializeListJson(string? successModel);

    ResponseMessage ActionUpdateResponse(DBResponse response);

    ResponseMessage ActionDeleteResponse(DBResponse response);

    T? ActionResponse(DBResponse response);
}
