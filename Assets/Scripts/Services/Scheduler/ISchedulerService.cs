using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZooWorld.Services
{
    public interface ISchedulerService : IService
    {
        public int Schedule(Action action, float time);

        public void Cancel(int handle);
    }
}
