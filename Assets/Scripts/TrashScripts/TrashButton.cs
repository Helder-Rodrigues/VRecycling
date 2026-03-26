using UnityEngine;

public class TrashButton : MonoBehaviour
{
    public void PressButton()
    {
        print("Button pressed");
        TrashManager.Instance.EmptyTrashList();
    }

    public void ReleaseButton()
    {
        print("Button released");
    }
}
