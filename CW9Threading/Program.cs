/*
 *  Name: Jackson Horton
 *  CW 9
 *  This Main uses the user input to manage all the threads and thread objects and accumulates
 *  the results to estimate the value of pi.
 */
using CW9Threading;
using System.Threading;

public class Program
{
    public static void Main(string[] args)
    {
        // get user input
        Console.Write("Enter number of darts to throw per thread and the number of threads to run (space separated): ");
        string[] input = Console.ReadLine().Split();
        int numDartsPerThread = int.Parse(input[0]);
        int numThreads = int.Parse(input[1]);

        // make lists for storing threads
        List<Thread> threads = new();
        List<FindPiThread> findPiThreads = new();


        // creates timer, increments every second
        var watch = System.Diagnostics.Stopwatch.StartNew();

        // loop 1: set up and start threads
        for (int i = 0; i < numThreads; i++)
        {
            FindPiThread piThread = new(numDartsPerThread);
            findPiThreads.Add(piThread);

            Thread t = new Thread(new ThreadStart(piThread.throwDarts));
            threads.Add(t);

            t.Start();
            Thread.Sleep(16);
        }


        // Loop 2: join all threads, waits for completion
        foreach (var item in threads) { 
            item.Join();
        }


        int numInside = 0;
        // Loop 3: once all threads are complete, tally the num of darts that landed inside
        foreach (var resultThread in findPiThreads)
        {
            numInside += resultThread.GetDartsInside();
        }
        

        // Output Results
        Console.WriteLine("Number of darts inside: " + numInside);
        Console.WriteLine("Number of darts thrown: " + (numDartsPerThread * numThreads));

        double piEstimate = 4 * (double) numInside / (numDartsPerThread * numThreads);
        Console.WriteLine("Pi esitmate: " + piEstimate);

        Console.WriteLine("Time taken: " + watch.ElapsedMilliseconds/1000d);

        Console.ReadKey();

    }
}