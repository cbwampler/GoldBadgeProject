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

        //Method for Agent to take care of next claim by either pressing 'Y'to handle the claim, or 'N' to go back to the main menu
        


        //Method for agent to enter a new claim.  New claim will be entered by providing the following information;
        //Enter the Claim ID:
        //Enter the Claim Type:
        //Enter the claim description:
        //Enter the Amount of Damage:
        //Enter the Date of the Incident:
        //Enter the Date of Claim:
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

        //Update a claim in a queue
    }
}
