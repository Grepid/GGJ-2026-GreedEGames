using UnityEngine;

public class CustomerManager : Singleton<CustomerManager> 
{
    private void Start()
    {
        CustomerOrder order = new(new(OrderDifficulty.Easy,Mask.Base.Square),new(OrderDifficulty.Medium,Mask.Material.Gold),new(OrderDifficulty.Hard,Mask.Feather.Red));
        print(order.OrderText);
    }
}
