namespace Shows.Tests;

public class UnitTest1
{
    [Fact] 
    public void Test1()
    {
        //throw new OutOfMemoryException();
    }

    [Fact]
    public void AddingIntegersOf10And20Gives30()
    {
        int a = 10, b = 20, answer;
        answer = a + b;

        Assert.Equal(30, answer);
    }

    // You can't test everything. Ever. Tests aren't free, and they don't 
    // guarantee anything, really. 

    [Theory]
    [InlineData(10,20,30)]
    [InlineData(20,30,50)]
    [InlineData(2,2,4)]
    public void AddingSomeIntegers(int a, int b, int expected)
    {
        var answer = a + b;
        Assert.Equal(expected, answer);
    }
}
