using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour
{

    [SerializeField]
    private uint roomSize = 6;

    private string roomName;

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void SetRoomName(string _name)
    {
        Debug.Log("seteando");
        roomName = _name;
        Debug.Log("jum: " + roomName);
    }

    public void CreateRoom()
    {
        
        if (roomName != "" && roomName != null)
        {
            Debug.Log("Creando");
            Debug.Log("Creating Room: " + roomName + " with room for " + roomSize + " players.");
            networkManager.matchMaker.CreateMatch(roomName, roomSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
        }
    }

}