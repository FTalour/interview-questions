using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    /// This the subject in the observer pattern.
    public class Job
    {
        private List<Applicant> applicants;
        private JobStatus statusOfJob;
        public Job()
        {
            applicants = new List<Applicant>();
        }
        public void Add(Applicant candidate)
        {
            applicants.Add(candidate);
        }
        public void Remove(Applicant candidate)
        {
            applicants.Remove(candidate);
        }
        public void Notify()
        {
            foreach (Applicant candidate in applicants)
            {
                candidate.Update(this);
            }
        }
        public JobStatus Status
        {
            get
            {
                return statusOfJob;
            }
            set
            {
                statusOfJob = value;
                Notify();
            }
        }
    }
    //Jobstatus enumerator
    public enum JobStatus { FILLED, SUSPENDED, REMOVED };
    /// This is Observer.
    public class Applicant
    {
        //declare variables
        string fname;
        string lname;
        string emailID;
        string phoneNo;
        public Applicant()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Properties for exposing the member variables
        #endregion
        public void Update(Job appliedJob)
        {
            switch (appliedJob.Status)
            {
                case JobStatus.FILLED:
                    //Do something like sending email, //updating database, etc
                    break;
                case JobStatus.REMOVED:
                    //Do something like sending email, //updating database, etc
                    break;
                case JobStatus.SUSPENDED:
                    //Do something like sending email, //updating database, etc
                    break;
            }
            //Your own functionality
            //End Of Functionality
        }
    }
}
