
using System.Collections.Generic;
using System.Threading;

namespace H2_ProducerConcumer.Lib
{
    public class ProducerConsumer
    {
        private Queue<int> numberTray = new Queue<int>();

        public MessageEvent ProducerConsumerInfo { get; set; }

        public void RefillTray(int[] numbers)
        {
            lock (numberTray)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    numberTray.Enqueue(numbers[i]);
                }
                Monitor.PulseAll(numberTray);
            }
        }

        public int GetNumber()
        {
            lock (numberTray) 
            {
                while (numberTray.Count == 0)
                {
                    ProducerConsumerInfo.Invoke("Consumer fik ikke lov til at consumere: 0");
                    Monitor.Wait(numberTray);
                }
                return numberTray.Dequeue();
            }
        }
    }
}
