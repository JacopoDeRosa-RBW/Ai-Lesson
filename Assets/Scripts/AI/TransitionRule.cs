using System.Collections;
using UnityEngine;

namespace AI
{
    public class TransitionRule : ScriptableObject
    {
        public virtual bool Valid(State state)
        {
            return false;
        }
       
    }
}