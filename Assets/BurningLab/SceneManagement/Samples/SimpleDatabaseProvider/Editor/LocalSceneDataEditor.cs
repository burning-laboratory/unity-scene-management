using BurningLab.SceneManagement.Types;
using UnityEditor;

namespace BurningLab.SceneManagement.Extensions.LocalScenesDatabaseExtension.Editor
{
    /// <summary>
    /// Local scene data editor.
    /// </summary>
    [CustomEditor(typeof(LocalSceneData))]
    public class LocalSceneDataEditor : UnityEditor.Editor
    {
        /// <summary>
        /// Reference to scene asset field.
        /// </summary>
        private SerializedProperty _sceneAssetField;
        private SerializedProperty _sceneAssetReferenceField;
        private SerializedProperty _loadPriorityField;
        private SerializedProperty _assetTypeField;
        private SerializedProperty _sceneLoadTypeField;
        private SerializedProperty _loadModeField;
        private SerializedProperty _activationModeField;
        private SerializedProperty _sceneReloadPolicy;
        
        private void OnEnable()
        {
            _sceneAssetField = serializedObject.FindProperty("_sceneAsset");
            _sceneAssetReferenceField = serializedObject.FindProperty("_sceneAssetReference");
            _loadPriorityField = serializedObject.FindProperty("_loadPriority");
            _assetTypeField = serializedObject.FindProperty("_assetType");
            _sceneLoadTypeField = serializedObject.FindProperty("_sceneLoadType");
            _loadModeField = serializedObject.FindProperty("_loadMode");
            _activationModeField = serializedObject.FindProperty("_activationMode");
            _sceneReloadPolicy = serializedObject.FindProperty("_sceneReloadPolicy");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            SceneAssetType sceneAssetType = (SceneAssetType) _assetTypeField.enumValueIndex;

            EditorGUILayout.LabelField("Settings", EditorStyles.boldLabel);
            
            switch (sceneAssetType)
            {
                case SceneAssetType.LocalAsset:
                    EditorGUILayout.PropertyField(_sceneAssetField);
                    break;
                
                case SceneAssetType.AddressableAsset:
                    EditorGUILayout.PropertyField(_sceneAssetReferenceField);
                    break;
            }

            EditorGUILayout.PropertyField(_loadPriorityField);
            EditorGUILayout.PropertyField(_assetTypeField);
            EditorGUILayout.PropertyField(_sceneLoadTypeField);
            EditorGUILayout.PropertyField(_loadModeField);
            EditorGUILayout.PropertyField(_activationModeField);

            EditorGUILayout.PropertyField(_sceneReloadPolicy);
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}