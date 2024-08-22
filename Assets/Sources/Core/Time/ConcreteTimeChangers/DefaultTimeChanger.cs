namespace Sources.Core.Time.ConcreteTimeChangers
{
    public class DefaultTimeChanger : ITimeChanger
    {
        public void Start()
        {
            UnityEngine.Time.timeScale = 1;
        }

        public void Stop()
        {
            UnityEngine.Time.timeScale = 0;
        }
    }
}