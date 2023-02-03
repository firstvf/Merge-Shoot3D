using System.Collections.Generic;

[System.Serializable]
public class ButtonsData 
{
    private List<(int, uint)> _weaponsCost;

    public List<(int, uint)> GetWeaponsCost() => _weaponsCost;

    public ButtonsData()
    {
        
    }
}