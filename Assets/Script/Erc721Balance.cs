using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Web3Unity.Scripts.Library.ETHEREUEM.EIP;

public class Erc721Balance : MonoBehaviour
{
    [SerializeField]
    private string contractAddress = "0x9123541E259125657F03D7AD2A7D1a8Ec79375BA";
    [SerializeField]
    private string walletAddress;

    public Button BalanceBtn;
    public Text balanceText;
    public GameObject LoadingScreen;


     void  Start()
    {

       walletAddress = PlayerPrefs.GetString("Account");
        BalanceBtn.onClick.AddListener(BalanceErc721);
      
    }

    private async void BalanceErc721()
    {
         LoadingScreen.SetActive(true);
        BigInteger balance = await ERC721.BalanceOf(contractAddress, walletAddress);
        Debug.Log(balance);
        LoadingScreen.SetActive(false);
        balanceText.text=balance.ToString();


    }
}
