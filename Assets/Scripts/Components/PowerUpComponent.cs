using System;

namespace PewPew.Components
{
    public enum PowerUpType
    {
        Weapon
    }

    [Serializable]
    public struct PowerUpComponent
    {
        public PowerUpType type;
    }
}
