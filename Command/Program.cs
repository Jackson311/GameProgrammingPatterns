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

    class TV : IDevice
    {
        public void On()
        {
            Console.WriteLine("通电，电视");
        }

        public void Off()
        {
            Console.WriteLine("断电，电视");
        }

        public void ChannelUp()
        {
            Console.WriteLine("电视频道，切换上");
        }

        public void ChannelDown()
        {
            Console.WriteLine("电视频道，切换下");
        }

        public void VolumeUp()
        {
            Console.WriteLine("电视音量，上");
        }

        public void VolumeDown()
        {
            Console.WriteLine("电视音量，下");
        }
    }

    class Radio : IDevice
    {
        public void On()
        {
            Console.WriteLine("通电，收音机");
        }

        public void Off()
        {
            Console.WriteLine("断电，收音机");
        }

        public void ChannelUp()
        {
            Console.WriteLine("收音机频道，切换上");
        }

        public void ChannelDown()
        {
            Console.WriteLine("收音机频道，切换下");
        }

        public void VolumeUp()
        {
            Console.WriteLine("收音机音量，上");
        }

        public void VolumeDown()
        {
            Console.WriteLine("收音机音量，下");
        }
    }
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*
             * 现在是客户端-命令-控制器
             * 现在是控制器和客户端分开了，控制器不需要知道是什么客户端是TV还是radio
             * 只要命令里有去实现客户端的就行，而且你可以实现非常多不同的命令，同时还支持撤回等操作
             */
            
            TV tv = new TV();
            Radio radio = new Radio();
            Controller controller = new Controller();
            
            controller.BindSwitchCommand(new SwitchCommand(radio));
            controller.BindChannleCommand(new ChannleCommand(radio));
            controller.BindVolumeCommnad(new VolumeCommand(radio));
            
            controller.SwitchCommandExe();
            controller.SwitchCommandUnExe();
            controller.ChannleCommnadExe();
            controller.ChannleCommnadUnExe();
            controller.VolumeCommandExe();
            controller.VolumeCommandUnExe();
            
        }
    }
}