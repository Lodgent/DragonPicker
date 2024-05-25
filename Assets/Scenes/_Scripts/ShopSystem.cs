using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
{
    [System.Serializable]
    class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchased;
    }

    [SerializeField] List<ShopItem> ShopItems;
    [SerializeField] Transform ShopScrollView;
    GameObject ItemTemplate;
    GameObject g;
    
    // Start is called before the first frame update
    void Start()
    {
        ItemTemplate = ShopScrollView.GetChild(0).gameObject;
        int len= ShopItems.Count;
        for (int i = 0; i < len; i++)
        {
            g = Instantiate (ItemTemplate, ShopScrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItems[i].Image;
            g.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text= ShopItems[i].Price.ToString();
            g.transform.GetChild(2).GetComponent<Button>().interactable= !ShopItems[i].IsPurchased;
        }
        Destroy(ItemTemplate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
