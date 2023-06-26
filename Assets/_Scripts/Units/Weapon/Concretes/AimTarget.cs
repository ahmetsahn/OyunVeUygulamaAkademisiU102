using UnityEngine;

public class AimTarget : MousePosition
{
    private void Update()
    {
        transform.position =GetMousePos();
    }
}
