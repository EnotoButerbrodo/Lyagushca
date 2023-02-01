using System.Collections;
using UnityEngine;

namespace Bootstrap.GameStateMachine
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}