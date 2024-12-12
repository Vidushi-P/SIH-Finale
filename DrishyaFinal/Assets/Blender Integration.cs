using System.Diagnostics;
using UnityEngine;

public class BlenderIntegration : MonoBehaviour
{
    public string blenderExecutablePath = @"C:\Program Files\Blender Foundation\Blender 4.2\blender.exe"; // Update this path
    public string pythonScriptPath = @"C:\Users\RAMSHARAN\OneDrive\Desktop\DRISHYA\Testing\FloorplanToBlender3d\Blender\floorplan_to_3dObject_in_blender.py"; // Update this path
    public string outputModelPath = @"C:\Users\RAMSHARAN\OneDrive\Desktop\DRISHYA\Testing\FloorplanToBlender3d\Testing"; // Update this path

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