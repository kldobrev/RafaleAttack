public struct WeaponData
{
    public string cannonName;
    public int damageAmount;
    public int range;
    public int capacity;
    public string iconPath;
    public string particleSystemPath;

    public WeaponData(string name, int damage, int cannonRange, int cap, string path, string effectPath)
    {
        cannonName = name;
        damageAmount = damage;
        range = cannonRange;
        capacity = cap;
        iconPath = path;
        particleSystemPath = effectPath;
    }
}