using System.IO;
using System.Linq;
using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Utils;
using UnityEditor;
using UnityEngine;

namespace BurningLab.SceneManagement.Editor
{
    public class ScenePostProcessor : AssetPostprocessor
    {
        public static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (importedAssets.Length != 0)
            {
                foreach (string importedAsset in importedAssets)
                {
                    if (Path.GetExtension(importedAsset) == ".unity")
                    {
                        SceneData newSceneData = ScriptableObject.CreateInstance<SceneData>();
                        newSceneData.SetScene(importedAsset);
                        
                        string assetName = Path.GetFileNameWithoutExtension(importedAsset) + " Scene Data.asset";
                        string sceneName = Path.GetFileName(importedAsset);
                        string assetPath = importedAsset.Replace(sceneName, assetName);
                        
                        string[] databases = AssetDatabase.FindAssets("t: ScenesDatabase");
                        if (databases.Length == 0)
                        {
                            throw new FileNotFoundException("Not found scenes database in project. Please create scenes database asset in any place in project. Create -> Burning-Lab -> Scene Management -> Scenes Database");
                        }

                        string scenesDatabasePath = AssetDatabase.GUIDToAssetPath(databases.First());
                        ScenesDatabase scenesDatabase = AssetDatabase.LoadAssetAtPath<ScenesDatabase>(scenesDatabasePath);
                        if (scenesDatabase.SceneDataExists(importedAsset))
                            return;

                        AssetDatabase.CreateAsset(newSceneData, assetPath);

                        SceneData createdSceneData = AssetDatabase.LoadAssetAtPath<SceneData>(assetPath);
                        scenesDatabase.Scenes.Add(createdSceneData);
                        
#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
                        UnityConsole.PrintEditorLog("ScenePostProcessor", "OnPostprocessAllAssets", "New scene data created: " + assetPath);
#endif
                    }
                }
            }

            if (deletedAssets.Length != 0)
            {
                foreach (string deletedAsset in deletedAssets)
                {
                    if (Path.GetExtension(deletedAsset) == ".unity")
                    {
                        
                        
                        string[] databases = AssetDatabase.FindAssets("t: ScenesDatabase");
                        if (databases.Length == 0)
                        {
                            throw new FileNotFoundException("Not found scenes database in project. Please create scenes database asset in any place in project. Create -> Burning-Lab -> Scene Management -> Scenes Database");
                        }

                        string scenesDatabasePath = AssetDatabase.GUIDToAssetPath(databases.First());
                        ScenesDatabase scenesDatabase = AssetDatabase.LoadAssetAtPath<ScenesDatabase>(scenesDatabasePath);
                        if (scenesDatabase.SceneDataExists(deletedAsset) == false)
                            return;

                        SceneData sceneData = scenesDatabase.Scenes.Find(sd => sd.SceneAssetPath == deletedAsset);
                        
                        if (sceneData != null)
                        {
                            scenesDatabase.Scenes.Remove(sceneData);
                            string assetPath = AssetDatabase.GetAssetPath(sceneData);
                            AssetDatabase.DeleteAsset(assetPath);

#if DEBUG_BURNING_LAB_SDK || DEBUG_SCENES_SWITCHER
                            UnityConsole.PrintEditorLog("ScenePostProcessor", "OnPostprocessAllAssets", "Deleted scene data asset: " + assetPath);
#endif
                        }
                    }
                }
            }
        }
    }
}