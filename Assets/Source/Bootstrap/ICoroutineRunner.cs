using System.Collections;
using UnityEngine;

namespace Source.Bootstrap
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator enumerator);
    }
}
