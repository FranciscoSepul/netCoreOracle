
namespace BackSecurity.Settings
{
    public class AppSetting
    {
        public string Domain { get; set; }
        public bool CronActivated { get; set; }
        public bool RepairActivated { get; set; }
        public MailSettings MailSettings { get; set; }
    }
}
