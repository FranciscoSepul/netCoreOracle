using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using BackSecurity.BackgroundProcessing.Hangfire.IHangfire;

namespace BackSecurity.BackgroundProcessing.Hangfire
{
    public class HangfireBackgroundJob : IBackgroundJob
    {
        public string Enqueue(Expression<Action> methodCall)
        {
            return BackgroundJob.Enqueue(methodCall);
        }

        public string Enqueue<T>(string identifier, Expression<Action<T>> methodCall)
        {
            return BackgroundJob.Enqueue(methodCall);
        }

        public string Schedule(Expression<Action> methodCall, TimeSpan delay)
        {
            return BackgroundJob.Schedule(methodCall, delay);
        }

        public string Schedule<T>(Expression<Action<T>> methodCall, TimeSpan delay)
        {
            return BackgroundJob.Schedule(methodCall, delay);
        }

        public string Schedule(Expression<Action> methodCall, DateTimeOffset delay)
        {
            return BackgroundJob.Schedule(methodCall, delay);
        }

        public string Schedule<T>(Expression<Action<T>> methodCall, DateTimeOffset delay)
        {
            return BackgroundJob.Schedule(methodCall, delay);
        }

        public string ContinueJobWith(string parentId, Expression<Action> methodCall)
        {
            return BackgroundJob.ContinueJobWith(parentId, methodCall);
        }

        public string ContinueJobWith(string parentId, Expression<Action> methodCall, JobContinuationOptions options)
        {
            return BackgroundJob.ContinueJobWith(parentId, methodCall, options);
        }

        public string ContinueJobWith<T>(string parentId, Expression<Action<T>> methodCall)
        {
            return BackgroundJob.ContinueJobWith<T>(parentId, methodCall);
        }

        public string ContinueJobWith<T>(string parentId, Expression<Action<T>> methodCall, JobContinuationOptions options)
        {
            return BackgroundJob.ContinueJobWith<T>(parentId, methodCall, options);
        }

        public bool Delete(string identifier)
        {
            return BackgroundJob.Delete(identifier);
        }
    }
}
