using UnityEngine;
using UnityEditor;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
/// 
public partial class GoogleDataAssetUtility
{
    [MenuItem("Assets/Create/Google/Sheet1")]
    public static void CreateSheet1AssetFile()
    {
        Sheet1 asset = CustomAssetUtility.CreateAsset<Sheet1>();
        asset.SheetName = "Elond_Shop";
        asset.WorksheetName = "Sheet1";
        EditorUtility.SetDirty(asset);        
    }
    
}