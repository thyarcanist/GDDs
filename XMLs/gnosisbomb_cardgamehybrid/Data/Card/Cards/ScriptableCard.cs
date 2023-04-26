using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Card")]
public class ScriptableCard : MonoBehaviour
{
    bool isInPlay;
    bool isPrimer;
    bool isEventCard;
    bool isScenarioCard;
    bool isLocationCard;
    bool isEntityCard;
    bool unlockTier;

    public string cardCode;
    public string cardName;
    public string Description;
    private string Alignment;
    private void Awake()
    {
        if (isInPlay)
        {
            if (isEntityCard)
            {
                // Show and Set
                unlockTier = true;
            }
            if (isPrimer || isScenarioCard)
            {
                // Do Something To Scriptable Object
            }
        }
    }

    public string GetCardAlignment(string alignment)
    {
        return alignment;
    }

    private void SetInPlayFalse()
    {
        isInPlay = false;
    }
}
