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
    { //location for all items to be held
        private List<ClaimInfo> _listOfClaims = new List<ClaimInfo>();

        //Method for Agent to see all claims
        public List<ClaimInfo> ViewAllClaims()
        {
            return _listOfClaims;
        }

        //Method for Agent to take care of next claim by either pressing 'Y'to handle the claim, or 'N' to go back to the main menu
        public bool DisplayFirstClaim(int existingClaimId, ClaimInfo newClaim)
        {
            
            //Find the claim in queue
            ClaimInfo existingClaim = GetClaimById(existingClaimId);
                        

            //Show the claim information
            if(existingClaim != null)
            {
                existingClaim.ClaimId = newClaim.ClaimId;
                existingClaim.TypeOfClaim = newClaim.TypeOfClaim;
                existingClaim.Description = newClaim.Description;
                existingClaim.ClaimAmount = newClaim.ClaimAmount;
                existingClaim.DateOfIncident = newClaim.DateOfIncident;
                existingClaim.DateOfClaim = newClaim.DateOfClaim;
                existingClaim.IsValid = newClaim.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }


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
            _listOfClaims.Add(claim);
        }

        //Create a Helper method to find the existing claim to manipulate
        public ClaimInfo GetClaimById(int claimId)
        {
            foreach (ClaimInfo claim in _listOfClaims)
            {
                if (claim.ClaimId == claimId)
                {
                    return claim;
                }
            }
            return null;
        }
    }
}
