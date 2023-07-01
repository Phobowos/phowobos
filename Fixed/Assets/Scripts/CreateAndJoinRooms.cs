using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;

    // All of these functions are from Photon.
    public void CreateRoom()
    {
        // This function creates a room with the text of the createInput UI.
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        // Same as createRoom(), but joins the room with the text.
        PhotonNetwork.JoinRoom(joinInput.text);
    }

    public override void OnJoinedRoom()
    {
        // When you join the room, it will take you to the scene called GameScene. Must use the name of the Scene. Using Unity SceneManager does not work. Idk why.
        PhotonNetwork.LoadLevel("GameScene");
    }
}
