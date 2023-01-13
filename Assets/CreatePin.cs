using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreatePin : MonoBehaviour
{
    public GameObject Prefab;
    public GameObject Level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDowntest()
    {
        Instantiate(Prefab, Level.transform);
    }
}
