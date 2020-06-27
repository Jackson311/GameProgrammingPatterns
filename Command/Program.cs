using System;

namespace Command
{
    /// <summary>
    /// 控制器
    /// </summary>
    class Switcher
    {
        private ISwitchable _switchable;

        public Switcher(ISwitchable switchable)
        {
            _switchable = switchable;
        }

        public void OnButton()
        {
            _switchable.On();
        }

        public void OffButton()
        {
            _switchable.Off();
        }
    }

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
            /*
             * 现在是客户端-控制器
             * 控制器获取要控制的客户端，然后进行控制
             */
            Bulb bulb = new Bulb();
            Fan fan = new Fan();
            Switcher switcher_0 = new Switcher(bulb);
            switcher_0.OnButton();
            switcher_0.OffButton();
            Switcher switcher_1 = new Switcher(fan);
            switcher_1.OnButton();
            switcher_1.OffButton();

        }
    }
}