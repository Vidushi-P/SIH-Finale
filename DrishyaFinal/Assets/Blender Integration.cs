using System.Diagnostics;
using UnityEngine;

public class BlenderIntegration : MonoBehaviour
{
    public string blenderExecutablePath = @"C:\Path\To\blender.exe"; // Update this path
    public string pythonScriptPath = @"C:\Path\To\your\floorplanToBlender3d.py"; // Update this path
    public string outputModelPath = @"C:\Path\To\output\model.fbx"; // Update this path

    public void ConvertTo3D(string inputImagePath)
    {
        string arguments = $"--background --python {pythonScriptPath} -- {inputImagePath} {outputModelPath}";

        ProcessStartInfo startInfo = new ProcessStartInfo()
        {
            FileName = blenderExecutablePath,
            Arguments = arguments,
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        Process process = Process.Start(startInfo);
        process.WaitForExit();
       
    }
}