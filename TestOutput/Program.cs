using ParallelCompulsory;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        long start = 1000000;
        long end = 2000000;
        List<long> primes = new List<long>();
        var primeGen = new PrimeGenerator();
        Console.WriteLine("Press any key to start sequential");
        Console.ReadKey();
        Console.WriteLine($"Calculating Prime Sequentially from {start} to {end}");
        MeasureTime(() => primes = primeGen.GetPrimesSequential(start, end));
        //PrintPrimes(primes);

        Console.WriteLine("Press any key to start parallel");
        Console.ReadKey();
        MeasureTime(() => primes = primeGen.GetPrimesParallel(start, end));
        //PrintPrimes(primes);
    }

    static void PrintPrimes(List<long> calculatedPrimes)
    {
        Console.WriteLine("Press any key to see primes");
        Console.ReadKey();
        foreach (var item in calculatedPrimes)
        {
            Console.WriteLine(item);
        }
    }

    static void MeasureTime(Action ac)
    {
        Stopwatch sw = Stopwatch.StartNew();
        ac.Invoke();
        sw.Stop();
        Console.WriteLine("Time = {0} seconds", sw.Elapsed.TotalSeconds);
    }

}