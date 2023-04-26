using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;


[XmlRoot("primer")]
public class Primer 
{
    // Displays Card Info

    [XmlAttribute("code")]
    public string code;

    [XmlAttribute("primerName")]
    public string primerName;

    [XmlAttribute("description")]
    public string cardDescription;

    [XmlAttribute("alignment")]
    public string cardAlignment;

    [XmlAttribute("keyword")]
    public string cardKey;
}
