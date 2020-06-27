namespace Command
{
    public interface ISwitchable
    {
        /// <summary>
        /// 开动作
        /// </summary>
        void On();

        /// <summary>
        /// 关动作
        /// </summary>
        void Off();
    }

    public interface IDevice : ISwitchable
    {
        /// <summary>
        /// 频道上
        /// </summary>
        void ChannelUp();

        /// <summary>
        /// 频道下
        /// </summary>
        void ChannelDown();

        /// <summary>
        /// 声音上
        /// </summary>
        void VolumeUp();

        /// <summary>
        /// 声音下
        /// </summary>
        void VolumeDown();
    }
}