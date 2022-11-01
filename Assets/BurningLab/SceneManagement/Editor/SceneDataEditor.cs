using BurningLab.SceneManagement.Database;
using BurningLab.SceneManagement.Types;
using UnityEditor;

namespace BurningLab.SceneManagement.Editor
{
    [CustomEditor(typeof(SceneData))]
    public class SceneDataEditor : UnityEditor.Editor
    {
        private SerializedProperty _sceneAssetField;
        private SerializedProperty _sceneAssetReferenceField;
        private SerializedProperty _loadPriorityField;
        private SerializedProperty _assetTypeField;
        private SerializedProperty _sceneLoadTypeField;
        private SerializedProperty _loadModeField;
        private SerializedProperty _activationModeField;

        private void OnEnable()
        {
            _sceneAssetField = serializedObject.FindProperty("_sceneAsset");
            _sceneAssetReferenceField = serializedObject.FindProperty("_sceneAssetReference");
            _loadPriorityField = serializedObject.FindProperty("_loadPriority");
            _assetTypeField = serializedObject.FindProperty("_assetType");
            _sceneLoadTypeField = serializedObject.FindProperty("_sceneLoadType");
            _loadModeField = serializedObject.FindProperty("_loadMode");
            _activationModeField = serializedObject.FindProperty("_activationMode");
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
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}