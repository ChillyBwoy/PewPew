using System;

namespace PewPew.Components
{
    public enum PickUpItemType
    {
        Weapon
    }

    [Serializable]
    public struct PickUpItemComponent
    {
        public PickUpItemType type;
    }
}
