using System;

namespace Command
{

    class Bulb : ISwitchable
    {
        public void On()
        {
            Console.WriteLine("通电，亮灯");
        }

        public void Off()
        {
            Console.WriteLine("断电，关灯");
        }
    }

    class Fan : ISwitchable
    {
        public void On()
        {
            Console.WriteLine("通电，开风扇");
        }

        public void Off()
        {
            Console.WriteLine("断电，关风扇");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Bulb bulb = new Bulb();
            bulb.On();
            bulb.Off();
            Fan fan = new Fan();
            fan.On();
            fan.Off();
        }
    }
}