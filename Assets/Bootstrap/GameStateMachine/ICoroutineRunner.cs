using System.Collections;
using UnityEngine;

namespace CoonDev.StateMachine
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}