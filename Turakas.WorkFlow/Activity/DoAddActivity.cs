using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Primitives;
using WorkflowCore.Services;

namespace Turakas.WorkFlow.Activity
{
    public class DoAddActivity : IActivityController
    {
        public Task<PendingActivity> GetPendingActivity(string activityName, string workerId, TimeSpan? timeout = null)
        {
            throw new NotImplementedException();
        }

        public Task ReleaseActivityToken(string token)
        {
            throw new NotImplementedException();
        }

        public Task SubmitActivityFailure(string token, object result)
        {
            throw new NotImplementedException();
        }

        public Task SubmitActivitySuccess(string token, object result)
        {
            throw new NotImplementedException();
        }
    }
}