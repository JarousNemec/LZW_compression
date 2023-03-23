using System.Xml;

namespace LZW;

public class LzwProcessor
{
    private Dictionary<int, string> _dictionary = new();
    private Dictionary<string, int> _reverseDictionary = new();

    private void InitializeDictionary()
    {
        _dictionary.Clear();
        _reverseDictionary.Clear();
        for (int i = 'a'; i <= 'z'; i++)
        {
            AddToDic(((char)i).ToString());
        }
    }

    private void AddToDic(string value)
    {
        if (_reverseDictionary.ContainsKey(value)) return;
        _dictionary.Add(_dictionary.Count, value);
        _reverseDictionary.Add(value, _reverseDictionary.Count);
    }

    public string Encode(string input)
    {
        InitializeDictionary();
        string output = string.Empty;

        for (int i = 0; i < input.Length; i++)
        {
            if (output != string.Empty)
            {
                output += ";";
            }

            var known = GetBiggestKnownString(input, i, input.Length, out int nextIndex);
            i = nextIndex;
            output += _reverseDictionary[known];
        }

        return output;
    }


    private string GetBiggestKnownString(string input, int i, int maxIndex, out int nextIndex)
    {
        string temp = String.Empty;
        string output = input[i].ToString();
        if (i == maxIndex - 1)
        {
            nextIndex = i;
            return output;
        }

        temp = input[i + 1].ToString();

        while (true)
        {
            if (_dictionary.ContainsValue(output + temp))
            {
                output += temp;
                i++;
                if (i == maxIndex)
                {
                    nextIndex = i;
                    return output;
                }

                temp = input[i].ToString();
            }
            else
            {
                AddToDic(output + temp);
                nextIndex = i;
                return output;
            }
        }
    }

    public string Decode(string input)
    {
        InitializeDictionary();
        var output = string.Empty;
        var actual = string.Empty;
        var last = string.Empty;
        var keys = input.Split(';');
        foreach (var t in keys)
        {
            checkAgain:
            actual = t;
            if (_dictionary.ContainsKey(Convert.ToInt32(actual)))
            {
                output += _dictionary[Convert.ToInt32(actual)];
                if (last != string.Empty)
                {
                    AddToDic(last + _dictionary[Convert.ToInt32(actual)][0]);
                }
            }
            else
            {
                if (last != string.Empty)
                {
                    AddToDic(last + last[0]);
                    goto checkAgain;
                }
            }

            last = _dictionary[Convert.ToInt32(actual)];
        }

        return output;
    }
}