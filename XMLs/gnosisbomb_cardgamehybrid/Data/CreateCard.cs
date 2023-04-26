using UnityEngine;
using System.IO;
using UnityEditor;

[RequireComponent(typeof(CardData))]
public class CreateCard : MonoBehaviour
{
    public CardData cardData;

    [ContextMenu("Create Card")]
    public void CreateCardFile()
    {
        cardData = GetComponent<CardData>();
        // Create a file based on the CardType
        string filePath = Path.Combine("Assets/Cards/", cardData.currentCardType.ToString() + "/" + cardData.cardName + ".asset");

        // Create the asset
        AssetDatabase.CreateAsset(cardData, filePath);
    }
}