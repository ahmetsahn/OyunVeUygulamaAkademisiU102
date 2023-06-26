using UnityEngine;

public class MousePosition : Singleton<MousePosition>
{
    
    public Vector2 screenCenterPoint;
    public Ray ray;
    public RaycastHit hit;

    public Vector3 GetMousePos()
    {
        screenCenterPoint = new(Screen.width / 2, Screen.height / 2);
        ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        
        if (Physics.Raycast(ray, out hit, 9999f))
        {
            return hit.point;
        }

        else
        {
            return Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // Raycast ���n�n�z�n ba�lang�� noktas�
        Vector3 raycastStartPoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        // Raycast ���n� uzunlu�unu belirleyin, burada 9999f kullan�lm��t�r
        Vector3 raycastEndPoint = raycastStartPoint + Camera.main.transform.forward * 9999f;

        // I��n� �izmek i�in Gizmos.DrawLine kullan�n
        Gizmos.DrawLine(raycastStartPoint, raycastEndPoint);

    }
}
