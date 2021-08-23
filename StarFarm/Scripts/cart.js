


$('.product-quantity input').change( function() {
    updateQuantity(this);
    
});



function total() {
    updateQuantity(1);
    var subtotal= 0
   $('.product').each(function () {
       subtotal += parseFloat($(this).children.children('.product-price').text());
   });
  var tax = subtotal * 0.1;
    var total = subtotal + tax + 6.17;
   $('.cart-subtotal').text(subtotal.toFixed(2));  
   $('#cart-tax').text(tax.toFixed(2)); 
   $('#cart-total').text(total.toFixed(2)); 
};



function recalculateCart(){
   var subtotal = 0;
   $('.product').each(function () {
       subtotal += parseFloat($(this).children.children('.product-price').text());
   });
  var tax = subtotal * 0.1;
  var total = subtotal + tax + 6.17;
   $('.cart-subtotal').text(subtotal.toFixed(2));  
   $('#cart-tax').text(tax.toFixed(2)); 
   $('#cart-total').text(total.toFixed(2)); 
}


function updateQuantity(quantityInput) {
    var productRow = $(quantityInput).parent().parent();
    var price = parseFloat(productRow.children.children('.product-price').text());
  var quantity = $(quantityInput).val();
  var linePrice = price * quantity;
    productRow.children.children('.product-line-price').each(function () {
      $(this).text(linePrice.toFixed(2));

  });
  recalculateCart();  
}











	
	
