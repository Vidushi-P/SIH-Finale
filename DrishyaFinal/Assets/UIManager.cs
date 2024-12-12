using UnityEngine;
using UnityEngine.UI;
using System.IO;
using SFB; 

public class UIManager : MonoBehaviour
{
    public Button uploadButton;
    public Button convertButton;
    public BlenderIntegration blenderIntegration;
    private string uploadedImagePath;

    void Start()
    {
        Debug.Log("Running start method");
        uploadButton.onClick.AddListener(UploadFloorplan);
        convertButton.onClick.AddListener(ConvertFloorplanTo3D);
    }

    void UploadFloorplan()
    {
        var extensions = new[] {
        new ExtensionFilter("Image Files", "png", "jpg", "jpeg")
    };

   
    string[] paths = StandaloneFileBrowser.OpenFilePanel("Select Floorplan Image", "", extensions, false);
    
    if (paths.Length > 0)
    {
        uploadedImagePath = paths[0]; 
        Debug.Log("Selected file: " + uploadedImagePath); 
    }
    else
    {
        Debug.Log("No file selected.");
    }
    }

    void ConvertFloorplanTo3D()
    {
        if(blenderIntegration == null)
        {
        Debug.LogError("BlenderIntegration is not assigned");
        return;
        }

        if (!string.IsNullOrEmpty(uploadedImagePath))
        {
            blenderIntegration.ConvertTo3D(uploadedImagePath);
        }
        else
        {
            Debug.Log("No image uploaded.");
        }
    }
}
