namespace _App._MainGame.Scripts.Item.Presenter
{
    public class ItemPresenter : IItemPresenter
    {
        private readonly ItemUiStoreSpawner _itemUiStoreSpawner;
        private readonly TamagotchiModel _tamagotchiModel;
        
        public ItemPresenter(TamagotchiModel tamagotchiModel, ItemUiStoreSpawner itemUiStoreSpawner)
        {
            _tamagotchiModel = tamagotchiModel;
            _itemUiStoreSpawner = itemUiStoreSpawner;
        }
        
        public bool IsItemCanBuy(ItemId itemId)
        {
            return _tamagotchiModel.Coins >= itemId.Price;
        }
    }
}