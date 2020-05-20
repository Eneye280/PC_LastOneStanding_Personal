using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInput))]
public class ManagerPlayer : MonoBehaviour
{
    [SerializeField] internal ScriptablePlayer scriptablePlayer;

    private void Awake()
    {
        scriptablePlayer.namePlayer = gameObject.name;
    }
    private void Update()
    {
        MovementPlayer();
    }

    internal void MovementPlayer()
    {
        if(GameManager.instance.modeGame == ModeGame.gamePlay)
        {
            scriptablePlayer.horizontal = scriptablePlayer.directionPlayer.x;
            scriptablePlayer.vertical = scriptablePlayer.directionPlayer.y;

            scriptablePlayer.movementPlayer = new Vector3();
            scriptablePlayer.movementPlayer.Set(/*scriptablePlayer.horizontal*/0, 0, scriptablePlayer.vertical);

            transform.Translate(scriptablePlayer.movementPlayer * scriptablePlayer.speedPlayerMovement * Time.deltaTime);

            //scriptablePlayer.vertical *= Time.deltaTime;
            transform.Rotate(0, scriptablePlayer.horizontal * scriptablePlayer.speedPlayerRotation * Time.deltaTime, 0);

        }
    }
}
