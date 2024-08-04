/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/

namespace Template.UnitTests.MockData;

/// <summary>
/// BaseUnitTest class base for unit tests.
/// </summary>
public class BaseUnitTest
{
    public Mock<IDbConnection> moqConnection;

    /// <summary>
    /// Sets up a mock database connection with predefined behavior and properties.
    /// </summary>
    public void MockDataBaseDbConnection()
    {
        moqConnection = new Mock<IDbConnection>(MockBehavior.Default);
        moqConnection.Setup(x => x.Open());
        moqConnection.Setup(x => x.ConnectionTimeout).Returns(30);
        moqConnection.Setup(x => x.Database).Returns(ConstantTest.TestData);
        moqConnection.Setup(x => x.Dispose());
        moqConnection.Setup(x => x.BeginTransaction()).Returns(new Mock<DbTransaction>().Object);
        moqConnection.Setup(x => x.Close());
        moqConnection.Setup(d => d.State).Returns(ConnectionState.Open);
    }

    /// <summary>
    /// Returns a mock object of type <see cref="IMediator"/>.
    /// </summary>
    /// <returns>A mock object of type <see cref="IMediator"/>.</returns>
    public static Mock<IMediator> GetMediatorMock()
    {
        return new Mock<IMediator>();
    }

    /// <summary>
    /// Sets up a mock database command to execute a query and return a data reader with the specified data.
    /// </summary>
    /// <typeparam name="T">The type of data to be returned by the data reader.</typeparam>
    /// <param name="data">The data to be returned by the data reader.</param>
    public void MockDataBaseExecuteReader<T>(T data)
    {
        // Define the data reader, that return only one record.
        var moqDataReader = new Mock<IDataReader>();
        moqDataReader.SetupSequence(x => x.Read()).Returns(true);
        string readerData = JsonConvert.SerializeObject(data).ToString();

        moqDataReader.Setup(m => m.GetName(0)).Returns(ConstantTest.TestData); // the first column name
        moqDataReader.Setup(m => m.GetFieldType(0)).Returns(typeof(string)); // the data type of the first column
        moqDataReader.Setup(m => m.GetValue(0)).Returns(readerData);

        // Define the command to be mock and use the data reader
        var commandMock = new Mock<IDbCommand>();

        // Because the SQL to mock has parameter we need to mock the parameter
        commandMock.Setup(m => m.Parameters.Add(It.IsAny<IDbDataParameter>())).Verifiable();
        commandMock.Setup(m => m.ExecuteReader()).Returns(moqDataReader.Object);

        // Now the mock if IDbConnection configure the command to be used
        this.moqConnection.Setup(m => m.CreateCommand()).Returns(commandMock.Object);
    }

    /// <summary>
    /// Sets up a mock database command to execute a non-query operation.
    /// </summary>
    public void MockDataBaseExecuteNonQuery()
    {
        // Configure the mock of the command to be used
        var commandMock = new Mock<IDbCommand>(MockBehavior.Loose);
        commandMock.Setup(c => c.ExecuteNonQuery()).Returns(1);

        // Use sequence when several parameters are needed
        commandMock.SetupSequence(m => m.Parameters.Add(It.IsAny<IDbDataParameter>()));

        // Setup the IdbConnection Mock with the mocked command
        this.moqConnection.Setup(m => m.CreateCommand()).Returns(commandMock.Object);
    }
}