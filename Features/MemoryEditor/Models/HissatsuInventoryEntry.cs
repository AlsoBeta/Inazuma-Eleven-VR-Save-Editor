using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InazumaElevenVRSaveEditor.Features.MemoryEditor.Models
{
    public class HissatsuInventoryEntry : INotifyPropertyChanged
    {
        private int _amount;

        public string Name { get; set; } = string.Empty;

        public long Address { get; set; }

        public string? Note { get; set; }
        public int Amount
        {
            get => _amount;
            set
            {
                int clamped = Math.Max(0, Math.Min(value, 9999));

                if (_amount != clamped)
                {
                    _amount = clamped;
                    OnPropertyChanged();
                }
            }
        }

        public string AddressDisplay => $"0x{Address:X}";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
