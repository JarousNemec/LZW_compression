using System.Threading.Channels;
using LZW;

Console.WriteLine("Hello, World!");
var toEncode = "abababababababababababab".ToLower();
var lzwProcessor = new LzwProcessor();
var encoded = lzwProcessor.Encode(toEncode);
var decoded = lzwProcessor.Decode(encoded);

Console.WriteLine(toEncode);
Console.WriteLine(encoded);
Console.WriteLine(decoded);