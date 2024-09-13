using CustomersTable.Data.Interfaces;

namespace CustomersTable.Services
{
    public class ComponentCommunicationService : IComponentCommunicationService
    {
        public event Action<string>? ErrorOccured;
        public event Action<bool>? BusyChanged;
        public event Action<bool>? IsEditingChanged;
        public event Action? DownloadNeeded;
        public event Action? RefreshNeeded;

        public void TriggerError(string message) => ErrorOccured?.Invoke(message);
        public void TriggerBusy(bool busy) => BusyChanged?.Invoke(busy);
        public void TriggerEditing(bool isEditing) => IsEditingChanged?.Invoke(isEditing);

        public void TriggerDownload() => DownloadNeeded?.Invoke();

        public void TriggerReresh() => RefreshNeeded?.Invoke();
    }
}
