using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public Dictionary<int, List<string>> GetListOfBadges()
        {
            return _badgeDictionary;
        }

        public void AddNewBadgeToList(Badge newBadge)
        {
            _badgeDictionary.Add(newBadge.BadgeID, newBadge.DoorNames);
        }

        public Badge GetBadgeByBadgeID(int badgeID)
        {
            foreach (KeyValuePair<int, List<string>> existingBadge in _badgeDictionary)
            {
                foreach (string door in existingBadge.Value)
                {
                    if (existingBadge.Key == badgeID)
                    {
                        Badge badge = new Badge(existingBadge.Key, existingBadge.Value);
                        return badge;
                    }
                }
            }
            return null;
        }
    }
}
