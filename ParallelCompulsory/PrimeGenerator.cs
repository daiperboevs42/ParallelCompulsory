using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelCompulsory
{
    public class PrimeGenerator
    {
        public List<long> GetPrimesSequential(long first, long last)
        {
            List<long> primes = new List<long>();
            for (var number = first; number < last; number++)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
            }
            return primes;
        }

        static bool IsPrime(long number)
        {
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            for (long divisor = 3; divisor < (number / 2); divisor += 2)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }
            return true;
        }


        public List<long> GetPrimesParallel(long first, long last)
        {
            List<long> primes = new List<long>();
            var lockObject = new object();

            var range = last - first;
            var numberOfThreads = (long)Environment.ProcessorCount;

            var threads = new Thread[numberOfThreads];
            var chunkSize = range / numberOfThreads;

            for (long i = 0; i < numberOfThreads; i++)
            {
                var chunkStart = first + i * chunkSize;
                var chunkEnd = (i == (numberOfThreads - 1)) ? last : chunkStart + chunkSize;
                threads[i] = new Thread(() =>
                {
                    for (var number = chunkStart; number < chunkEnd; ++number)
                    {
                        if (IsPrime(number))
                        {
                            lock (lockObject)
                            {
                                primes.Add(number);
                            }
                        }
                    }
                });

                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            return primes;
        }

        static List<long> GeneratePrimes(long start, long end)
        {
            bool isPrime = true;
            List<long> primes = new List<long>();
            for (long i = start; i <= end; i++)
            {
                for (long j = start; j <= end; j++)
                {
                    if (i != j && i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(i);
                }
                isPrime = true;
            }
            return primes;
        }

    }
}
