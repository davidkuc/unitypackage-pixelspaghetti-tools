using UnityEditor;

public class AddNameSpace : UnityEditor.AssetModificationProcessor
{
    public static void OnWillCreateAsset(string path)
    {
        path = path.Replace(".meta", "");
        int index = path.LastIndexOf(".");
        if (index < 0) return;
        string file = path.Substring(index);
        if (file != ".cs" && file != ".js" && file != ".boo") return;
        file = System.IO.File.ReadAllText(path);

        string rootNamespace = string.IsNullOrWhiteSpace(EditorSettings.projectGenerationRootNamespace) ?
          string.Empty : $"{EditorSettings.projectGenerationRootNamespace}.";
        file = file.Replace("#NAMESPACE#", rootNamespace);

        System.IO.File.WriteAllText(path, file);
        AssetDatabase.Refresh();
    }
}