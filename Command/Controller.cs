using System.Collections.Generic;
using System.Runtime.CompilerServices;

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

    /// <summary>
    /// 撤销重做控制器
    /// </summary>
    public class Commander
    {
        private List<ICommand> _commands = new List<ICommand>();
        private int currentCommandIndex = -1;

        public void AddCommand(ICommand command)
        {
            command.Exe();
            _commands.Add(command);

            ++currentCommandIndex;
        }

        public void Do()
        {
            // 重做命令处于顶部
            if (currentCommandIndex == _commands.Count - 1)
                return;

            ++currentCommandIndex;
            _commands[currentCommandIndex].Exe();
        }

        public void UnDo()
        {
            if (currentCommandIndex < 0)
                return;
                

            _commands[currentCommandIndex].UnExe();
            --currentCommandIndex;
        }
    }
}