using UnityEngine;
using constString = ConstStrings;

public class BaseMonoBehaviour : MonoBehaviour
{
    #region Methods

    protected virtual void prtDbgLog(string str)
        => Debug.Log($"{constString.StrAppName}::{str}");

    protected virtual void prtDbgLogError(string str)
        => Debug.LogError($"{constString.StrAppName}::error::{str}");
    
    #endregion
}
