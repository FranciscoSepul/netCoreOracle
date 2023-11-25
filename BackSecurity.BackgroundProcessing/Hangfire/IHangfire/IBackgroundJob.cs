using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BackSecurity.BackgroundProcessing.Hangfire.IHangfire
{
    public interface IBackgroundJob
    {
        string Enqueue(Expression<Action> methodCall);
        string Enqueue<T>(string identifier, Expression<Action<T>> methodCall);
        string Schedule(Expression<Action> methodCall, TimeSpan delay);
        string Schedule<T>(Expression<Action<T>> methodCall, TimeSpan delay);
        string Schedule(Expression<Action> methodCall, DateTimeOffset delay);
        string Schedule<T>(Expression<Action<T>> methodCall, DateTimeOffset delay);
        bool Delete(string identifier);
        string ContinueJobWith(string parentId, Expression<Action> methodCall);
        string ContinueJobWith(string parentId, Expression<Action> methodCall, JobContinuationOptions options);
        string ContinueJobWith<T>(string parentId, Expression<Action<T>> methodCall);
        string ContinueJobWith<T>(string parentId, Expression<Action<T>> methodCall, JobContinuationOptions options);
    }
}
