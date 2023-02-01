using System.IO;
using UnityEditor;
using UnityEngine;

public class AddNameSpace : UnityEditor.AssetModificationProcessor
{
    public static void OnWillCreateAsset(string path)
    {
        var rootNamespace = string.IsNullOrWhiteSpace(EditorSettings.projectGenerationRootNamespace) ?
            string.Empty : $"{EditorSettings.projectGenerationRootNamespace}";

        path = path.Replace(".meta", "");
        int index = path.LastIndexOf(".");
        if (index < 0)
            return;

        string file = path.Substring(index);
        if (file != ".cs" && file != ".js" && file != ".boo")
            return;

        string formattedNamespace = GetNamespace(path, rootNamespace);
        file = System.IO.File.ReadAllText(path);
        if (file.Contains(formattedNamespace))
            return;

        file = file.Replace(rootNamespace, formattedNamespace);

        System.IO.File.WriteAllText(path, file);
        AssetDatabase.Refresh();
    }

    private static string GetNamespace(string filePath, string rootNamespace)
    {
        filePath = filePath.Replace("Assets/Scripts/", "/")
            .Replace('/', '.')
            .Replace(' '.ToString(), string.Empty);

        var splitPath = filePath.Split('.');
        string pathWithoutFileName = string.Empty;

        for (int i = 1; i < splitPath.Length - 2; i++)
        {
            if (i == splitPath.Length - 3)
            {
                pathWithoutFileName += splitPath[i];
            }
            else
            {
            pathWithoutFileName += splitPath[i] + '.';
            }
        }

        return $"{rootNamespace}.{pathWithoutFileName}";
    }
}