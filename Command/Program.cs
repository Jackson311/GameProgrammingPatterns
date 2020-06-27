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

    class Person
    {
        private int _x;
        private int _y;

        public void Move(int x,int y)
        {
            _x = x;
            _y = y;
            Console.WriteLine("Person Walk x:{0} ,y:{1}",_x,_y);
        }

        public void GetPostion(out int x, out int y)
        {
            x = _x;
            y = _y;
        }
    }

    class JumpPerson
    {
        private int _z;

        public void Jum(int z)
        {
            _z = z;
            Console.WriteLine("Person Jump z:{0}",_z);
        }

        public int Z => _z;
    }
    class MoveCommnad : ICommand
    {
        private Person _person;
        private int _oriX;
        private int _oriY;
        private int _curX;
        private int _curY;

        public MoveCommnad(Person person, int x, int y)
        {
            _person = person;
            _curX = x;
            _curY = y;
            _person.GetPostion(out _oriX,out _oriY);
        }
        
        public void Exe()
        {
            _person.Move(_curX,_curY);
        }

        public void UnExe()
        {
            _person.Move(_oriX,_oriY);
        }
    }

    class JumoCommand : ICommand
    {
        private JumpPerson _jumpPerson;
        private int _oriZ;
        private int _curZ;

        public JumoCommand(JumpPerson jumpPerson,int z)
        {
            _jumpPerson = jumpPerson;
            _curZ = z;
            _oriZ = jumpPerson.Z;
        }

        public void Exe()
        {
            _jumpPerson.Jum(_curZ);
        }

        public void UnExe()
        {
            _jumpPerson.Jum(_oriZ);
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
            
            Person person = new Person();
            JumpPerson jumpPerson = new JumpPerson();

            Commander commander = new Commander();
            commander.AddCommand(new MoveCommnad(person,1,1));
            commander.AddCommand(new JumoCommand(jumpPerson,1));
            commander.AddCommand(new MoveCommnad(person,2,1));
            commander.AddCommand(new JumoCommand(jumpPerson,3));
            commander.AddCommand(new MoveCommnad(person,2,2));
            commander.AddCommand(new JumoCommand(jumpPerson,5));
            commander.AddCommand(new JumoCommand(jumpPerson,6));
            Console.WriteLine("----------撤销");
            commander.UnDo();
            commander.UnDo();
            commander.UnDo();
            commander.UnDo();
            commander.UnDo();
            commander.UnDo();
            commander.UnDo();
            Console.WriteLine("----------恢复");
            commander.Do();
            commander.Do();
            commander.Do();
            commander.Do();
            commander.Do();
            commander.Do();

        }
    }
}