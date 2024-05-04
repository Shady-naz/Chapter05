using System.Text;
using BenchmarkDotNet.Attributes;
public class StringBenchmarks
{
    int[] numbers;
    public StringBenchmarks()
    {
        numbers = Enumerable.Range(start: 1, count: 20).ToArray();
    }
    [Benchmark(Baseline=true)]
    public string StringConcatenationTest()
    {
        string s = string.Empty;
        for (int i = 0; i < numbers.Length; i++)
        {
            s += numbers[i] + ", ";
        }
        return s;
    }
    [Benchmark]
    public string StringBuiderTest()
    {
        StringBuilder sb = new();
        for (int i = 0;i < numbers.Length;i++)
        {
            sb.Append(numbers[i]);
            sb.Append(", ");
        }
        return sb.ToString();
    }
}
