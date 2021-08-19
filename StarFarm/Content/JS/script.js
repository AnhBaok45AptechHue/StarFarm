$(document).ready(function() {
	$(window).scroll(function(event) {
		var pos_body = $('html,body').scrollTop();
		var pos_img2 = $('.content img:nth-child(2)').offset().top;
		var pos_img3 = $('.content img:nth-child(3)').offset().top;
		console.log(pos_img2);
		// console.log(pos_body);
		if(pos_body>20){
			$('.menu').addClass('co-dinh-menu');
		}
		else {
			$('.menu').removeClass('co-dinh-menu');
		}
		if(pos_body>1200){
			$('.back-to-top').addClass('hien-ra');
		}
		else{
			$('.back-to-top').removeClass('hien-ra');
		}
		if(pos_body>pos_img2-200){
			$('.content img:nth-child(2)').addClass('fadeInLeft animated');
		}
		if(pos_body>pos_img3-200){
			$('.content img:nth-child(3)').addClass('fadeInRight animated');
		}
	});
	$('.back-to-top').click(function(event) {
		$('html,body').animate({
			scrollTop: 0},
			500);
	});
});