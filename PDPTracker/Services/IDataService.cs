using System;
using System.Collections.Generic;
using PDPTracker.Models;

namespace PDPTracker
{
    public interface IDataService
    {
        int RegisterUser (UserLogin userLogin);
        int Login (string email, string password);
        User GetUser (int userId);
        List<Activity> GetActivities ();
        List<Activity> GetUserActivities (int userId);
        Activity GetActivityById (int activityId);
        int UpdateActivity (Activity activity);
        int DeleteActivity (int activityId);
    }
}
