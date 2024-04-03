public struct WeaponData
{
    public string cannonName;
    public int damageAmount;
    public int range;
    public int capacity;
    public float activeTime;
    public string iconPath;
    public string particleSystemPath;

    public WeaponData(string name, int damage, int weaponRange, int weaponCapacity, float timeActive, string path, string effectPath)
    {
        cannonName = name;
        damageAmount = damage;
        range = weaponRange;
        capacity = weaponCapacity;
        activeTime = timeActive;
        iconPath = path;
        particleSystemPath = effectPath;
    }
}