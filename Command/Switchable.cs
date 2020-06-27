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
}