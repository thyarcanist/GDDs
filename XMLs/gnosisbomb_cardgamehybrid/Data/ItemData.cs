using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public enum UseType
{
    Undefined,
    Health,
    Junk,
    Tool,
    Gas,
    Intel
}
public enum FoodCategory
{
    Undefined,
    Food,
    Drink
}

[CreateAssetMenu(fileName = "New Item", menuName = "ItemData")]
public class ItemData : ScriptableObject
{
    [Header("General Item Data")]
    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject prefab;

    [Header("Description")]
    public int usageAmount;
    public float durability;
    public float value;
    public bool perishable;
    public float perishTime;
    public float itemWeight;
    public bool canItemBeUsed;

    [Header("Food Values")]
    public int healingAmount;
    public FoodCategory foodType;
    public bool isRotten; // will change healingAmount to a very low number, if isRotten and perishTime resets, it will be removed

    [Header("Usage")]
    public UseType type;
    public bool isInUse;
    public int GetEntryLevel;


    [ContextMenu("Save ItemData")]
    public void SaveItem(ItemData itemData)
    {
        string path = "Assets/Resources/Data/Items" + itemData.itemName + ".asset";
        AssetDatabase.CreateAsset(itemData, path);
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = itemData;
    }

    private void Awake()
    {
        if (!canItemBeUsed)
        {
            canItemBeUsedUp = false;
        }
        if (type != UseType.Health)
        {
            foodType = FoodCategory.Undefined;
        }
    }

    public void DecayItem(bool isTraversing)
    {
        if (perishable && isTraversing)
        {
            perishTime -= Time.deltaTime;

            if (perishTime <= 0)
            {
                perishTime = 0;
                Debug.Log($"{itemName} has decayed");
            }
        }
    }

    private bool canItemBeUsedUp;
    public void UseItem(bool canItemBeUsed, UseType type)
    {
        switch (type)
        {
            case UseType.Health:
                if (canItemBeUsed && usageAmount > 0)
                {
                    usageAmount = 0;
                    Debug.Log("Health replenished!");
                }
                break;
            case UseType.Junk:
                if (canItemBeUsed && usageAmount <= 1)
                {
                    usageAmount = 0;
                    Debug.Log("Item has been used up");
                }
                else if (canItemBeUsed && usageAmount > 1)
                {
                    usageAmount--;
                }
                break;
            case UseType.Tool:
                if (canItemBeUsed && usageAmount == 3)
                {
                    usageAmount = 0;
                    Debug.Log("Item has been broken and used up");
                }
                else if (canItemBeUsed && usageAmount > 0)
                {
                    usageAmount--;
                }
                if (canItemBeUsed && itemName == "AutoLock")
                {
                    if (GetEntryLevel >= 1 && GetEntryLevel <= 4)
                    {
                        // Unlock Attempt
                        UseAutoLock();

                    }
                }
                break;
            case UseType.Intel:
                if (canItemBeUsed && usageAmount > 0)
                {
                    usageAmount = 0;
                    Debug.Log("Intel has been used");
                }
                break;
            case UseType.Gas:
                if (canItemBeUsed && usageAmount > 0 && isInUse)
                {
                    usageAmount -= (int)0.15f;
                    Debug.Log("Gas is being used");
                }
                else if (canItemBeUsed && usageAmount <= 0)
                {
                    usageAmount = 0;
                    Debug.Log("Gas has been depleted");
                }
                break;
            default:
                Debug.Log("What are you trying to do?");
                break;
        }
    }

    public void ReduceItemValue(float durability)
    {
        float durabilityLoss = durability / 5;
        value *= (1 - durabilityLoss * 0.35f);
    }

    #region AutoLock

    private int AutoLockUses;
    public void UseAutoLock()
    {
        if (itemName == "AutoLock")
        {
            AutoLockUses++;
            if (GetEntryLevel >= 1 && GetEntryLevel <= 4)
            {
                float successRate = 80f;
                successRate -= 5f * (GetEntryLevel - 1);
                durability -= 3f;
                if (durability < 10f)
                {
                    successRate = 0.5f;
                }
                if (CalculateEvent(successRate))
                {
                    Debug.Log("Lockpicked successfully.");
                }
                else
                {
                    Debug.Log("Unlocking failed.");
                }
            }
        }
    }

    public bool CalculateEvent(float successRate)
    {
        float random = Random.Range(0f, 100f);
        if (random < successRate)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

}