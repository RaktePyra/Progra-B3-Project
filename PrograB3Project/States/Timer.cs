using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrograB3Project.States
{
    public class Timer
    {
        private Action _actionToTrigger;
        private float _triggerTime;
        private float _internalTimer = 0;
        private bool _hasBeenStarted = false;
        public Timer(Action delegate_to_call, float time_in_seconds)
        {
            _actionToTrigger = delegate_to_call;
            _triggerTime = time_in_seconds;
        }
        
        public void Start()
        {
            _hasBeenStarted = true;
        }
        public void Update(float delta_time)
        {
            if (_hasBeenStarted)
            {
                _internalTimer += delta_time;

                if (_internalTimer > _triggerTime)
                {
                    _actionToTrigger();
                }
            }
        }

        public void Stop()
        {
            _hasBeenStarted = false;
            _internalTimer = 0;
        }
    }
}
