using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using GDataDB;
using GDataDB.Linq;

using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
[CustomEditor(typeof(Sheet1))]
public class Sheet1Editor : BaseGoogleEditor<Sheet1>
{	    
    public override bool Load()
    {        
        Sheet1 targetData = target as Sheet1;
        
        var client = new DatabaseClient("", "");
        string error = string.Empty;
        var db = client.GetDatabase(targetData.SheetName, ref error);	
        var table = db.GetTable<Sheet1Data>(targetData.WorksheetName) ?? db.CreateTable<Sheet1Data>(targetData.WorksheetName);
        
        List<Sheet1Data> myDataList = new List<Sheet1Data>();
        
        var all = table.FindAll();
        foreach(var elem in all)
        {
            Sheet1Data data = new Sheet1Data();
            
            data = Cloner.DeepCopy<Sheet1Data>(elem.Element);
            myDataList.Add(data);
        }
                
        targetData.dataArray = myDataList.ToArray();
        
        EditorUtility.SetDirty(targetData);
        AssetDatabase.SaveAssets();
        
        return true;
    }
}
