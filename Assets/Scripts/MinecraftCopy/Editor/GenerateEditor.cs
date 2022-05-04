using UnityEditor;
using UnityEngine;

namespace MinecraftCopy.Editor
{
    [CustomEditor(typeof(Generate))]
    public class GenerateEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var t = target as Generate;

            // generate single cube
            if (GUILayout.Button("Generate Single Cube")) t.GenerateSingleCube();

            // generate single chunk
            if (GUILayout.Button("Generate Single Chunk")) t.GenerateSingleChunk();
        }
    }
}