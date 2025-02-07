using System.Diagnostics;
using System.Timers;

class Program
{
    private static System.Timers.Timer _timer;
    private static Stopwatch _stopwatch = new Stopwatch();
    private const int LifetimeSeconds = 10;
    private static readonly CancellationTokenSource _cts = new();
    static string word = "developer";
    static async Task Main()
    {
        // Fisher-Yates algorithm
        string shuffledWord = ShuffleWord();
        Console.WriteLine($"** Try to guess the word \"{shuffledWord}\" **");
    
        _stopwatch.Start();
        Task executionTask = KeepRunning(_cts.Token);

        await Task.Delay(TimeSpan.FromSeconds(LifetimeSeconds));


        Console.WriteLine("\nTime's Up");
        _cts.Cancel();

        await Task.Delay(500);

        Environment.Exit(0);
    }

    private static async Task KeepRunning(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                await GuessWord(token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\nGuessing was canceled.");
                Environment.Exit(0);
            }
        }
    }

    private static async Task GuessWord(CancellationToken token)
    {
        Console.Write("Enter your guess: ");

        string? guessedWord = await Task.Run(() => Console.ReadLine(), token);


        if (guessedWord.Equals(word, StringComparison.CurrentCultureIgnoreCase))
        {
            Console.WriteLine("Your guess is correct!");
            Environment.Exit(0);
        }
        Console.WriteLine("Your guess is incorrect!");
    }

    static string ShuffleWord()
    {
        Random rand = new Random();

        var chars = word.ToCharArray();
        for (int i = chars.Length - 1; i > 0; i--)
        {
            int randomIndex = rand.Next(i + 1);
            (chars[randomIndex], chars[i]) = (chars[i], chars[randomIndex]);
        }
        return new string(chars);
    }
}
