using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public void hoverstart()
    {
        transform.localScale = Vector3.one * 1.1f;
    }
    public void hoverend()
    {
        transform.localScale = Vector3.one;
    }
    public void clickstart()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material.color = Color.grey;
    }
    public void clickend()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material.color = Color.white;
    }
    public void click()
    {
        
    }
    
}