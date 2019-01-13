var x = 0;
var s = "";



var theForm = $("#theForm");
theForm.hide();

//var form = document.getElementById("theForm");
//form.hidden = true;

var button = $("#buyButton");
button.on("click", function () {
    console.log("Ved at købe genstand");
});

var productInfo = $(".product-props li");
productInfo.on("click", function () {
    console.log($(this).text());
});
