/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.Infrastructure;

/// <summary>
/// Defining DB access methods using unit of works.
/// </summary>
public abstract class BaseDataAccess
{
    private DBResponse? _response;

    /// <summary>
    /// Get OutPut Parameter value.
    /// </summary>
    /// <param name="dataParams">Request Parameter Collection.</param>
    /// <returns>Return output param value.</returns>
    public virtual long? GetOutPutParameterName(IDataParameterCollection dataParams)
    {
        long? result = 0;
        var outParam = (SqlParameter)dataParams["@Result"];
        if (outParam != null)
        {
            result = outParam.Value is DBNull ? default(long?) : Convert.ToInt64(outParam.Value);
        }

        return result;
    }

    /// <summary>
    /// Execute Async for Insert, Update and Delete.
    /// </summary>
    /// <param name="uow">Request Unit Of Works.</param>
    /// <param name="procedureName">Request procedure name.</param>
    /// <returns>Only Return result value from DB.</returns>
    public async Task<DBResponse> ExecuteAsync(UnitOfWork uow, string procedureName)
    {
        _response = new DBResponse();
        uow.DbCommand!.CommandText = procedureName;
        uow.DbCommand.CommandType = CommandType.StoredProcedure;
        uow.DbCommand.ExecuteNonQuery();
        uow.SaveChanges();
        _response.Id = GetOutPutParameterName(uow.DbCommand!.Parameters);
        return await Task.FromResult(_response);
    }

    /// <summary>
    /// Execute Reader With Save Async.
    /// </summary>
    /// <param name="uow">Request Unit Of Works</param>
    /// <param name="procedureName">Request procedure name.</param>
    /// <returns>Return response from DB.</returns>
    public async Task<DBResponse> ExecuteReaderWithSaveAsync(UnitOfWork uow, string procedureName)
    {
        string jsonResult = string.Empty;
        _response = new DBResponse();

        uow.DbCommand!.CommandText = procedureName;
        uow.DbCommand.CommandType = CommandType.StoredProcedure;
        using (var reader = uow.DbCommand.ExecuteReader())
        {
            jsonResult = GetJsonData(reader);
        }

        _response.Id = GetOutPutParameterName(uow.DbCommand!.Parameters);
        if (_response.Id == (int)ExceptionCode.DBValidationError || _response.Id == (int)ExceptionCode.DBException)
        {
            _response.Errors = jsonResult.ToString();
        }
        else
        {
            _response.Data = jsonResult.ToString();
            uow.SaveChanges();
        }

        return await Task.FromResult(_response);
    }

    /// <summary>
    /// Get Execute Reader Async.
    /// </summary>
    /// <param name="uow">Request Unit Of Works</param>
    /// <param name="procedureName">Request procedure name.</param>
    /// <returns>Return response from DB.</returns>
    public async Task<DBResponse> GetExecuteReaderAsync(UnitOfWork uow, string procedureName)
    {
        string jsonResult = string.Empty;
        _response = new DBResponse();
        uow.DbCommand!.CommandText = procedureName;
        uow.DbCommand.CommandType = CommandType.StoredProcedure;
        using (var reader = uow.DbCommand.ExecuteReader())
        {
            jsonResult = GetJsonData(reader);
        }

        _response.Id = GetOutPutParameterName(uow.DbCommand!.Parameters);
        _response.Data = jsonResult;
        return await Task.FromResult(_response);
    }

    /// <summary>
    /// Get Execute Scalar Async.
    /// </summary>
    /// <param name="uow">Request Unit Of Works.</param>
    /// <param name="procedureName">Request procedure name.</param>
    /// <returns>Return response from DB.</returns>
    public async Task<DBResponse> GetExecuteScalarAsync(UnitOfWork uow, string procedureName)
    {
        _response = new DBResponse();
        uow.DbCommand!.CommandText = procedureName;
        uow.DbCommand.CommandType = CommandType.StoredProcedure;
        string jsonResult = Convert.ToString(uow!.DbCommand?.ExecuteScalar()) !;
        _response.Id = GetOutPutParameterName(uow.DbCommand!.Parameters);
        _response.Data = jsonResult;
        return await Task.FromResult(_response);
    }

    /// <summary>
    /// Get Json data from data reader.
    /// </summary>
    /// <param name="dataReader">Request data reader.</param>
    /// <returns>Json string.</returns>
    private static string GetJsonData(IDataReader dataReader)
    {
        var jsonResult = new StringBuilder();
        if (dataReader is null)
        {
            jsonResult.Append("[]");
        }
        else
        {
            while (dataReader.Read())
            {
                jsonResult.Append(dataReader.GetValue(0).ToString());
            }
        }

        return jsonResult.ToString();
    }

    /// <summary>
    /// Add a parameter to the command.
    /// </summary>
    /// <typeparam name="T">The type of the parameter value.</typeparam>
    /// <param name="paramName">The name of the parameter.</param>
    /// <param name="paramValue">The value of the parameter.</param>
    /// <param name="dbType">The DbType of the parameter.</param>
    /// <param name="isInput">Indicates whether the parameter is an input parameter.</param>
    /// <param name="isSqlDbType">Indicates whether the parameter is a SqlDbType parameter.</param>
    /// <param name="sqlDbType">The SqlDbType of the parameter.</param>
    /// <returns>The created SqlParameter.</returns>
    public SqlParameter AddParameter<T>(string paramName, T paramValue, DbType dbType = DbType.String, bool isInput = true, bool isSqlDbType = false, SqlDbType sqlDbType = SqlDbType.Structured)
    {
        var param = new SqlParameter();
        param.ParameterName = paramName;
        param.Direction = isInput ? ParameterDirection.Input : ParameterDirection.Output;

        // If Parameter is not Sql Db Type.
        if (!isSqlDbType)
        {
            param.DbType = dbType;

            // Assigning Parameter Value.
            param.Value = !string.IsNullOrEmpty(Convert.ToString(paramValue)) ? paramValue : DBNull.Value;
        }

        // If Parameter is Sql Db Type
        else
        {
            param.SqlDbType = sqlDbType;
            param.Value = paramValue;
        }

        return param;
    }

    /// <summary>
    /// Convert model to data table for UDT table.
    /// </summary>
    /// <typeparam name="T">Generic model list.</typeparam>
    /// <param name="data">Request model data.</param>
    /// <returns>Return data table.</returns>
    public static DataTable ConvertToDataTable<T>(IList<T> data)
    {
        var dataTable = new DataTable(typeof(T).Name);

        // Get all the properties of the model type.
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        // Add columns to the DataTable with custom column names.
        foreach (var property in properties)
        {
            var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
            var propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
            if (columnAttribute != null)
            {
                dataTable.Columns.Add(columnAttribute.Name, propertyType);
            }
        }

        // Add data rows to the DataTable.
        foreach (var item in data)
        {
            var row = dataTable.NewRow();
            foreach (var property in properties)
            {
                var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
                if (columnAttribute != null)
                {
                    row[columnAttribute.Name!] = property.GetValue(item) ?? DBNull.Value;
                }
            }

            dataTable.Rows.Add(row);
        }

        return dataTable;
    }
}
