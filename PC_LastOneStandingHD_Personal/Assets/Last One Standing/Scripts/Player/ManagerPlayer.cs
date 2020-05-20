using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
public class ManagerPlayer : MonoBehaviour
{
    [SerializeField] internal ScriptablePlayer scriptablePlayer;

    private void Update()
    {
        MovementPlayer();
    }

    internal void MovementPlayer()
    {
        scriptablePlayer.horizontal = scriptablePlayer.directionPlayer.x;
        scriptablePlayer.vertical = scriptablePlayer.directionPlayer.y;

        scriptablePlayer.movementPlayer = new Vector3();
        scriptablePlayer.movementPlayer.Set(scriptablePlayer.horizontal,0, scriptablePlayer.vertical);

        transform.Translate(scriptablePlayer.movementPlayer * scriptablePlayer.speedPlayer * Time.deltaTime);
    }
}
