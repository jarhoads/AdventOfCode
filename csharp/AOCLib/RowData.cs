namespace AOCLib;

public class RowData(List<RowNumber> numbers, List<RowSymbol> symbols)
{
    public int Id { get; set; }
    public List<RowNumber> Numbers { get; set; } = numbers;
    public List<RowSymbol> Symbols { get; set; } = symbols;

    public override string ToString()
    {
        return $"Row: {Id} Numbers: {String.Join(",", Numbers)} Symbols: {String.Join(",", Symbols)}";
    }
}

public class RowNumber
{
    public int Number { get; set; }
    public int Begin { get; set; }
    public int End { get; set; }

    public override string ToString()
    {
        return $"({Number}, {Begin}, {End})";
    }
}

public class RowSymbol(string symbol, List<RowNumber> adjacents)
{
    public string Symbol { get; set; } = symbol;
    public int Location { get; set; }
    public List<RowNumber> Adjacents { get; set; } = adjacents;

    public override string ToString()
    {
        return $"({Symbol}, {Location}, Adjecents: {String.Join(",", Adjacents)})";
    }
}