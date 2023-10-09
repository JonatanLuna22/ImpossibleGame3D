using UnityEngine;

namespace DefaultNamespace
{
    public class FollowPlayer : MonoBehaviour
    {
        private void LateUpdate()
        {
            GameObject player = GameObject.Find("Player");
            Vector3 target = player.transform.position + new Vector3(0, 0, -10);
            transform.position = target;
        }
    }
}