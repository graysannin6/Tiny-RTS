using System;
using System.Collections.Generic;
using UnityEngine;


public class ResourceManager : MonoBehaviour
{

    public static ResourceManager Instance { get; private set; }

    public event EventHandler OnResourceAmountChanged;

    private Dictionary<ResourceType_SO, int> resourceAmountDictionnary;

    void Awake()
    {
        Instance = this;

        resourceAmountDictionnary = new Dictionary<ResourceType_SO, int>();

        ResourceTypeList_SO resourceTypeList = Resources.Load<ResourceTypeList_SO>(typeof(ResourceTypeList_SO).Name);

        foreach (ResourceType_SO resourceType in resourceTypeList.list)
        {
            resourceAmountDictionnary[resourceType] = 0;
        }
        TestLogResourceAmountDictionnary();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ResourceTypeList_SO resourceTypeList = Resources.Load<ResourceTypeList_SO>(typeof(ResourceTypeList_SO).Name);
            AddResource(resourceTypeList.list[0], 10);
            TestLogResourceAmountDictionnary();
        }
    }

    private void TestLogResourceAmountDictionnary()
    {
        foreach (ResourceType_SO item in resourceAmountDictionnary.Keys)
        {
            Debug.Log(item.nameString + ": " + resourceAmountDictionnary[item]);
        }
    }

    public void AddResource(ResourceType_SO resourceType, int amount)
    {
        resourceAmountDictionnary[resourceType] += amount;

        OnResourceAmountChanged?.Invoke(this, EventArgs.Empty);

        TestLogResourceAmountDictionnary();
    }

    public int GetResourceAmount(ResourceType_SO resource)
    {
        return resourceAmountDictionnary[resource];
    }
}
