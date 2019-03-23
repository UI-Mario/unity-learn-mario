using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour {

	// Use this for initialization

    private static ResourceManager m_instance;
    private ResourceManager() 
    {

    }
    public static ResourceManager Instance() 
    {
        if (m_instance == null) 
        {
            m_instance = GameObject.FindObjectOfType<ResourceManager>();
            if (m_instance == null) 
            {
                GameObject go = new GameObject();
                go.name = "ResourceManager";
                m_instance = go.AddComponent<ResourceManager>();

            }

        }
            return m_instance;
    }
    public move characterCtr;
    public GameMenuUI gameMenuCtr;

    void Awake() 
    {
        characterCtr = GameObject.FindObjectOfType<move>();
        gameMenuCtr = GameObject.FindObjectOfType<GameMenuUI>();

    }
}
