using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ImportRaScript : MonoBehaviour
{
    public GameObject Level;
    public GameObject Prefab;
    public List<string> nameMaterials;
    public List<Material> Materials;
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImportJson()
    {
        string jsonFile = File.ReadAllText(EditorUtility.OpenFilePanel("Import Json", "", ""));

        for (int i = 0; i < Level.transform.childCount; i++)
        {
            if (Level.transform.GetChild(i).GetComponent<ARMoveblePoint>())
            {
                Destroy(Level.transform.GetChild(i).gameObject);
            }
        }

        listPin jsonData = JsonUtility.FromJson<listPin>(jsonFile);
        foreach (var pin in jsonData.Pins)
        {
            var instPin = Instantiate(Prefab, Level.transform);
            instPin.transform.localPosition = pin.position;
            instPin.GetComponent<ARMoveblePoint>().enabled = true;
            instPin.name = pin.name;
            try
            {
                instPin.GetComponent<Renderer>().material = Materials[nameMaterials.IndexOf(pin.name)];
            }catch(ArgumentOutOfRangeException e)
            {
                Debug.Log(pin.name);
            }

        }
    }

    public void ExportJson()
    {
        listPin PinsList = new listPin();
        for(int i = 0; i < Level.transform.childCount; i++)
        {
            var child = Level.transform.GetChild(i);
            if (child.GetComponent<ARMoveblePoint>())
            {
                PinPrefab prefab = new PinPrefab();
                prefab.material = child.GetComponent<Renderer>().material;
                prefab.position = child.transform.localPosition;
                prefab.name = child.name;
                PinsList.Pins.Add(prefab);
            }
        }
        File.WriteAllText(EditorUtility.SaveFilePanel("Export Json", "", textMeshPro.text, "json"), JsonUtility.ToJson(PinsList));
    }

    [Serializable]
    public class listPin
    {
        public List<PinPrefab> Pins = new List<PinPrefab>();
    }

    [Serializable]
    public class PinPrefab
    {
        public Vector3 position;
        public Material material;
        public string name;
    }
}
