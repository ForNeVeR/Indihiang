///
/// ThreadBarrierExtensions class is taken from 
/// http://blog.quantumbitdesigns.com/2008/07/22/simplifying-ui-and-worker-threads-delegatemarshaler-revisited/
///

using System;
using System.Threading;

namespace Indihiang.Cores
{
    /// <summary>
    /// Provides extension method for raising an event using a SynchronizationContext
    /// </summary>
    public static class ThreadBarrierExtensions
    {
        /// <summary>
        /// Asynchronously posts a call to a method on a synchronization context
        /// </summary>
        /// <typeparam name="T">The type of event args</typeparam>
        /// <param name="synchronizationContext">The SynchronizationContext to which the method will be posted</param>
        /// <param name="action">The method to post to the provided SynchronizationContext</param>
        /// <param name="eventArgs">The event args</param>
        public static void Post<T>(this SynchronizationContext synchronizationContext, Action<T> action, T eventArgs)
            where T : EventArgs
        {
            //posting implies asynchronous so if no SynchronizationContext exists, 
            //just post the method to a threadpool thread
            if (synchronizationContext == null)
            {
                ThreadPool.QueueUserWorkItem((e) => action((T)e), eventArgs);
            }
            else
            {
                synchronizationContext.Post((e) => action((T)e), eventArgs);

                //alternate technique
                //synchronizationContext.Post(delegate { action(eventArgs); }, null);
            }
        }

        /// <summary>
        /// Synchronously posts a call to a method on a synchronization context
        /// </summary>
        /// <typeparam name="T">The type of event args</typeparam>
        /// <param name="synchronizationContext">The SynchronizationContext to which the method will be sent</param>
        /// <param name="action">The method to send to the provided SynchronizationContext</param>
        /// <param name="eventArgs">The event args</param>
        public static void Send<T>(this SynchronizationContext synchronizationContext, Action<T> action, T eventArgs)
            where T : EventArgs
        {
            //if no SynchronizationContext exists, just call the method
            if (synchronizationContext == null)
            {
                action(eventArgs);
            }
            else
            {
                synchronizationContext.Send((e) => action((T)e), eventArgs);

                //alternate technique
                //synchronizationContext.Send(delegate { action(eventArgs); }, null);
            }
        }
    }
}
