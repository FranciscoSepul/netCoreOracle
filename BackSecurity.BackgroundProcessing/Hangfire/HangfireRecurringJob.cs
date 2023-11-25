using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using BackSecurity.BackgroundProcessing.Hangfire.IHangfire;

namespace BackSecurity.BackgroundProcessing.Hangfire
{
    public class HangfireRecurringJob : IRecurringJob
    {
        public void AddOrUpdate(Expression<Action> methodCall, string cron)
        {
            RecurringJob.AddOrUpdate(methodCall, cron, TimeZoneInfo.Utc);
        }
        public void AddOrUpdate<T>(string identifier, Expression<Action<T>> methodCall, string cron)
        {
            RecurringJob.AddOrUpdate<T>(identifier, methodCall, cron, TimeZoneInfo.Utc);
        }
        public void AddOrUpdate(string identifier, Expression<Action> methodCall, string cron)
        {
            RecurringJob.AddOrUpdate(identifier, methodCall, cron, TimeZoneInfo.Utc);
        }
        public void RemoveIfExists(string identifier)
        {
            RecurringJob.RemoveIfExists(identifier);
        }
        public void Trigger(string identifier)
        {
            RecurringJob.Trigger(identifier);
        }
    }
}
