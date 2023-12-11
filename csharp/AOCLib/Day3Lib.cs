namespace AOCLib;

public static class Day3Lib
{
    public static bool IsPartNumber(RowNumber number, List<RowData> rows, int row, bool checkForGear = false)
    {
        var numberCols = Enumerable.Range(number.Begin, $"{number.Number}".Length).ToList();

        // check to see if any symbols are beside the number
        var current = rows[row];
        if (CheckSymbol(current, number, numberCols, checkForGear)) {
            return true; 
        }


        // check to see if any symbols are above or below the number columns
        if (row > 0) { 
            int aboveRow = row-1;
            var above = rows[aboveRow];
            // are there any symbols?
            if (CheckSymbol(above, number, numberCols, checkForGear)) { return true; }
        }

        if (row < (rows.Count-1)) { 
            int belowRow = row+1;
            var below = rows[belowRow];
            if (CheckSymbol(below, number, numberCols, checkForGear)) { return true; }
        }

        return false;        

    }

    public static bool CheckSymbol(RowData row, RowNumber number, List<int> numberCols, bool checkForGear = false)
    {
        var GearSymbol = "*";

        if(row.Symbols.Count > 0)
        {
            foreach (var symbol in row.Symbols)
            {
                if ((symbol.Symbol == GearSymbol && checkForGear) || !checkForGear)
                {

                    var symbolLocation = symbol.Location;
                    // check directly adjacent
                    if (numberCols.Contains(symbolLocation))
                    {
                        symbol.Adjacents.Add(number);
                        return true;
                    }

                    var left = symbolLocation - 1;
                    if (numberCols.Contains(left))
                    {
                        symbol.Adjacents.Add(number);
                        return true;
                    }

                    var right = symbolLocation + 1;
                    if (numberCols.Contains(right))
                    {
                        symbol.Adjacents.Add(number);
                        return true;
                    }
                }

                
            }
        }

        return false;
    } 

    public static RowData ConvertToRowData(string row, int rowNum)
    {
        var numbers = new List<RowNumber>();
        var symbols = new List<RowSymbol>();        
        var data = new RowData(numbers, symbols) { Id = rowNum };
        string currentNum = "";
        int currBegin = 0;
        for (int i = 0; i < row.Length; i++)
        {

            // check for a number
            if (Char.IsDigit(row[i]))
            {
                if (String.IsNullOrEmpty(currentNum)) { currBegin = i; }
                currentNum += row[i];
            }
            else
            {
                // not a digit
                // if it is a symbol, add it to the symbols list
                if (row[i] != '.')
                {
                    var symbol = new RowSymbol($"{row[i]}", new List<RowNumber>()) { Location = i };
                    data.Symbols.Add(symbol);
                }
                
                if (!String.IsNullOrEmpty(currentNum))
                {
                    // there is a number to add to the list
                    var rowNumber = new RowNumber()
                    {
                        Number = InputUtil.ToDigit(currentNum),
                        Begin = currBegin,
                        End = (i > 0) ? (i-1) : 0
                    }; 
                    data.Numbers.Add(rowNumber);                     
                }
                currentNum = "";
            }
        }

        // there is a number to add
        if (!String.IsNullOrEmpty(currentNum)) 
        {
            // there is a number at the end of the line to add to the list
            var rowNumber = new RowNumber()
            {
                Number = InputUtil.ToDigit(currentNum),
                Begin = currBegin,
                End = (row.Length - 1)
            };
            data.Numbers.Add(rowNumber);

        }
        return data;
    }
}