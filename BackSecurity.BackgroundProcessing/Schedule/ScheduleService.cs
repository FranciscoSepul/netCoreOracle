using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using BackSecurity.BackgroundProcessing.Schedule.ISchedule;

namespace BackSecurity.BackgroundProcessing.Schedule
{
    public class ScheduleService : IScheduleService
    {

        private readonly ILogger logger;

        public ScheduleService(ILogger<ScheduleService> logger)
        {
            this.logger = logger;
        }

        public void Saludar()
        {
            logger.LogInformation("Hola, estoy siendo ejecutado desde un cron!");
            logger.LogInformation("Que tengas un buen dia :)");
        }
    }
}
