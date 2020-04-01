using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.XR.ARFoundation;

public class SurfaceShaderSwitchManager : MonoBehaviour
{
    public List<Material> availableMaterials;
    public TMP_Dropdown materialsDropdown;

    public ARPlaneManager ARPlaneManager;
    // Start is called before the first frame update
    void Start()
    {
        RefreshMaterialsDropdown();
    }

    public void RefreshMaterialsDropdown()
    {
        materialsDropdown.onValueChanged.RemoveListener(OnMaterialDropdownChange);
        materialsDropdown.ClearOptions();

        foreach(Material m in availableMaterials)
        {
            materialsDropdown.options.Add(new TMP_Dropdown.OptionData(m.name));
        }

        materialsDropdown.onValueChanged.AddListener(OnMaterialDropdownChange);
        materialsDropdown.value = 0;
    }

    private void OnMaterialDropdownChange(int value)
    {
        ARPlaneManager.planePrefab.GetComponent<Renderer>().material = availableMaterials[value];   
        foreach (var plane in ARPlaneManager.trackables)
        {
            plane.gameObject.GetComponent<Renderer>().material = availableMaterials[value];
        }
    }
}
