using System;
using System.Collections.Generic;
using PDPTracker.Models;

namespace PDPTracker
{
    public interface IDataService
    {
        List<Activity> GetActivities ();
        Activity GetActivityById (int activityId);
        void UpdateActivity (Activity activity);
    }
}
