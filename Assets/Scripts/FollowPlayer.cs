using UnityEngine;

namespace DefaultNamespace
{
    public class FollowPlayer : MonoBehaviour
    {
        private void LateUpdate()
        {
            GameObject player = GameObject.Find("Player");
            if (player == null)
            {
                return;
            }
            Vector3 target = player.transform.position + new Vector3(0, 2.42f, -7.5f);
            transform.position = target;
        }
    }
}