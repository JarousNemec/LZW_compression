using System.Threading.Channels;
using LZW;

Console.WriteLine("Hello, World!");
var toEncode = "abababab".ToLower();
var lzwProcessor = new LzwProcessor();
var encoded = lzwProcessor.Encode(toEncode);
var decoded = lzwProcessor.Decode(encoded);

Console.WriteLine(toEncode);
Console.WriteLine(encoded);
Console.WriteLine(decoded);

Console.WriteLine("---------------------------------------");

toEncode = "abcdabcdabcdabcdabcdabcdahojahojahojahoj".ToLower();
encoded = lzwProcessor.Encode(toEncode);
decoded = lzwProcessor.Decode(encoded);

Console.WriteLine(toEncode);
Console.WriteLine(encoded);
Console.WriteLine(decoded);