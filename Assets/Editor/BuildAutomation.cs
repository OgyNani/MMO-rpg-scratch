using System.Diagnostics;
using System.IO;
using System.Threading;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BuildAutomation : MonoBehaviour
{
    private static string buildFolderPath = "D:/GAMEBUILD";
    private static string archiveFilePath = "D:/GAMEBUILD.rar";

    [MenuItem("Tools/Build and Archive Game")]
    public static void BuildAndArchive()
    {
        UnityEngine.Debug.Log("Starting automated build...");

        // �������������� ���������� ���� ���� � �������
        SaveAllScenesAndAssets();

        // �������� ������� ������, ���� �� ����������
        if (File.Exists(archiveFilePath))
        {
            File.Delete(archiveFilePath);
        }

        string exePath = buildFolderPath + "/hopon.exe";

        // �������� ������� ������������ �����, ���� �� ����������
        if (File.Exists(exePath))
        {
            File.Delete(exePath);
        }

        // ��������� �������� ����� ������
        Thread.Sleep(500);

        string[] scenes = { "Assets/Scenes/MainMenu.unity", "Assets/Scenes/World.unity", "Assets/Scenes/MainWorld.unity" };

        UnityEngine.Debug.Log("Building project...");
        BuildPipeline.BuildPlayer(scenes, exePath, BuildTarget.StandaloneWindows, BuildOptions.None);

        UnityEngine.Debug.Log("Creating archive...");
        CreateArchive();

        UnityEngine.Debug.Log("Automated build completed successfully.");
    }

    private static void SaveAllScenesAndAssets()
    {
        // ��������� ��� ����� � ������
        for (int i = 0; i < EditorSceneManager.sceneCount; i++)
        {
            var scene = EditorSceneManager.GetSceneAt(i);
            if (scene.isDirty)
            {
                EditorSceneManager.SaveScene(scene);
            }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        UnityEngine.Debug.Log("All scenes and assets saved.");
    }

    private static void CreateArchive()
    {
        string winrarPath = "C:/Program Files/WinRAR/WinRAR.exe";

        if (!File.Exists(winrarPath))
        {
            UnityEngine.Debug.LogError("WinRAR �� ������ �� ���������� ����.");
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
