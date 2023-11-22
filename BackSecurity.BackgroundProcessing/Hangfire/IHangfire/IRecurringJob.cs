using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BackSecurity.BackgroundProcessing.Hangfire.IHangfire
{
    public interface IRecurringJob
    {
        void AddOrUpdate(Expression<Action> methodCall, string cron);
        void AddOrUpdate<T>(string identifier, Expression<Action<T>> methodCall, string cron);

        void AddOrUpdate(string identifier, Expression<Action> methodCall, string cron);

        void RemoveIfExists(string identifier);

        void Trigger(string identifier);
    }
}
