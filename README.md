
# Welcome to DracoArts

![Logo](https://dracoarts-logo.s3.eu-north-1.amazonaws.com/DracoArts.png)



 # ERC721 NFT Interaction with MetaMask in Unity Webgl


This guide provides a detailed explanation of how to connect MetaMask to a Unity game using the ChainSafe SDK, then interact with an ERC721 (NFT) smart contract to:

- Fetch the connected wallet’s NFT balance

- Mint a new NFT (if the contract allows it)

# 1. Connecting MetaMask 

## How the Connection Works
- The Unity game sends a connection request to MetaMask (via WalletConnect or browser extension).

- The user approves the connection in their MetaMask mobile app or browser extension.

- Once connected, the game receives:

- The wallet address

- A Web3 provider (for signing transactions)

## Why Use MetaMask?
### Security: 
- Private keys stay in MetaMask (never exposed to Unity).

### User-Friendly: 
- Players confirm transactions directly in MetaMask.

### Cross-Platform: 
- Works on PC (browser extension) & Mobile (WalletConnect).


# Fetching NFT Balance (ERC721)
### Step-by-Step Process
- Game detects the connected wallet address from MetaMask.

- Calls the balanceOf function on the ERC721 contract.

- Displays the result (number of NFTs owned).

### Technical Details
- The balanceOf function is part of the standard ERC721 interface.

- The function takes one parameter: the wallet address.

- Returns a number (BigInteger) representing how many NFTs the wallet holds.

#### User Experience Flow

✅ Player connects wallet → Game shows NFT count

# 3. Minting a New NFT (If Supported by Contract)
## Step-by-Step Process
- Game prepares a mint transaction (requires NFT contract details).

####  MetaMask pops up for the user to:

-  Confirm gas fees

- Sign the transaction

#### Transaction is sent to the blockchain (Ethereum, Polygon, etc.).

#### Game waits for confirmation (success/fail).

#### Updated NFT balance is displayed.

## Requirements for Minting
- The ERC721 contract must have a mint function (not all NFTs allow public minting).

#### The player may need to:

- Pay gas fees (ETH/MATIC).

- Pay an additional minting fee (if required by the contract).

- Provide a Token URI (metadata link for the NFT).

#### User Experience 

✅ Player clicks "Mint" → MetaMask opens for approval → Transaction processes → New NFT appears in wallet

# 4. Security & Best Practices
### Key Security Features

🔒 MetaMask handles all private key operations (Unity never sees the private key).

🔒 Every transaction requires user approval (no auto-sending).

🔒 Gas fees are visible before signing (prevants hidden costs).

### Best Practices for Developers

✔ Always test on a testnet first (Sepolia, Mumbai).

✔ Handle transaction errors gracefully (show feedback if mint fails).


✔ Cache wallet data (avoid spamming RPC calls).

# Prerequisites
- Unity 2021.3 or later
- Project Shift on Webgl

- ChainSafe SDK installed in your Unity project
   [ChainSafe]("https://github.com/ChainSafe/web3.unity")

- Basic understanding of C# and Unity

- Ethereum wallet with testnet ETH (for transactions)





## Usage/Examples
    Erc721 Balance
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

Mint Nft Erc721

     async public void Erc721MintNft()
    {

        LoadingScreen .SetActive(true);
         tokenId=tokenIdInput.text;
        string to=PlayerPrefs.GetString("Account");
        // smart contract method to call
        string method = "publicMint";
        // abi in json format
      
        // array of arguments for contract
        string [] obj = {to,tokenId};
        string args =JsonConvert.SerializeObject(obj);
        // value in wei
        string value = "0";
        // gas limit OPTIONAL
        string gasLimit = "";
        // gas price OPTIONAL
        string gasPrice = "";
        // connects to user's browser wallet (metamask) to update contract state
        try
        {
            string response = await Web3GL.SendContract(method, erc721Abi, contract, args, value, gasLimit, gasPrice);
            Debug.Log(response);

            HashText.text=response;
             LoadingScreen .SetActive(false);
        }
        catch (Exception e)
        {
            Debug.LogException(e, this);
            
             LoadingScreen .SetActive(false);
        }
    }
## Images

 Erc721Balance
![](https://github.com/AzharKhemta/Gif-File-images/blob/main/Erc721Balance%20check.gif?raw=true)

 Erc721Mint 
 
![](https://github.com/AzharKhemta/Gif-File-images/blob/main/Erc721%20Mint%20%20Nft.gif?raw=true)
## Authors

- [@MirHamzaHasan](https://github.com/MirHamzaHasan)
- [@WebSite](https://mirhamzahasan.com)


## 🔗 Links

[![linkedin](https://img.shields.io/badge/linkedin-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/company/mir-hamza-hasan/posts/?feedView=all/)
## Documentation

[ChainSafe Docs](https://docs.gaming.chainsafe.io/)




## Tech Stack
**Client:** Unity,C#

**Plugin:** ChainSafe SDK



