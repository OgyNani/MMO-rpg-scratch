using System.Diagnostics;
using System.IO;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class BuildAutomation : MonoBehaviour
{
    private static string buildFolderPath = "D:/GAMEBUILD";
    private static string archiveFilePath = "D:/GAMEBUILD.rar";

    [MenuItem("Tools/Build and Archive Game")]
    public static void BuildAndArchive()
    {
        UnityEngine.Debug.Log("Starting automated build...");

        if (File.Exists(archiveFilePath))
        {
            File.Delete(archiveFilePath);
        }

        string exePath = buildFolderPath + "/hopon.exe";

        if (File.Exists(exePath))
        {
            File.Delete(exePath);
        }

        Thread.Sleep(500);

        // Получаем все сцены из Build Settings
        string[] scenes = GetScenesFromBuildSettings();

        UnityEngine.Debug.Log("Building project...");
        BuildPipeline.BuildPlayer(scenes, exePath, BuildTarget.StandaloneWindows, BuildOptions.None);

        UnityEngine.Debug.Log("Creating archive...");
        CreateArchive();

        UnityEngine.Debug.Log("Automated build completed successfully.");
    }

    private static string[] GetScenesFromBuildSettings()
    {
        int sceneCount = EditorBuildSettings.scenes.Length;
        string[] scenes = new string[sceneCount];
        for (int i = 0; i < sceneCount; i++)
        {
            scenes[i] = EditorBuildSettings.scenes[i].path;
        }
        return scenes;
    }

    private static void CreateArchive()
    {
        string winrarPath = "C:/Program Files/WinRAR/WinRAR.exe";

        if (!File.Exists(winrarPath))
        {
            UnityEngine.Debug.LogError("WinRAR не найден по указанному пути.");
            return;
        }

        ProcessStartInfo rarProcessInfo = new ProcessStartInfo
        {
            FileName = winrarPath,
            Arguments = $"a -r \"{archiveFilePath}\" \"{buildFolderPath}\"",
            WindowStyle = ProcessWindowStyle.Hidden
        };

        using (Process rarProcess = Process.Start(rarProcessInfo))
        {
            rarProcess.WaitForExit();
        }

        UnityEngine.Debug.Log("Build archived successfully.");
    }
}
