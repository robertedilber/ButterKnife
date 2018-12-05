using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
namespace ButterKnife.Streaming
{
    public class Scheduler
    {
        bool verbose;
        public Stopwatch watch;
        public float milliseconds;
        public Scheduler(float maxTimeInMilliseconds, bool activateDebug)
        {
            watch = new Stopwatch();
            milliseconds = maxTimeInMilliseconds;
            verbose = activateDebug;
        }


        public void RunScheduledTask(MonoBehaviour mono, System.Action action, int iterations)
        {
            watch.Start();
            mono.StartCoroutine(Task(action, iterations));
            
        }

        public IEnumerator Task(System.Action action, int iterations)
        {
            float time = Time.time;
            for (int i = 0; i < iterations; i++)
            {
                if (watch.ElapsedMilliseconds > milliseconds)
                {
                    yield return null;
                    watch.Reset();
                    if (verbose)
                        Debug.Log("Scheduler skipped a frame for task : " + action);
                    watch.Start();
                }
                action.Invoke();
            }
            if (verbose)
            {

                Debug.Log("Task lasted : " + (Time.time - time).ToString() + " to complete task : " + action);
            }
        }
    }
}
