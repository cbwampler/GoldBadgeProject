using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repo
{
    //create a badge class
    public class BadgeInfo
    {
        public int BadgeId { get; set; }
        public List<string> DoorNames { get; set; }
        public string BadgeName { get; set; }
       

        public BadgeInfo() { }
       
        public BadgeInfo(int badgeId, List<string> doorNames, string badgeName)
        {
            BadgeId = badgeId;
            DoorNames = doorNames;
            BadgeName = badgeName;
        }
        
    }
    


}




