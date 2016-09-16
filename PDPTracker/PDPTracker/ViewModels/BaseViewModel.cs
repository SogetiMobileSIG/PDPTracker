using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PDPTracker
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties

        #region Title
        private string _title;

        public string Title {
            get { return _title; }
            set { _title = value; }
        }

        #endregion

        #region IsBusy
        private bool _isBusy;

        public bool IsBusy {
            get { return _isBusy; }
            set { _isBusy = value; }
        }
        #endregion

        #endregion

        #region INotify Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke (this, new PropertyChangedEventArgs (propertyName));
        }
        #endregion
    }
}

