using System;

namespace Sources.Core.Car.Engine
{
    public interface IEngine
    {
        void Start();

        void Stop();
        
        bool IsRunning { get; }

        event Action Changed;
    }
}