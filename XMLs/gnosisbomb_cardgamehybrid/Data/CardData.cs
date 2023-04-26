using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName="New Card", menuName ="VoidOS/Card Creation")]
public class CardData : ScriptableObject
{
    [Header("Card Enums")]
    public string type;
    public string cardName;

    public GameObject cardObj;
    public enum CardType
    {
        None,
        Location,
        Primer,
        Scenario,
        Event,
        Entity
    }
    public CardType currentCardType;
    public enum EntityType
    {
        ArchAngel,
        Lord,
        None
    }
    public EntityType entityType;
    public enum KarmicPointsRange
    {
        Nil,
        I,
        II,
        III,
        IV,
        V
    }
    public KarmicPointsRange KarmaRange;
    public enum EventCardType
    {
        None,
        Black,
        White,
        Grey,
        Movement
    };
    public EventCardType currentEventType;

    // Gameplay Values
    bool isInPlay;
    bool isPlayed;

    [Header("More Card Booleans")]
    bool unlocksTier;
    bool isPrimerCard;
    bool isEventCard;
    bool isScenarioCard;
    bool isEntityCard;
    bool isLocationCard;

    int karmicPointsValue;

    [Header("Primer Values")]
    // Primer values
    public string primerName;
    public string cardAlignment;

    [Header("Location Values")]
    // Location values
    public string locationName;
    public int entryLevel;
    public int stashAmount;

    [Header("Both Values")]
    public string cardKey;
    public string code;
    public string description;

    private void Awake()
    {
        type = currentCardType.ToString();
        // Entity Type
        if (entityType == EntityType.Lord || entityType == EntityType.ArchAngel)
        {
            isEntityCard = true;
            switch (KarmaRange)
            {
                case KarmicPointsRange.Nil:
                    karmicPointsValue = Random.Range(0, 0);
                    break;
                case KarmicPointsRange.I:
                    karmicPointsValue = Random.Range(-50, -10);
                    break;
                case KarmicPointsRange.II:
                    karmicPointsValue = Random.Range(-60, -80);
                    break;
                case KarmicPointsRange.III:
                    karmicPointsValue = Random.Range(-60, -80);
                    break;
                case KarmicPointsRange.IV:
                    karmicPointsValue = Random.Range(-60, -80);
                    break;
                case KarmicPointsRange.V:
                    karmicPointsValue = Random.Range(-60, -80);
                    break;
            }

            if (entityType == EntityType.ArchAngel)
            {
                karmicPointsValue = Mathf.Abs(karmicPointsValue);
            }
        }
        else
        {
            isEntityCard = false;
        }
        // Event Card
        if (isEventCard)
        {
            //
        }
        // Location Card
        if (isLocationCard)
        {

        }
        if (isPrimerCard || isScenarioCard)
        {
            karmicPointsValue = 0;
            if (isPrimerCard)
            {
                // Primer
            }
            else if (isScenarioCard)
            {
                // Scenario
            }
        }

        if (isInPlay)
        {
            if (isEntityCard)
            {
                // Show and Set
                unlocksTier = true;
                // Unlocks new karmic tiers for things to do.
                // If no other tiers to unlock exists, net (pos) OR (neg) karma
            }
            else
            {
                unlocksTier = false;
            }

            isPlayed = true;
        }
        if (isPlayed == true)
        {
            // Do Everything Else
        }
    }
    void Start()
    {
        if (currentCardType == CardType.Location)
        {
            // Specify the Following:
            // LocationGen.cs
        }
    }

    public static void CreateCard()
    {
        CardData cardData = CreateInstance<CardData>();

        AssetDatabase.CreateAsset(cardData, "Assets/VoidOS/Cards/NewCard.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = cardData;
    }
}