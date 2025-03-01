using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace ZooWorld.Services
{
    public class SchedulerService : ISchedulerService, IFixedTickable
    {
        private readonly Dictionary<int, ScheduledEvent> _scheduledEvents = new ();
        private readonly List<int> _eventsToInvoke = new ();
        private int _currentId;

        public UniTask Initialize(DiContainer container) => UniTask.CompletedTask;

        public int Schedule(Action action, float time)
        {
            ++_currentId;
            _scheduledEvents.Add(_currentId, new ScheduledEvent(_currentId, time, action));
            return _currentId;
        }

        public void Cancel(int handle) => _scheduledEvents.Remove(handle);

        public void FixedTick()
        {
            foreach (var scheduledEvent in _scheduledEvents.Values)
            {
                scheduledEvent.TimeLeft -= Time.fixedDeltaTime;

                if (scheduledEvent.TimeLeft <= 0)
                {
                    // Can't invoke/remove directly while enumerating
                    _eventsToInvoke.Add(scheduledEvent.Id);
                }
            }

            foreach (var handle in _eventsToInvoke)
            {
                _scheduledEvents[handle].Event.Invoke();
                _scheduledEvents.Remove(handle);
            }

            _eventsToInvoke.Clear();
        }
        
        private class ScheduledEvent
        {
            public readonly int Id;
            public readonly Action Event;
            public float TimeLeft;

            public ScheduledEvent(int id, float timeLeft, Action @event)
            {
                Id = id;
                TimeLeft = timeLeft;
                Event = @event;
            }
        }
    }
}
