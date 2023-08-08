using UnityEngine;

[CreateAssetMenu(fileName ="AmmoScriptableObject",menuName ="ScriptableObjects/Create Ammo")]
public class Ammo : ScriptableObject
{
    [SerializeField] private FoodType foodtype;

    public FoodType GetFoodType() { return foodtype; }

    [SerializeField] private GameObject foodMesh;

    [SerializeField] private int damageValue;

    [SerializeField] private int maxAmmoAmt;
}

public enum FoodType { hotDog, burger, fries, meatCooked, taco, pizza }