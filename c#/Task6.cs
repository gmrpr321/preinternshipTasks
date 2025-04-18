using System;

namespace EventDrivenCounter
{

    public delegate void ThresholdReachedEventHandler(object sender, ThresholdReachedEventArgs e);


    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

  
    public class Counter
    {
        private int threshold;
        private int total;


        public event ThresholdReachedEventHandler ThresholdReached;

        public Counter(int threshold)
        {
            this.threshold = threshold;
        }

        public void Add(int x)
        {
            total += x;
            Console.WriteLine($"Current total: {total}");
            if (total >= threshold)
            {
                OnThresholdReached();
            }
        }


        protected virtual void OnThresholdReached()
        {
            ThresholdReached?.Invoke(this, new ThresholdReachedEventArgs()
            {
                Threshold = threshold,
                TimeReached = DateTime.Now
            });
        }
    }

   
    class Program
    {
        static void Main(string[] args)
        {
            Counter counter = new Counter(5);


            counter.ThresholdReached += EmailNotifier;
            counter.ThresholdReached += LogToFile;
            counter.ThresholdReached += DisplayMessage;

            Console.WriteLine("Press any key to increment counter by 1. Press 'q' to quit.");

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.KeyChar == 'q') break;

                counter.Add(1);
            }
        }

        static void EmailNotifier(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"[EmailNotifier] Threshold {e.Threshold} reached at {e.TimeReached}.");
        }

        static void LogToFile(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"[LogToFile] Logging threshold {e.Threshold} to file...");
        }

        static void DisplayMessage(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine($"[DisplayMessage] Alert! Counter has reached {e.Threshold}.");
        }
    }
}
