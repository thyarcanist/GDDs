using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


[XmlRoot("location")]
public class Location
{

    // Displays Location Info

    [XmlAttribute("locationName")]
    public string locationName;

    [XmlAttribute("code")]
    public string code;

    [XmlAttribute("description")]
    public string description;

    [XmlAttribute("entrylevel")]
    public int entryLevel;

    [XmlAttribute("keyword")]
    public string cardKey;

    [XmlAttribute("stashAmount")]
    public int stashAmount;

}
