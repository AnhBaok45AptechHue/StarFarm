namespace StarFarm.Models.ViewModel
{
    public class CartItem
    {
		public long ProductId { get; set; }
		public string ProductName { get; set; }
		public string ImageUrl { get; set; }

		public double Price { get; set; }

		public CartItem(Product product)
		{
			ProductId = (long)product.Product_Id;
			ProductName = product.Product_Name;
			ImageUrl = product.Image;
		
			Price = product.Price;
        }
		public CartItem() { }
	}
}