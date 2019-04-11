using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReadSceneNames : MonoBehaviour
{
    public string[] scenes;
#if UNITY_EDITOR
    private static string[] ReadNames()
    {
        List<string> temp = new List<string>();
        foreach (UnityEditor.EditorBuildSettingsScene S in UnityEditor.EditorBuildSettings.scenes)
        {
            //
            string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
            name = name.Substring(0,name.LastIndexOf('.'));
            //
            if (S.enabled)
            {
                //string name = S.path.Substring(S.path.LastIndexOf('/') + 1);
                S.path.Substring(S.path.LastIndexOf('/') + 1);
                temp.Add(name);
            }
        }
        //
        foreach (string scene in temp.ToArray())
        {
            Debug.Log("'" + scene + "' was added to the list of scenes." );
        }
        //
        return temp.ToArray();
    }

    [UnityEditor.MenuItem("ReadSceneNames/Update Scene Names")]
    private static void UpdateNames(UnityEditor.MenuCommand command)
    {
        ReadSceneNames context = (ReadSceneNames)command.context;
        context.scenes = ReadNames();
    }

    private void Reset()
    {
        scenes = ReadNames();
    }
#endif
}