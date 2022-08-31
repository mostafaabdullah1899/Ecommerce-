
var CartItems=[];
if (!sessionStorage.getItem('cart')){
    sessionStorage.setItem('cart', JSON.stringify(CartItems));
} 

var Ids = [];
if (!sessionStorage.getItem('ids')) {
    sessionStorage.setItem('ids', JSON.stringify(Ids));
} 


function addToCart(value){
    CartItems= JSON.parse(sessionStorage.getItem('cart'));
    Ids = JSON.parse(sessionStorage.getItem('ids'));

    CartItems.push(
        {   'value':value,
            'title':document.getElementById('title'+value).innerText,
            'price':document.getElementById('price'+value).innerText,
            'img':document.getElementById('img'+value).src
        }
    );

    Ids.push({
        'id': document.getElementById('price' + value).innerText
    });
    CartItems.sort((a, b) =>  (a.title.length+parseInt(a.value))-(b.title.length+parseInt(b.value)) );
    sessionStorage.setItem('cart', JSON.stringify(CartItems));    
}

function buyNow(value){
  addToCart(value);
  window.open("cart.html","_self")
} 

