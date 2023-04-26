using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;

public class DataManager : MonoBehaviour
{
    [ContextMenu("Do Something")]
    public void DoSomething()
    {
        Debug.Log("Take some fire breaths.");
    }

    public string primerToLoad;
    public string locationToLoad;

    // Keywords will clear after round is over; for new cards.
    // Keywords will be taken from all cards in the scene
    public List<string> Keywords;

    public void Awake()
    {
        Keywords = new List<string>();
    }


    // Copy Paste, for PRIMER LOAD XML Data

    [ContextMenu("Load Primer XML Data")]
    public void LoadPrimerXMLData()
    {
        // Correct The File Path
        string path = $"{Application.dataPath}/Resources/Data/Card/XML/Primers/{primerToLoad}.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(Primer));
        StreamReader reader = new StreamReader(path);
        Primer deserialized = (Primer)serializer.Deserialize(reader.BaseStream);
        reader.Close();

        Debug.Log($"Loaded Primer: {primerToLoad}");
        Debug.Log("----------------");
        Debug.Log($"code = {deserialized.code}");
        Debug.Log($"name = {deserialized.primerName}");
        Debug.Log($"description = {deserialized.cardDescription}");
        Debug.Log($"alignment = {deserialized.cardAlignment}");
        Debug.Log($"keyword = {deserialized.cardKey}");

        if (!Keywords.Contains(deserialized.cardKey))
        {
            Keywords.Add(deserialized.cardKey);
        }
    }

    [ContextMenu("Load Location XML Data")]
    public void LoadLocationXMLData()
    {
        string path = $"{Application.dataPath}/Resources/Data/Card/XML/Locations/{locationToLoad}.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(Location));
        StreamReader reader = new StreamReader(path);
        Location deserialized = (Location)serializer.Deserialize(reader.BaseStream);
        reader.Close();

        if (!Keywords.Contains(deserialized.cardKey))
        {
            Keywords.Add(deserialized.cardKey);
        }

    }

    public void GetLocationXMLData(string locationName)
    {
        string path = $"{Application.dataPath}/Resources/Data/Card/XML/Locations/{locationName}.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(Location));
        StreamReader reader = new StreamReader(path);
        Location deserialized = (Location)serializer.Deserialize(reader.BaseStream);
        reader.Close();
    }

    // END FOR OTHER XML DATA

    // PRIMER SAVE XML DATA
    [Header("Create A Primer Card")]
    public string _code;
    public string _primerName;
    public string _description;
    public string _alignment;
    public string _cardKey;

    [ContextMenu("Save Primer XML Data")]
    public void SavePrimerXMLData()
    {
        Primer NewPrimer = new Primer()
        {
            code = _code,
            primerName = _primerName,
            cardDescription = _description,
            cardAlignment = _alignment,
            cardKey = _cardKey
        };

        string path = $"{Application.dataPath}/Resources/Data/Card/XML/Primers/{NewPrimer.primerName}.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(Primer));
        StreamWriter writer = new StreamWriter(path);
        serializer.Serialize(writer.BaseStream, NewPrimer);
        writer.Close();

        Debug.Log($"Saved primer to file:{path}");
    }


    [Header("Create A Location Card")]
    public string _codeLoc;
    public string _locationName;
    public string _descriptionLoc;
    public int _entryLevel;
    public int _stashAmount;
    public string _keywordLoc;


    [ContextMenu("Save Location XML Data")]
    public void SaveLocationXMLData()
    {

        Location NewLocation = new Location()
        {
            code = _codeLoc,
            locationName = _locationName,
            description = _descriptionLoc,
            entryLevel = _entryLevel,
            cardKey = _keywordLoc,
            stashAmount = _stashAmount
        };


        string path = $"{Application.dataPath}/Resources/Data/Card/XML/Locations/{NewLocation.locationName}.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(Location));
        StreamWriter writer = new StreamWriter(path);
        serializer.Serialize(writer.BaseStream, NewLocation);
        writer.Close();

        Debug.Log($"Saved location to file:{path}");
    }


    // Displays PrimerData
    public void DisplayPrimerDataOnTMPro()
    {
        // Get the Primer data
        Primer primer = GetPrimerData();

        // Get the UI elements
        TextMeshProUGUI codeText = GameObject.Find("CodeText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI descText = GameObject.Find("DescText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI alignText = GameObject.Find("AlignText").GetComponent<TextMeshProUGUI>();

        // Assign the values to the UI elements
        codeText.text = "Code: " + primer.code;
        nameText.text = "Name: " + primer.primerName;
        descText.text = "Description: " + primer.cardDescription;
        alignText.text = "Alignment: " + primer.cardAlignment;
    }

    // Method to get the Primer data
    private Primer GetPrimerData()
    {
        // Correct The File Path
        string path = $"{Application.dataPath}/Resources/Data/Card/XML/Primers/{primerToLoad}.xml";
        XmlSerializer serializer = new XmlSerializer(typeof(Primer));
        StreamReader reader = new StreamReader(path);
        Primer deserialized = (Primer)serializer.Deserialize(reader.BaseStream);
        reader.Close();

        return deserialized;
    }

    private void Update()
    {
        DisplayPrimerDataOnTMPro();
    }

    void ClearKeywords(bool isRoundNew)
    {
        Keywords.Clear();
    }
}