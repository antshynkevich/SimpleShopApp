namespace VideoCourseProject.Models;

public class CartItem
{
    public Guid Id { get; set; }
    public ProductViewModel ProductViewModel { get; set; }
    public int Amount { get; set; }

    public decimal Cost => ProductViewModel.Cost * Amount;
}
