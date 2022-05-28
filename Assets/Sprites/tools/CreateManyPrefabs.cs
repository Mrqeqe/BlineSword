using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class CreateManyPrefabs 
{
    // Start is called before the first frame update
   // [MenuItem("CustomerTools/Create Prefab")]
    //static void createprefab()
    //{
    //    // keep track of the currently selected gameobject(s)
    //    gameobject[] objectarray = selection.gameobjects;

    //    // loop through every gameobject in the array above
    //    foreach (gameobject gameobject in objectarray)
    //    {
    //        // create folder prefabs and set the path as within the prefabs folder,
    //        // and name it as the gameobject's name with the .prefab format
    //        if (!directory.exists("assets/prefabs"))
    //            assetdatabase.createfolder("assets", "prefabs");
    //        string localpath = "assets/prefabs/" + gameobject.name + ".prefab";

    //        // make sure the file name is unique, in case an existing prefab has the same name.
    //        localpath = assetdatabase.generateuniqueassetpath(localpath);

    //        // create the new prefab and log whether prefab was saved successfully.
    //        bool prefabsuccess;
    //        prefabutility.saveasprefabasset(gameobject, localpath, out prefabsuccess);
    //        if (prefabsuccess == true)
    //            debug.log("prefab was saved successfully");
    //        else
    //            debug.log("prefab failed to save" + prefabsuccess);
    //    }
    //}

}
