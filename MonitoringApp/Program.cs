using Packt.Shared;
using System.Text; // Recorder

SectionTitle("Using StringBuilder");
// simulate a process that requires some memory resources...
int[] numbers = Enumerable.Range(
start: 1, count: 50_000).ToArray();

Recorder.Start();
StringBuilder builder = new();
for (int i = 0; i < numbers.Length; i++)
{
    builder.Append(numbers[i]);
    builder.Append(", ");
}
Recorder.Stop();

WriteLine();

SectionTitle("Using string with +");
Recorder.Start();
string s = String.Empty;
for (int i = 0;i < numbers.Length; i++)
{
    s += numbers[i] + ", ";
}
Recorder.Stop();