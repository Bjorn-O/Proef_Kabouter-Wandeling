using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    [SerializeField] private int currentIndex = 0;
    
    
    
    public void SwitchScene()
    {
        switch (currentIndex)
        {
            case 0:
                currentIndex = 1;
                SceneManager.LoadScene(currentIndex);
                break;
            case 1:
                currentIndex = 0;
                SceneManager.LoadScene(currentIndex);
                break;
        }
    }
}
