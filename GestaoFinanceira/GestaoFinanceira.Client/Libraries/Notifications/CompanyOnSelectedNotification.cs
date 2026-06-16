namespace GestaoFinanceira.Client.Libraries.Notifications
{
    public class CompanyOnSelectedNotification
    {
        public Action? OnCompanySelected {  get; set; }

        public void NotificationOnselected()  
        {
            OnCompanySelected?.Invoke();
        }
    }
}
