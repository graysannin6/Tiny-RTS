using UnityEngine;

[System.Serializable]
public class ResourceGenerationRule
{
    public ResourceType_SO resourceType;
    public float generationInterval;
    public int amountPerInterval = 1;
}

