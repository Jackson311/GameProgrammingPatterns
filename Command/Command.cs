namespace Command
{
    public interface ICommand
    {
        void Exe();
        void UnExe();
    }

    /*
     * -----将一个请求封装为一个对象------在这里被体现出来
     * 我们将一个个的命令/请求封装为一个对象
     */
    
    
    /// <summary>
    /// 开关命令
    /// </summary>
    public class SwitchCommand : ICommand
    {
        private IDevice _device;

        public SwitchCommand(IDevice device)
        {
            _device = device;
        }

        public void Exe()
        {
            _device.On();
        }

        public void UnExe()
        {
            _device.Off();
        }
    }

    /// <summary>
    /// 频道切换命令
    /// </summary>
    public class ChannleCommand : ICommand
    {
        private IDevice _device;

        public ChannleCommand(IDevice device)
        {
            _device = device;
        }

        public void Exe()
        {
            _device.ChannelUp();
        }

        public void UnExe()
        {
            _device.ChannelDown();
        }
    }

    /// <summary>
    /// 音量控制命令
    /// </summary>
    public class VolumeCommand : ICommand
    {
        private IDevice _device;

        public VolumeCommand(IDevice device)
        {
            _device = device;
        }

        public void Exe()
        {
            _device.VolumeUp();
        }

        public void UnExe()
        {
            _device.VolumeDown();
        }
    }
}