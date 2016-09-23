using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace PDPTracker
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties

        #region Title
        private string _title;

        public string Title {
            get { return _title; }
            set { _title = value; OnPropertyChanged (); }
        }

        #endregion

        #region IsBusy
        private bool _isBusy;

        public bool IsBusy {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged (); }
        }
        #endregion

        #region CurrentPage
        private Page _currentPage;          public Page CurrentPage {             get { return _currentPage; }             set { _currentPage = value; OnPropertyChanged (); }         } 
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

