namespace Command
{
    public class Controller
    {
        // 开关命令对象
        private ICommand _switchCommand;
        // 频道命令对象
        private ICommand _channleCommand;
        // 音量命令对象
        private ICommand _volumeCommand;
        
        /*绑定函数*/
        
        /// <summary>
        /// 绑定开关命令对象
        /// </summary>
        /// <param name="command"></param>
        public void BindSwitchCommand(SwitchCommand command)
        {
            _switchCommand = command;
        }

        /// <summary>
        /// 绑定开关命令对象
        /// </summary>
        /// <param name="command"></param>
        public void BindChannleCommand(ChannleCommand command)
        {
            _channleCommand = command;
        }

        /// <summary>
        /// 音量命令对象
        /// </summary>
        /// <param name="command"></param>
        public void BindVolumeCommnad(VolumeCommand command)
        {
            _volumeCommand = command;
        }
        
        /*执行命令*/

        public void SwitchCommandExe()
        {
            _switchCommand.Exe();
        }

        public void SwitchCommandUnExe()
        {
            _switchCommand.UnExe();
        }

        public void ChannleCommnadExe()
        {
            _channleCommand.Exe();
        }

        public void ChannleCommnadUnExe()
        {
            _channleCommand.UnExe();
        }

        public void VolumeCommandExe()
        {
            _volumeCommand.Exe();
        }

        public void VolumeCommandUnExe()
        {
            _volumeCommand.UnExe();
        }
    }
}