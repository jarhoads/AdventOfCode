using AOCLib;

namespace AOCTests;

public class UnitTest1
{
    [Fact]
    public void AOCLibTest_ConvertToRGB_1()
    {
        var game = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        var result = InputUtil.ConvertToRGB(game);

        Assert.Equal(4, result[0][InputUtil.GameRed]);
        Assert.Equal(0, result[0][InputUtil.GameGreen]);
        Assert.Equal(3, result[0][InputUtil.GameBlue]);

        Assert.Equal(1, result[1][InputUtil.GameRed]);
        Assert.Equal(2, result[1][InputUtil.GameGreen]);
        Assert.Equal(6, result[1][InputUtil.GameBlue]);

        Assert.Equal(0, result[2][InputUtil.GameRed]);
        Assert.Equal(2, result[2][InputUtil.GameGreen]);
        Assert.Equal(0, result[2][InputUtil.GameBlue]);

    }

    [Fact]
    public void AOCLibTest_ConvertToRGB_2()
    {
        var game = "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";
        var result = InputUtil.ConvertToRGB(game);

        Assert.Equal(0, result[0][InputUtil.GameRed]);
        Assert.Equal(2, result[0][InputUtil.GameGreen]);
        Assert.Equal(1, result[0][InputUtil.GameBlue]);

        Assert.Equal(1, result[1][InputUtil.GameRed]);
        Assert.Equal(3, result[1][InputUtil.GameGreen]);
        Assert.Equal(4, result[1][InputUtil.GameBlue]);

        Assert.Equal(0, result[2][InputUtil.GameRed]);
        Assert.Equal(1, result[2][InputUtil.GameGreen]);
        Assert.Equal(1, result[2][InputUtil.GameBlue]);

    }

    [Fact]
    public void AOCLibTest_ValidGame_1()
    {
        var game = "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";
        var result = InputUtil.ValidGame(game, 12, 13, 14);

        Assert.True(result);
    }

    [Fact]
    public void AOCLibTest_ValidGame_2()
    {
        var game = "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
        var result = InputUtil.ValidGame(game, 12, 13, 14);

        Assert.False(result);
    }

    [Fact]
    public void AOCLibTest_ValidGame_3()
    {
        var game = "Game 2: 15 green, 20 red, 8 blue; 12 green, 7 red; 10 green, 2 blue, 15 red; 13 blue, 15 red";
        var result = InputUtil.ValidGame(game, 12, 13, 14);

        Assert.False(result);
    }

    [Fact]
    public void AOCLibTest_MaxGame_1()
    {
        var game = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
        var result = InputUtil.MaxGame(game);

        Assert.Equal(4, result[InputUtil.GameRed]);
        Assert.Equal(2, result[InputUtil.GameGreen]);
        Assert.Equal(6, result[InputUtil.GameBlue]);
    }

    [Fact]
    public void AOCLibTest_MaxGame_2()
    {
        var game = "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue";
        var result = InputUtil.MaxGame(game);

        Assert.Equal(1, result[InputUtil.GameRed]);
        Assert.Equal(3, result[InputUtil.GameGreen]);
        Assert.Equal(4, result[InputUtil.GameBlue]);
    }

    [Fact]
    public void AOCLibTest_MaxGame_3()
    {
        var game = "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red";
        var result = InputUtil.MaxGame(game);

        Assert.Equal(20, result[InputUtil.GameRed]);
        Assert.Equal(13, result[InputUtil.GameGreen]);
        Assert.Equal(6, result[InputUtil.GameBlue]);
    }

    [Fact]
    public void AOCLibTest_GamePower_1()
    {
        int[] game = [4, 2, 6];
        var power = InputUtil.GamePower(game);

        Assert.Equal(48, power);
    }

    [Fact]
    public void AOCLibTest_GamePower_2()
    {
        int[] game = [1, 3, 4];
        var power = InputUtil.GamePower(game);

        Assert.Equal(12, power);
    }

    [Fact]
    public void AOCLibTest_GamePower_3()
    {
        int[] game = [20, 13, 6];
        var power = InputUtil.GamePower(game);

        Assert.Equal(1560, power);
    }
}