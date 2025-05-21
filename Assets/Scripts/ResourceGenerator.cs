using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    private List<ResourceGenerationRuntime> activeGenerators = new();
    private BuildingType_SO buildingType;

    private void Awake()
    {
        buildingType = GetComponent<BuildingTypeHolder>().buildingType;

        if (buildingType.resourceGenerator == null) return;

        foreach (var rule in buildingType.resourceGenerator.generationRules)
        {
            activeGenerators.Add(new ResourceGenerationRuntime(rule));
        }
    }

    private void Update()
    {
        foreach (var generator in activeGenerators)
        {
            if (generator.Tick(Time.deltaTime))
            {
                ResourceManager.Instance.AddResource(generator.rule.resourceType, generator.rule.amountPerInterval);
            }
        }
    }
}
