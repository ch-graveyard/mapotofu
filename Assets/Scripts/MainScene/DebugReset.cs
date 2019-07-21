using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugReset : MonoBehaviour
{
    /// <summary>
    /// Reloads current scene; for debugging purposes.
    /// </summary>
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
