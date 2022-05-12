using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.AssetImporters;
using UnityEditor.U2D.PSD;
using UnityEngine;

namespace CritterCoast.Editor
{
    [ScriptedImporter(1, new string[0], new[] {"psd"})]
    public class IsometricTileImporter : ScriptedImporter
    {
        //configuration here
        public bool TestField;
        public int CellWidth;
        public int CellHeight;
        
        public override void OnImportAsset(AssetImportContext ctx)
        {
            var fileStream = new FileStream(ctx.assetPath, FileMode.Open, FileAccess.Read);
            var doc = PaintDotNet.Data.PhotoshopFileType.PsdLoad.Load(fileStream);     
            
            try
            {
                var psdLayers = new List<PSDLayer>();
                ExtractLayerTask.Execute(psdLayers, doc.Layers, true, new FlattenLayerData[]{}, new LayerMappingUseLayerName());

                foreach (var layer in psdLayers)
                {
                    //TODO: do some stuff
                    Debug.Log(layer.name);
                }
            }
            finally
            {
                fileStream.Close();
                if (doc != null)
                    doc.Dispose();
                UnityEngine.Profiling.Profiler.EndSample();
                EditorUtility.SetDirty(this);
            }


        }
    }
}