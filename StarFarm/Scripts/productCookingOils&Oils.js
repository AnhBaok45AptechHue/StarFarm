// SEARCH PRODUCTS////

var divsearch= document.getElementById("products");
var filter,input,txtValue;
function search() {
    input = document.getElementById("myInput");
    inputText = input.value.toUpperCase();
   	divsearch.innerHTML='';
    for (i = 0; i < product.length; i++){
    var x = product[i];
	var a = x.name.toUpperCase();
        txtValue = a;
        if (txtValue.search(inputText) > -1) {
		divsearch.innerHTML += 
		 	'<div class="col-4 id="card'+x.id+' ">'+
	            '<div class="card">'+
	              '<a href="productDetail.html?id='+x.id+'">'+
	              	'<img class="card-img-top" src="../image/'+x.image1+ '">'+
	              '</a>'+
	              '<div class="card-body">'+
	              	'<h6 class="font-weight-bold pt-1 recommendedcard" title="'+x.name + '">'+x.name + '</h6>'+
	    
	               '<div class="d-flex align-items-center product">'+
	                  '<span class="fa fa-star checked"></span>'+
        						'<span class="fa fa-star checked"></span>'+
        						'<span class="fa fa-star checked"></span>'+
        						'<span class="fa fa-star checked"></span>'+
        						'<span class="fa fa-star"></span>'+
	                '</div>'+
	                '<div class="d-flex align-items-center justify-content-between pt-3">'+
	                 	'<div class="col-4">'+
	                    '<div class="h5 font-weight-bold cardPrice">'+ x.price +'$</div>'+
	                    '</div>'+
	                   '<div class="col-8"><button type="button" class="btn modalToAddCard" id="'+ x.id+'"> Add to cart </button></div>'+
	                '</div>'+
	                '</div>'+
	              '</div>'+
	            '</div>'+

			'</div>';

		 } 
}
};
  




// ADD PRODUCTS////




var divProduct = document.getElementById("products");
		for (var i = 0; i < cookingOilsOils.length; i++) {
			var x = cookingOilsOils[i];
			divProduct.innerHTML += 
		 	'<div class="col-4  ">'+
	            '<div class="card">'+
	              '<a href="productDetail.html?id='+x.id+'">'+
	              	'<img class="card-img-top" id = "imageToCart" src="../image/'+x.image1+ '">'+
	              '</a>'+
	              '<div class="card-body">'+
	                '<h6 class="font-weight-bold pt-1 recommendedcard" title="'+x.name + '">'+x.name + '</h6>'+
	                '<div class="d-flex align-items-center product">'+
	                   '<span class="fa fa-star checked"></span>'+
        						'<span class="fa fa-star checked"></span>'+
        						'<span class="fa fa-star checked"></span>'+
        						'<span class="fa fa-star checked"></span>'+
        						'<span class="fa fa-star"></span>'+
	                '</div>'+
	                '<div class="d-flex align-items-center justify-content-between pt-3">'+
	                	'<div class="col-4">'+
	                    	'<div class="h5 font-weight-bold cardPrice"> '+ x.price +'$</div>'+
	                  '</div>'+
	                  '<div class="col-8"><button type="button" class="btn modalToAddCard" id="'+x.id+'"> Add to cart </button></div>'+
	                  '</div>'+
	                '</div>'+
	              '</div>'+
			'</div>';


		};




	
	





// ADD TO CART /////


$('.product-quantity input').change( function() {
  updateQuantity(this);
});

$('.product-removal button').click( function() {
  removeItem(this);
});


$('.modalToAddCard').click( function() {
  addToCart(this);
  recalculateCart()
  total();
  
});

function total(){
    var resubtotal= 0
   $('.productItemCart').each(function () {
    resubtotal += parseFloat($(this).children('.product-price').text());
   });
  var retax = resubtotal * 0.1;
  var retotal = resubtotal + retax + 6.17;
   $('.cart-subtotal').text(resubtotal.toFixed(2));  
   $('#cart-tax').text(retax.toFixed(2)); 
   $('#cart-total').text(retotal.toFixed(2)); 
};



function recalculateCart(){
   var subtotal = 0;
   $('.productItemCart').each(function () {
    subtotal += parseFloat($(this).children('.product-line-price').text());
   });
  var tax = subtotal * 0.1;
  var total = subtotal + tax + 6.17;
   $('.cart-subtotal').text(subtotal.toFixed(2));  
   $('#cart-tax').text(tax.toFixed(2)); 
   $('#cart-total').text(total.toFixed(2)); 
}


function updateQuantity(quantityInput){
  var productRow = $(quantityInput).parent().parent();
  var price = parseFloat(productRow.children('.product-price').text());
  var quantity = $(quantityInput).val();
  var linePrice = price * quantity;
  productRow.children('.product-line-price').each(function () {
      $(this).text(linePrice.toFixed(2));

  });
  recalculateCart();  
}


function removeItem(removeButton)
{

  var productRow = $(removeButton).parent().parent();
 
    $(productRow).remove();
    recalculateCart();
}



function addToCart(addButton){

   var a = $(addButton).attr("id");
   for (var i = 0; i < product.length; i++) {
      var b = product[i];
      if( a == b.id ){
   $('#modalCardDetail').append(
      '<tr class="align-middle alert border-bottom productItemCart" role="alert">'+
         '<td class="text-center">'+
            '<img class="modalpic" src="../image/'+b.image1+'" alt="">'+
         '</td>'+
         '<td>'+
            '<div>'+
               '<p class="m-0 fw-bold">'+b.name+'</p>'+
            '</div>'+
         '</td>'+
         '<td class="product-price">'+
            '<div class="fw-600 ">'+b.price+'$</div>'+
         '</td>'+
         '<td class="d-flex product-quantity"> '+
            '<input class="input" min="0" value="1" type="number" id="itemPrice"  >'+
         '</td>'+
         '<td class="product-line-price"> <span id="itemTotal"></span> $</td>'+
         '<td class="product-removal">'+
            '<button class="btn ">'+
             '<span class="fas fa-times"></span>'+
            '</button>'+
                             
         '</td>'+
      '</tr>'
      );
 }
}

$('.product-removal button').click( function() {
  removeItem(this);
});
$('.product-quantity input').change( function() {
  updateQuantity(this);
});



}

// buttonscroll to top////

var mybutton = document.getElementById("myBtn");
window.onscroll = function() {scrollFunction()};
function scrollFunction() {
  if (document.body.scrollTop > 20 || document.documentElement.scrollTop > 20) {
    mybutton.style.display = "block";
  } else {
    mybutton.style.display = "none";
  }
}
function topFunction() {
  document.body.scrollTop = 0;
  document.documentElement.scrollTop = 0;
}