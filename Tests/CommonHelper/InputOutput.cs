/*
This computer program, as defined in the Copyright, Designs and Patents Act 1998 and the Software Directive (2009/24/EC),
is the copyright of Logic Valley Ltd, a wholly owned subsidiary of Marston (Holdings) Ltd. All rights are reserved.
*/
namespace Template.UnitTests.CommonHelper;

/// <summary>
/// The generic Input and output model.
/// </summary>
/// <typeparam name="T1">input Json data.</typeparam>
/// <typeparam name="T2">output json data.</typeparam>
internal class InputOutput<T1, T2>
{
    public T1? Data { get; set; }

    public T2? Result { get; set; }
}