using System;
using System.Threading;

namespace H2_ProducerConcumer.Lib
{
    public delegate void MessageEvent(string msg);

    public class Manager
    {
        public Manager()
        {
            producerConsumer = new ProducerConsumer();
            producerConsumer.ProducerConsumerInfo += OnProducerConsumerInfo;

            Thread producerThread = new Thread(Producer);
            Thread consumerThread = new Thread(Consumer);
            producerThread.Start();
            consumerThread.Start();
        }

        private static Random rng = new Random();
        private ProducerConsumer producerConsumer;

        public MessageEvent ManagerInfo { get; set; }

        private void OnProducerConsumerInfo(string msg)
        {
            ManagerInfo.Invoke(msg);
        }

        private void Producer()
        {
            while (true)
            {
                int[] numbers = GenerateRandomNumbers();
                producerConsumer.RefillTray(numbers);
                ManagerInfo.Invoke("Producer put " + numbers.Length + " numbers on tray");
                Thread.Sleep(rng.Next(100, 1000));
            }
        }
        private void Consumer()
        {
            while (true)
            {
                for (int i = 0; i < rng.Next(1, 4); i++)
                {
                    ManagerInfo.Invoke("Comsumer got " + producerConsumer.GetNumber() + " from tray");
                }

                Thread.Sleep(rng.Next(100, 1000));
            }
        }

        private int[] GenerateRandomNumbers()
        {
            int[] numbers = new int[rng.Next(1, 4)];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(0, 100);
            }
            return numbers;
        }
    }
}
