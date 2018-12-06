using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using Debug = UnityEngine.Debug;
namespace ButterKnife.Streaming
{
    public class Scheduler
    {
        public Stopwatch watch;
        public float milliseconds;
        public Scheduler(float maxTimeInMilliseconds)
        {
            watch = new Stopwatch();
            milliseconds = maxTimeInMilliseconds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mono"> The Monobehaviour on which start the coroutine </param>
        /// <param name="action"> Action to run through the scheduler</param>
        /// <param name="iterations"> The number of iteration to do </param>
        /// <param name="onSchedulerTaskFinished"> Action to trigger when the scheduler has finished </param>
        /// <param name="debugTag"> DEBUG : So the console message is identified when the scheduled task finishes </param>
        public void RunScheduledTask(MonoBehaviour mono, System.Action action, int iterations, System.Action onSchedulerTaskFinished = null, string debugTag = "")
        {
            watch.Start();
            mono.StartCoroutine(Task(action, iterations, onSchedulerTaskFinished, debugTag));

        }
        
        public IEnumerator Task(System.Action action, int iterations, System.Action onEndEvent = null, string taskTag = "")
        {
            float time = Time.time;
            for (int i = 0; i < iterations; i++)
            {
                if (watch.ElapsedMilliseconds > milliseconds)
                {
                    yield return null;
                    watch.Reset();
                    if (taskTag != "")
                        Debug.Log("Scheduler skipped a frame for task : " + taskTag);
                    watch.Start();
                }
                action.Invoke();
            }
            if (taskTag != "")
                Debug.Log("Task lasted : " + (Time.time - time).ToString() + " to complete task : " + taskTag);
            onEndEvent?.Invoke();
        }
    }
}
