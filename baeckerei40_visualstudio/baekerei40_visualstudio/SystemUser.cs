using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace baeckerei40
{
    class SystemUser : INotifyPropertyChanged
    {
        // Schnittstellen-Ereignis
        public event PropertyChangedEventHandler PropertyChanged;

        protected internal void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        // Eigenschaften
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value) return;
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _Rolle;
        public string Rolle
        {
            get { return _Rolle; }
            set
            {
                if (_Rolle == value) return;
                _Rolle = value;
                OnPropertyChanged("Rolle");
            }
        }
    }
}
