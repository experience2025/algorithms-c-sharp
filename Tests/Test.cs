using Task;

namespace Tests;

public class Test
{
    [Fact]
    public void TestRabbits()
    {
        Assert.Equal(1,Program.Rabbits(1,2));
        Assert.Equal(1,Program.Rabbits(2,2));
        Assert.Equal(2,Program.Rabbits(3,7));
        Assert.Equal(2,Program.Rabbits(3,8));
        Assert.Equal(3,Program.Rabbits(4,8));
        Assert.Equal(5,Program.Rabbits(5,6));
        Assert.Equal(8,Program.Rabbits(6,8));
        Assert.Equal(13,Program.Rabbits(7,9));
        Assert.Equal(20,Program.Rabbits(8,7));
        Assert.Equal(34,Program.Rabbits(9,9));
        //35,5,504355
        //50,5,155898016
    }

}
