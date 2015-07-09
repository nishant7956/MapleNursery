using JustTest1.DataModel;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JustTest1.Controller
{
    public class JobControlls
    {
        public static string[] JobStatusCode = new string[] { "sent", "viewed", "accepted", "rejected", "started", "inprogress", "finished", "paused","notAssigned" };

        public static async Task<List<Job>> FindAllJobsById(string userID)
        {
            IEnumerable<ParseObject> query = null;
            List<Job> listofJobs = new List<Job>();

            //Debug.WriteLine(typeof(Job).username + " adsad");
            query = await ParseObject.GetQuery(typeof(Job).Name)
                            .WhereEqualTo(MemberInfoGetting.GetMemberName(() => new Job().EmployeeId), userID)
                            .FindAsync();

            foreach (ParseObject _job in query)
            {
                listofJobs.Add(new Job()
                {
                    Id = _job.ObjectId,
                    name = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().name)),
                    description = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().description)),
                    content = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().content)),
                    EmployeeId = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().EmployeeId)),
                    location = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().location)),
                    locCoordinate = _job.Get<ParseGeoPoint>(MemberInfoGetting.GetMemberName(() => new Job().locCoordinate)),
                    Status = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().Status)),
                    UserRelation = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().UserRelation))
                });
            }

            return listofJobs;
        }

        /// <summary>
        /// Jobs sent, viewed and accepted
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static async Task<List<Job>> FindAssignedJobsById(string userID)
        {
            IEnumerable<ParseObject> query = null;
            List<Job> listofJobs = new List<Job>();

            //Debug.WriteLine(typeof(Job).username + " adsad");
            query = await ParseObject.GetQuery(typeof(Job).Name)
                            .WhereEqualTo(MemberInfoGetting.GetMemberName(() => new Job().EmployeeId), userID)
                            .WhereNotContainedIn(MemberInfoGetting.GetMemberName(() => new Job().Status), new string[] { JobStatusCode[5], JobStatusCode[6] })
                            .FindAsync();

            foreach (ParseObject _job in query)
            {
                listofJobs.Add(new Job()
                {
                    Id = _job.ObjectId,
                    name = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().name)),
                    description = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().description)),
                    content = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().content)),
                    EmployeeId = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().EmployeeId)),
                    location = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().location)),
                    locCoordinate = _job.Get<ParseGeoPoint>(MemberInfoGetting.GetMemberName(() => new Job().locCoordinate)),
                    Status = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().Status)),
                    UserRelation = _job.Get<string>(MemberInfoGetting.GetMemberName(() => new Job().UserRelation))
                });
            }

            return listofJobs;
        }
    }
}