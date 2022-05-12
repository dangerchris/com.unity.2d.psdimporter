using UnityEditor;
using UnityEditor.AssetImporters;

namespace CritterCoast.Editor
{
    [CustomEditor(typeof(IsometricTileImporter))]
    public class IsometricTileImporterEditor : ScriptedImporterEditor
    {
        public override void OnInspectorGUI()
        {
            ApplyRevertGUI();
            base.OnInspectorGUI();
        }
    }
}