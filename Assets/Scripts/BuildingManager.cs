using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    private Camera mainCamera;
    private BuildingTypeList_SO buildingTypeList;
    private BuildingType_SO buildingType;

    private void Awake()
    {
        buildingTypeList = Resources.Load<BuildingTypeList_SO>(typeof(BuildingTypeList_SO).Name);
        if (buildingTypeList == null || buildingTypeList.list.Count == 0)
        {
            Debug.LogError("Failed to load BuildingTypeList or it is empty.");
            Debug.Log(Resources.Load<BuildingTypeList_SO>(typeof(BuildingTypeList_SO).Name));
            return;
        }
        buildingType = buildingTypeList.list[0];
    }

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(buildingType.prefab, GetMouseWorldPosition(), Quaternion.identity);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            buildingType = buildingTypeList.list[0];
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            buildingType = buildingTypeList.list[1];
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        return mouseWorldPosition;
    }
}
