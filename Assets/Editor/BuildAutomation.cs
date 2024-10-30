using System.Diagnostics;
using System.IO;
using UnityEditor;
using UnityEngine;

public class BuildAutomation : MonoBehaviour
{
    private static string buildFolderPath = "D:/GAMEBUILD";
    private static string archiveFilePath = "D:/GAMEBUILD.rar";

    [MenuItem("Tools/Build and Archive Game")]
    public static void BuildAndArchive()
    {
        // 1. ������� ����� ����������
        if (Directory.Exists(buildFolderPath))
        {
            Directory.Delete(buildFolderPath, true);
        }

        // 2. �������� ������� ������
        if (File.Exists(archiveFilePath))
        {
            File.Delete(archiveFilePath);
        }

        // 3. �������� ����� ����� ��� �����
        Directory.CreateDirectory(buildFolderPath);

        // 4. ���������� �����
        string[] scenes = { "Assets/Scenes/MainMenu.unity", "Assets/Scenes/World.unity", "Assets/Scenes/MainWorld.unity" };
        BuildPipeline.BuildPlayer(scenes, buildFolderPath + "/GAME.exe", BuildTarget.StandaloneWindows, BuildOptions.None);

        // 5. ��������� � ������� WinRAR
        CreateArchive();
    }

    private static void CreateArchive()
    {
        string winrarPath = "C:/Program Files/WinRAR/WinRAR.exe";

        if (!File.Exists(winrarPath))
        {
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
    }
}
