using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KomodoIns_Repo
{
    public class KomodoInsRepo
    { 
    //Location for all items to be held
        private Queue<ClaimInfo> _claimQ = new Queue<ClaimInfo>();

        //Method for Agent to see all claims
        public Queue<ClaimInfo> ViewAllClaims()
        {
            return _claimQ;
        }

        
        //Evaluate the date of the incident and date of claim.  Determine whether the claim is valid or not( if it is within the 30-day grace period to file a claim)

        public void AddClaimToList(ClaimInfo claim)
        {
            _claimQ.Enqueue(claim);
        }

        //View first claim in queue
        public ClaimInfo GetNextClaim()
        {
            return _claimQ.Peek();
        }

        //Delete first claim in queue
        public ClaimInfo DeleteClaimfromQueue()
        {
            return _claimQ.Dequeue();
        }
    }
}
