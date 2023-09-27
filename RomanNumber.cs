using System;
using System.Collections.Generic;
using System.Linq;

public class RomanNumber
{
    private static readonly Dictionary<char, int> romanToInteger = new()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    private static readonly Dictionary<int, string> integerToRoman = new()
    {
        {1, "I"},
        {4, "IV"},
        {5, "V"},
        {9, "IX"},
        {10, "X"},
        {40, "XL"},
        {50, "L"},
        {90, "XC"},
        {100, "C"},
        {400, "CD"},
        {500, "D"},
        {900, "CM"},
        {1000, "M"}
    };

    private int integerValue;

    public RomanNumber(string roman)
    {
        integerValue = RomanToInteger(roman);
    }

    public RomanNumber(int integer)
    {
        integerValue = integer;
    }

    public override string ToString()
    {
        if (integerValue <= 0 || integerValue > 3999)
        {
            throw new ArgumentOutOfRangeException("integerValue", "Значение должно быть в диапазоне от 1 до 3999");
        }

        string roman = "";

        foreach (var pair in integerToRoman.OrderByDescending(p => p.Key))
        {
            while (integerValue >= pair.Key)
            {
                roman += pair.Value;
                integerValue -= pair.Key;
            }
        }

        return roman;
    }

    public static RomanNumber operator +(RomanNumber roman1, RomanNumber roman2) => new(roman1.integerValue + roman2.integerValue);
    
    public static RomanNumber operator -(RomanNumber roman1, RomanNumber roman2) => new(roman1.integerValue - roman2.integerValue);

    public static RomanNumber operator *(RomanNumber roman1, RomanNumber roman2) => new(roman1.integerValue * roman2.integerValue);
    

    private static int RomanToInteger(string roman)
    {
        int result = 0;
        int prevValue = 0;

        for (int i = roman.Length - 1; i >= 0; i--)
        {
            int currentValue = romanToInteger[roman[i]];

            if (currentValue < prevValue)
            {
                result -= currentValue;
            }
            else
            {
                result += currentValue;
            }

            prevValue = currentValue;
        }

        return result;
    }
}