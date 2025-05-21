using UnityEngine.UI;

using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System;

public class ResourcesUI : MonoBehaviour
{
    [SerializeField] private Transform resourceTemplate;

    private ResourceTypeList_SO resourceTypeList;
    private Dictionary<ResourceType_SO, Transform> resourceTypeTransformDict;

    private void Awake()
    {
        resourceTypeList = Resources.Load<ResourceTypeList_SO>(typeof(ResourceTypeList_SO).Name);
        resourceTypeTransformDict = new Dictionary<ResourceType_SO, Transform>();
        resourceTemplate.gameObject.SetActive(false);

        int index = 0;
        foreach (ResourceType_SO resourceType in resourceTypeList.list)
        {
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);

            float offsetAmount = -160f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0);

            var image = resourceTransform.GetComponentInChildren<Image>();
            var text = resourceTransform.GetComponentInChildren<TextMeshProUGUI>();

            image.sprite = resourceType.sprite;
            text.text = "0";

            resourceTypeTransformDict[resourceType] = resourceTransform;

            index++;
        }
    }

    private void Start()
    {
        ResourceManager.Instance.OnResourceAmountChanged += OnAmountChanged;
        UpdateResourceAmount();
    }

    private void OnAmountChanged(object sender, EventArgs e)
    {
        UpdateResourceAmount();
    }

    private void UpdateResourceAmount()
    {
        foreach (ResourceType_SO resourceType in resourceTypeList.list)
        {
            Transform resourceTransform = resourceTypeTransformDict[resourceType];
            var text = resourceTransform.GetComponentInChildren<TextMeshProUGUI>();
            int resourceAmount = ResourceManager.Instance.GetResourceAmount(resourceType);
            text.SetText(resourceAmount.ToString());

        }
    }

    private void OnDestroy()
    {
        ResourceManager.Instance.OnResourceAmountChanged -= OnAmountChanged;
    }
}
