using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PDPTracker
{
    public class LoginViewModel : BaseViewModel
    {

        #region Private Fields

        private readonly Page _parentPage;

        #endregion

        #region Constructor

        public LoginViewModel (Page parentPage)
        {
            _parentPage = parentPage;
        }

        #endregion

        #region Properties

        #region Login Title

        private string _loginTitle = "PDP Tracker";

        public string LoginTitle {
            get { 
                return _loginTitle; 
            }
            set {
                _loginTitle = value;
                OnPropertyChanged ();
            }
        }
        #endregion

        #region Username

        private string _username;

        public string Username {
            get {
                return _username;
            }

            set {
                _username = value;
                OnPropertyChanged ();
            }
        }
        #endregion

        #region Password

        private string _password;

        public string Password {
            get {
                return _password;
            }

            set {
                _password = value;
                OnPropertyChanged ();
            }
        }

        #endregion

        #region Remember Me

        private bool _shouldRemember;

        public bool ShouldRemember {
            get {
                return DataService.Instance.RememberMe;
            }
            set {
                DataService.Instance.RememberMe = value;
                OnPropertyChanged ();}
        }


        #endregion

        #region ErrorMsg
        
        public string ErrorMsg => "Login failed";

        #endregion

        #region ShowErrorMsg

        private bool _showErrorMsg;

        public bool ShowErrorMsg
        {
            get { return _showErrorMsg; }
            set
            {
                if (_showErrorMsg.Equals(value))
                    return;

                _showErrorMsg = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private bool _showIndicator;
        public bool ShowIndicator
        {
            get { return _showIndicator; }
            set
            {
                _showIndicator = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand => new Command (OnLogin);

        #endregion

        #region Private Methods

        private async void OnLogin ()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                return;

            ShowIndicator = true;

            if (Task.Run(() => LoginSuccessful()).Result)
            {
                ShowErrorMsg = false;
                await _parentPage.Navigation.PopModalAsync();
            }
            else
                ShowErrorMsg = true;

            ShowIndicator = false;
        }

        private bool LoginSuccessful() => string.Equals(Username, Password);


        #endregion
    }
}
