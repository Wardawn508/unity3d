using UnityEngine;
using System.Collections;
using UnityEditor;

public class EditorAdvan : MonoBehaviour
{



    [MenuItem("FPS Tools/Game Systems/ BuildWeaponSystems")]
    static void MakeFPSweaponAsset()
    {
        WeaponBaseSystems asset = ScriptableObject.CreateInstance<WeaponBaseSystems>();
        AssetDatabase.CreateAsset(asset, "Assets/AdvanceScripting/WeaponSystem.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("FPS Tools/Game Systems/ WeaponMovementsystems")]
    static void MakeFPSMovmentAsset()
    {
        WeaponMovements assetm = ScriptableObject.CreateInstance<WeaponMovements>();
        AssetDatabase.CreateAsset(assetm, "Assets/AdvanceScripting/WeaponMovements.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("FPS Tools/Game Systems/LifeSystems")]
    static void LifemanagertAsset()
    {
        LifeManager assetLife = ScriptableObject.CreateInstance<LifeManager>();
        AssetDatabase.CreateAsset(assetLife, "Assets/AdvanceScripting/LIfeManager.asset");
        AssetDatabase.SaveAssets();
    }
    [MenuItem("FPS Tools/Game Systems/FireSystems")]
    static void MakeFPSplayerInvetoryAsset()
    {
        Shots assetInv = ScriptableObject.CreateInstance<Shots>();
        Fullauto assetInv1 = ScriptableObject.CreateInstance<Fullauto>();
        brust assetInv2 = ScriptableObject.CreateInstance<brust>();
        shotgun assetInv3 = ScriptableObject.CreateInstance<shotgun>();
        AssetDatabase.CreateAsset(assetInv, "Assets/Shots.asset");
        AssetDatabase.CreateAsset(assetInv1, "Assets/Fullauto.asset");
        AssetDatabase.CreateAsset(assetInv2, "Assets/brust.asset");
        AssetDatabase.CreateAsset(assetInv3, "Assets/shotgun.asset");
        AssetDatabase.SaveAssets();
    }
    [MenuItem("FPS Tools/Game Systems/playerSystems")]
    static void MakeFPSplayerStatesAsset()
    {
        indieBehaviourScript assetInv = ScriptableObject.CreateInstance<indieBehaviourScript>();
        PlayerWalking assetInv1 = ScriptableObject.CreateInstance<PlayerWalking>();
        PlayerRunning assetInv2 = ScriptableObject.CreateInstance<PlayerRunning>();
        PlayerJumbing assetInv3 = ScriptableObject.CreateInstance<PlayerJumbing>();
        AssetDatabase.CreateAsset(assetInv, "Assets/indieBehaviourScript.asset");
        AssetDatabase.CreateAsset(assetInv1, "Assets/PlayerWalking.asset");
        AssetDatabase.CreateAsset(assetInv2, "Assets/PlayerRunning.asset");
        AssetDatabase.CreateAsset(assetInv3, "Assets/PlayerJumbing.asset");
        AssetDatabase.SaveAssets();

    }
}
