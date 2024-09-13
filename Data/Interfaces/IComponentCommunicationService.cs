namespace CustomersTable.Data.Interfaces
{
    public interface IComponentCommunicationService
    {
        public event Action<string>? ErrorOccured;
        public event Action<bool>? BusyChanged;
        public event Action<bool>? IsEditingChanged;
        public event Action? DownloadNeeded;
        public event Action? RefreshNeeded;
        public void TriggerError(string message);
        public void TriggerBusy(bool busy);
        public void TriggerEditing(bool isEditing);
        public void TriggerDownload();
        public void TriggerReresh();

    }
}
