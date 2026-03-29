using UnityEngine;
using UnityEngine.UI;

public class color : MonoBehaviour
{
    public void Correct()
    {
        ChangeColourtoGreen();
    }
    public void Wrong()
    {
        ChangeColourtoRed();
    }
    public void ChangeColourtoRed()
    {
        gameObject.GetComponent<Image>().color = Color.red;
    }

    public void ChangeColourtoGreen()
    {
        gameObject.GetComponent<Image>().color = Color.green;
    }
}
