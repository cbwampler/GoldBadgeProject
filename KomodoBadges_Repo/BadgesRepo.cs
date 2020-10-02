using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repo
{
    public class BadgesRepo
    {
        //Dictionary of badges
        private Dictionary<int, BadgeInfo> _badges = new Dictionary<int, BadgeInfo>();

        //add a badge to the dictionary
        public void AddBadgeToDict(int badgeId, BadgeInfo doorAccess)
        {
            _badges.Add(badgeId, doorAccess);
        }
        

        //view all badges in the dictionary
        public Dictionary<int, BadgeInfo> ViewAllBadges()
        {
            return _badges;
        }

        //view one badge

        public Dictionary<int, BadgeInfo> ViewOneBadge()
        {
            return _badges;
        }
     
        //delete a badge from the dictionary

        public bool DeleteBadgeFromDict(int badgeId)
        {
            BadgeInfo badge = GetBadgeInfoByID(badgeId);
            if (badge == null)
            {
                return false;
            }

            int initialCount = _badges.Count;
            _badges.Remove(badgeId);

            if(initialCount > _badges.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //update a badge in the dictionary

        public bool UpdateDoorsForBadge(int badgeId, BadgeInfo newDoors)
        {
            //Find existing doors for badgeId

            BadgeInfo existingBadgeInfo = GetBadgeInfoByID(badgeId);

            //Update doors for badge 

            if(existingBadgeInfo != null)
            {
                existingBadgeInfo.DoorNames = newDoors.DoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }

        //update badge doors 

        public bool UpdateBadgeDoorAccess(int badgeId, BadgeInfo newDoors)
        {
            //find the badge to update
            BadgeInfo existingBadgeInfo = GetBadgeInfoByID(badgeId);

            //view the badge info
            if(existingBadgeInfo != null)
            {
                existingBadgeInfo.DoorNames = newDoors.DoorNames;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        
        
        //add door access to badge

        public void AddDoorAccess()
        {


        }


        //remove door access to badge
        public void RemoveDoorAccess()
        {

        }


        //Helper Method to load Badge by ID

        public BadgeInfo GetBadgeInfoByID(int badgeId)
        {
            foreach(KeyValuePair<int, BadgeInfo> badgeInfo  in _badges)
            {
                if(badgeInfo.Key == badgeId)
                {
                    return badgeInfo.Value;
                }
            }
            return null;
        }

           }

}
