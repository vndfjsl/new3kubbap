using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerHeartState // 플레이어 불안정상태
{
    Normal,
    Unstable,
    Fear,
    Revenge
}

public class PlayerState : MonoBehaviour
{
    private PlayerMove playerMove;

    public PlayerHeartState playerState = PlayerHeartState.Normal;
    private readonly int[] stateSpeeds = new int[4] { 15, 12, 8, 12 };

    private void Awake()
    {
        playerMove = GetComponent<PlayerMove>();
    }

    public void SetPlayerState(PlayerHeartState state)
    {
        playerState = state;
        playerMove.moveSpeed = stateSpeeds[(int)playerState];
        UIManager.instance.ChangeBackground(state);
    }
}
