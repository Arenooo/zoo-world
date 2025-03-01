using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ZooWorld.Utility
{
    public static class Extensions
    {
        public static T RandomElement<T>(this IEnumerable<T> container)
        {
            var rand = new System.Random();
            return container.OrderBy(_ => rand.Next()).FirstOrDefault();
        }
    }
}
