using Xunit;

namespace DataStructures.Tests;

public class ListTest
{
    // Apparently I can't do generics in xunit :sob:
    // Also arrays as inputs apparently don't work because of an error with InlineData expecting a semicolon
    [Theory]
    [InlineData(1, 2, 3)]
    public void AddTest(int value1, int value2, int value3)
    {
        var list = new List<int>();
        list.Add(value1);
        list.Add(value2);
        list.Add(value3);
        
        Assert.Equal(3, list.Count);
        Assert.Equal(list[0], value1);
        Assert.Equal(list[1], value2);
        Assert.Equal(list[2], value3);
    }
}