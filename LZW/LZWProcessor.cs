namespace LZW;

public class LzwProcessor
{
    private Dictionary<int, string> _dictionary = new ();
    private Dictionary<string, int> _reverseDictionary = new ();

    public LzwProcessor()
    {
        for (int i = 'a'; i < 'z'; i++)
        {
            AddToDic(((char)i).ToString());
        }
        AddToDic("ab");
        AddToDic("ba");
    }

    private void AddToDic(string value)
    {
        _dictionary.Add(_dictionary.Count, value);
        _reverseDictionary.Add(value, _reverseDictionary.Count);
    }
    
    public string Encode(string input)
    {
        string output = string.Empty;
        
        for (int i = 0; i < input.Length; i++)
        {
            char af = input[i];
            // if ()
            // {
            //     
            // }
            
        }
        return output;
    }

    private string GetBiggestKnownString(string input, int i)
    {
        string output = string.Empty;
        do
        {
            output += input[i];
            i++;
        } while (_dictionary.ContainsValue(output) && i < input.Length);
        return output;
    }

    public string Decode(string input)
    {
        string output = string.Empty;

        return output;
    }
}