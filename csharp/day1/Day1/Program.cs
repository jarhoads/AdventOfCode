using AOCLib;

string textFile = @"C:\dev\AoC2023\csharp\day1\input.txt";
//Test_ConvertToCalibration();
//Test_ConvertToCalibrationWords();
GetResult(textFile);


static void GetResult(string textFile)
{
    var items = InputUtil.ReadTextInput(textFile);

    //var results = items.Select(item => InputUtil.ConvertToCalibration(item)).ToList();
    var results = items.Select(item => InputUtil.ConvertToCalibrationWords(item)).ToList();

    foreach (var result in results)
    {
        Console.WriteLine($"result: {result}");
    }

    var total = results.Sum();
    Console.WriteLine($"total: {total}");
}

static bool Test_ConvertToCalibration()
{
    var t1 = "1abc2";
    var t2 = "pqr3stu8vwx";
    var t3 = "a1b2c3d4e5f";
    var t4 = "treb7uchet";
    
    var t1Result = InputUtil.ConvertToCalibration(t1);
    if (t1Result != 12) { Console.WriteLine($"result is not 12 - result: {t1Result}"); return false; }

    var t2Result = InputUtil.ConvertToCalibration(t2);
    if (t2Result != 38) { Console.WriteLine($"result is not 38 - result: {t2Result}"); return false; }

    var t3Result = InputUtil.ConvertToCalibration(t3);
    if (t3Result != 15) { Console.WriteLine($"result is not 15 - result: {t3Result}"); return false; }

    var t4Result = InputUtil.ConvertToCalibration(t4);
    if (t4Result != 77) { Console.WriteLine($"result is not 77 - result: {t4Result}"); return false; }

    return true;

}

static bool Test_ConvertToCalibrationWords()
{
    var t1 = "two1nine";
    var t2 = "eightwothree";
    var t3 = "abcone2threexyz";
    var t4 = "xtwone3four";
    var t5 = "4nineeightseven2";
    var t6 = "zoneight234";
    var t7 = "7pqrstsixteen";

    var t1Result = InputUtil.ConvertToCalibrationWords(t1);
    if (t1Result != 29) { Console.WriteLine($"result is not 29 - result: {t1Result}"); return false; }
    else { Console.WriteLine($"passed - result: {t1Result}"); }

    var t2Result = InputUtil.ConvertToCalibrationWords(t2);
    if (t2Result != 83) { Console.WriteLine($"result is not 83 - result: {t2Result}"); return false; }
    else { Console.WriteLine($"passed - result: {t2Result}"); }

    var t3Result = InputUtil.ConvertToCalibrationWords(t3);
    if (t3Result != 13) { Console.WriteLine($"result is not 13 - result: {t3Result}"); return false; }
    else { Console.WriteLine($"passed - result: {t3Result}"); }

    var t4Result = InputUtil.ConvertToCalibrationWords(t4);
    if (t4Result != 24) { Console.WriteLine($"result is not 24 - result: {t4Result}"); return false; }
    else { Console.WriteLine($"passed - result: {t4Result}"); }

    var t5Result = InputUtil.ConvertToCalibrationWords(t5);
    if (t5Result != 42) { Console.WriteLine($"result is not 42 - result: {t5Result}"); return false; }
    else { Console.WriteLine($"passed - result: {t5Result}"); }

    var t6Result = InputUtil.ConvertToCalibrationWords(t6);
    if (t6Result != 14) { Console.WriteLine($"result is not 14 - result: {t6Result}"); return false; }
    else { Console.WriteLine($"passed - result: {t6Result}"); }

    var t7Result = InputUtil.ConvertToCalibrationWords(t7);
    if (t7Result != 76) { Console.WriteLine($"result is not 76 - result: {t7Result}"); return false; }
    else { Console.WriteLine($"passed - result: {t7Result}"); }

    return true;

}