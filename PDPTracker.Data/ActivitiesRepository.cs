using System.Collections.Generic;
using PDPTracker.Models;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace PDPTracker.Data
{
    public class ActivitiesRepository
    {
        #region Private Fields

        readonly SQLiteConnection _database;
        object locker = new object();

        #endregion

        #region Constructor

        public ActivitiesRepository ()
        {
            _database = DependencyService.Get<ISQLite> ().GetConnection ();

            _database.CreateTable<Category> ();
            _database.CreateTable<Grade> ();
            _database.CreateTable<Activity> ();
            _database.CreateTable<UserLogin> ();
            _database.CreateTable<User> ();
        }

        #endregion

        #region User

        public int Register(UserLogin userLogin){
            lock(locker){
                return _database.Insert (userLogin);
            }
        }

        public int Login(string email, string password){
            lock(locker) {
                return _database.Table<UserLogin> ().FirstOrDefault (x => string.Equals (email, x.Email) && string.Equals(password, x.Password)).UserId;
            }
        }

        public User GetUser(int userId){
            lock (locker) {
                return _database.Table<User> ().FirstOrDefault (x => x.Id == userId);
            }
        }

        #endregion

        #region Activities

        public List<Activity> GetActivities () {
            lock (locker) {
                return _database.Table<Activity> ().ToList ();
            }
        }

        public List<Activity> GetUserActivities(int userId){
            lock(locker){
                return _database.Table<Activity> ().Where (x => x.UserId == userId).ToList();
            }
        }

        public Activity GetActivityById (int activityId)
        {
            lock (locker) {
                return _database.Table<Activity> ().FirstOrDefault (x => x.Id == activityId);
            }
        }

        public int SaveActivity(Activity activity){

            if(activity.Id > 0){
                lock(locker) {
                    return _database.Update (activity, typeof (Activity));
                }
            } else {
                lock (locker) {
                    return _database.Insert (activity, typeof (Activity));
                }
            }
        }

        public int DeleteActivity(int activityId){
            lock(locker) {
                return _database.Delete<Activity> (activityId);
            }
        }

        #endregion

    }
}
