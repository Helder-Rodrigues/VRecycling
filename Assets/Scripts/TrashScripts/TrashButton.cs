using UnityEngine;

public class TrashButton : MonoBehaviour
{
    public void PressButton()
    {
        print("Button pressed");
        SpawnTrash.Instance.SpawnObject(TrashManager.Instance.GetTrashList());
    }

    public void ReleaseButton()
    {
        print("Button released");
    }
}
