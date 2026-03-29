using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Lesson08ScenesAndUI
{
    public class Scene00ButtonHandler : MonoBehaviour
    {
        private Button _changeToScene01Button;
        
        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            _changeToScene01Button = root.Q<Button>("ChangeToScene01Button");
            if(_changeToScene01Button != null)
                _changeToScene01Button.clicked += ChangeToScene01;
        }
        private void OnDisable()
        {
            if(_changeToScene01Button != null)
                _changeToScene01Button.clicked -= ChangeToScene01;
        }

        private void ChangeToScene01()
        {
            print("Changing to Scene01");
            SceneManager.LoadScene(1);  // SceneManager.LoadScene("Scene01");
        }
    }
}
