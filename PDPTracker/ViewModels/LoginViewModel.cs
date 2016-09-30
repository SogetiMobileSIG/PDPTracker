using System.Threading.Tasks;
using System.Windows.Input;
using PDPTracker.Models;
using Xamarin.Forms;

namespace PDPTracker
{
    public class LoginViewModel : BaseViewModel
    {

        #region Private Fields

        IDataService _dataService;

        #endregion

        #region Constructor

        public LoginViewModel (Page parentPage)
        {
            Title = "PDP Tracker";
            CurrentPage = parentPage;
            _dataService = new DataService ();
        }

        #endregion

        #region Properties

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
                return _shouldRemember;
            }
            set {
                _shouldRemember = value;
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
                await CurrentPage.Navigation.PopModalAsync();
            }
            else
                ShowErrorMsg = true;

            ShowIndicator = false;
        }

        private bool LoginSuccessful () 
        {
            var userId = _dataService.Login (Username, Password);
            User user;

            if(userId > 0){
                user = _dataService.GetUser (userId);
                CurrentPage.DisplayAlert("Login", user.Name, "OK");
                return true;
            } else {
                CurrentPage.DisplayAlert ("Login", "Login failed", "OK");
                return false;
            }
        }


        #endregion
    }
}
