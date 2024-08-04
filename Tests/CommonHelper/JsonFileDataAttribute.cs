/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.UnitTests.CommonHelper;

/// <summary>
/// JsonFileDataAttribute class for reading JSON file data.
/// </summary>
public class JsonFileDataAttribute : DataAttribute
{
    private readonly string _filePath;
    private readonly string _propertyName;
    private readonly bool _deserialize;
    private readonly Type? _input;
    private readonly Type? _output;

    /// <summary>
    /// Load data from a JSON file as the data source for a theory.
    /// </summary>
    /// <param name="filePath">The absolute or relative path to the JSON file to load.</param>
    public JsonFileDataAttribute(string filePath)
            : this(filePath, null!, false)
            {
            }

    /// <summary>
    /// Load data from a JSON file as the data source for a theory.
    /// </summary>
    /// <param name="filePath">The absolute or relative path to the JSON file to load.</param>
    /// <param name="propertyName">The name of the property on the JSON file that contains the data for the test.</param>
    /// <param name="deserialize">Whether to deserialized objects are used in unit test case method parameters.</param>
    public JsonFileDataAttribute(string filePath, string propertyName = null!, bool deserialize = true)
    {
        _filePath = filePath;
        _propertyName = propertyName;
        _deserialize = deserialize;
    }

    public JsonFileDataAttribute(string filePath, string propertyName = null!, Type? input = null, Type? output = null, bool deserialize = false)
    {
        _filePath = filePath;
        _propertyName = propertyName;
        _input = input;
        _output = output;
        _deserialize = deserialize;
    }

    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        if (testMethod == null)
        {
            throw new ArgumentNullException(nameof(testMethod));
        }

        // Get the absolute path to the JSON file
        string? path = Path.IsPathRooted(_filePath)
            ? _filePath
            : Path.GetRelativePath(Directory.GetCurrentDirectory(), _filePath);
        string startupPath = ApplicationEnvironment.ApplicationBasePath;
        string[]? pathItems = startupPath.Split(Path.DirectorySeparatorChar);
        int pos = pathItems.Reverse().ToList().FindIndex(x => string.Equals("bin", x));
        string projectPath = string.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - pos - 1));
        string url = Path.Combine(projectPath, "Data", _filePath);
        if (!File.Exists(url))
        {
            throw new ArgumentException($"Could not find file at path: {path}");
        }

        // Load the file
        string fileData = File.ReadAllText(url);

        if (string.IsNullOrEmpty(_propertyName))
        {
            // Whole file is the data
            var jsonData = JsonConvert.DeserializeObject<List<object[]>>(fileData);
            return CastParamTypes(jsonData!, testMethod);
        }
        else if (!_deserialize)
        {
            var entityData = JObject.Parse(fileData);
            string? data = entityData[_propertyName]!.ToString();
            return GetData(data);
        }
        else
        {
            // Only use the specified property as the data
            var allData = JObject.Parse(fileData);
            var data = allData[_propertyName];
            var jsonData = data!.ToObject<List<object[]>>();
            return CastParamTypes(jsonData!, testMethod);
        }
    }

    /// <summary>
    /// Cast the objects read from the JSON file to the Type of the method parameters.
    /// </summary>
    /// <param name="jsonData">Array of objects read from the JSON file.</param>
    /// <param name="testMethod">Method Base currently test method.</param>
    private IEnumerable<object[]> CastParamTypes(List<object[]> jsonData, MethodBase testMethod)
    {
        var result = new List<object[]>();

        // Get the parameters of current test method
        var parameters = testMethod.GetParameters();

        // Foreach tuple of parameters in the JSON data
        foreach (var paramsTuple in jsonData)
        {
            var paramValues = new object[parameters.Length];

            // Foreach parameter in the method
            for (int i = 0; i < parameters.Length; i++)
            {
                // Cast the value in the JSON data to match parameter type
                paramValues[i] = CastParamValue(paramsTuple[i], parameters[i].ParameterType);
            }

            result.Add(paramValues);
        }

        return result;
    }

    /// <summary>
    /// Cast an object from JSON data to the type specifed.
    /// </summary>
    /// <param name="value">Value to be casted.</param>
    /// <param name="type">Target type of the cast.</param>
    private object CastParamValue(object value, Type type)
    {
        // Cast objects
        if (value is JObject jObjectValue)
        {
            return jObjectValue.ToObject(type) !;
        }

        // Cast arrays
        else if (value is JArray jArrayValue)
        {
            return jArrayValue.ToObject(type) !;
        }

        // No cast for value types
        return value;
    }

    /// <summary>
    /// Split the property as data and result then return those.
    /// </summary>
    /// <param name="jsonData">jsonData.</param>
    /// <returns>IEnumerable.</returns>
    private IEnumerable<object[]> GetData(string jsonData)
    {
        var objectList = new List<object[]>();
        if (_input is not null && _output is not null)
        {
            var specific = typeof(InputOutput<,>).MakeGenericType(_input, _output);
            var generic = typeof(List<>).MakeGenericType(specific);
            dynamic? datalist = JsonConvert.DeserializeObject(jsonData, generic);
            foreach (dynamic data in datalist!)
            {
                objectList.Add(new object[] { data.Data, data.Result });
            }
        }
        else
        {
            dynamic? datalist = JsonConvert.DeserializeObject(jsonData);
            foreach (dynamic data in datalist!)
            {
                objectList.Add(new object[] { data.Result });
            }
        }

        return objectList;
    }
}