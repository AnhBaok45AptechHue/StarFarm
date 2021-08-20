namespace StarFarm.Models.ViewModel
{
    public class CartItem
    {
		public long ProductId { get; set; }
		public string ProductName { get; set; }
		public string ImageUrl { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }

		public CartItem(Product product, int quantity)
		{
			ProductId = (long)product.Product_Id;
			ProductName = product.Product_Name;
			ImageUrl = product.Image;
			Quantity = quantity;
			Price = product.Price;
        }
		public CartItem() { }
	}
}