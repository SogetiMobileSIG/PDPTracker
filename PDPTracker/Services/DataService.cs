using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PDPTracker.Data;
using PDPTracker.Models;

namespace PDPTracker
{
    public class DataService : IDataService
    {
        ActivitiesRepository _repo;

        public DataService ()
        {
            _repo = new ActivitiesRepository ();
        }

        public List<Activity> GetActivities ()
        {
            return _repo.GetActivities ();
        }

        public Activity GetActivityById (int activityId)
        {
            return _repo.GetActivityById (activityId);
        }

        public int Login (string email, string password)
        {
            return _repo.Login (email, password);
        }

        public List<Activity> GetUserActivities (int userId)
        {
            return _repo.GetUserActivities (userId);
        }

        public User GetUser (int userId)
        {
            return _repo.GetUser (userId);
        }

        public int UpdateActivity (Activity activity)
        {
            return _repo.SaveActivity (activity);
        }

        public int RegisterUser (UserLogin userLogin)
        {
            return 0;
        }

        public int DeleteActivity (int activityId)
        {
            return _repo.DeleteActivity (activityId);
        }
    }
}

