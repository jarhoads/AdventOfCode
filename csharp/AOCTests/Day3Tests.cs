using AOCLib;

namespace AOCTests;

public class Day3Tests
{
    [Fact]
    public void Day3Tests_ConvertToRowData_1()
    {
        var row1 = "467..114..";
        var rowData = Day3Lib.ConvertToRowData(row1, 0);

        var expected = "Row: 0 Numbers: (467, 0, 2),(114, 5, 7) Symbols:";
        Assert.Equal(expected, $"{rowData}".Trim());        
    }

    [Fact]
    public void Day3Tests_ConvertToRowData_2()
    {
        var row = "...*......";
        var rowData = Day3Lib.ConvertToRowData(row, 1);

        var expected = "Row: 1 Numbers:  Symbols: (*, 3)";
        Assert.Equal(expected, $"{rowData}".Trim());        
    }

    [Fact]
    public void Day3Tests_ConvertToRowData_3()
    {
        var row = "..35..633.";
        var rowData = Day3Lib.ConvertToRowData(row, 2);

        var expected = "Row: 2 Numbers: (35, 2, 3),(633, 6, 8) Symbols:";
        Assert.Equal(expected, $"{rowData}".Trim());        
    }

    [Fact]
    public void Day3Tests_ConvertToRowData_4()
    {
        var row = "......#...";
        var rowData = Day3Lib.ConvertToRowData(row, 3);

        var expected = "Row: 3 Numbers:  Symbols: (#, 6)";
        Assert.Equal(expected, $"{rowData}".Trim());        
    }

    [Fact]
    public void Day3Tests_ConvertToRowData_5()
    {
        var row = "617*......";
        var rowData = Day3Lib.ConvertToRowData(row, 4);

        var expected = "Row: 4 Numbers: (617, 0, 2) Symbols: (*, 3)";
        Assert.Equal(expected, $"{rowData}".Trim());        
    }


}