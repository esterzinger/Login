addEventListener("load",()=> {
    getProductsFromCart();
    calcItemCount()
    calcTotalAmount()

})

const calcItemCount = () => {
    document.getElementById("itemCount").innerText="hhh"
}

const calcTotalAmount = () => {
    document.getElementById("totalAmount").innerText = "rrr"
}


const deleteFromCart = (product) => {
    console.log(product)
    const bag = JSON.parse(localStorage.getItem('bag'));
    const newBag = bag.filter(p => p.productId != product.productId )
    localStorage.setItem('bag', JSON.stringify(newBag));
    getProductsFromCart()
   /* count--;*/
    //document.getElementById("ItemsCountText").innerText = count
    
}
const displayProduct = (product) => {
    console.log(`../Images/food/${product.img}.jpg`)
    var temp = document.querySelector("#temp-row")
    var clone = temp.content.cloneNode(true);
    console.log(clone)
    clone.querySelector("img").src = `../Images/food/${product.img}.jpg`
    clone.querySelector(".itemName").innerText = product.productName;
    clone.querySelector('button').addEventListener('click', () => { deleteFromCart(product) });
    document.getElementById("items").appendChild(clone)

}

const drowproducts = (bag) => {
//document.getElementById("items").innerHTML=""
    const productToDelete = document.getElementsByClassName("item-row");
    //console.log(productToDelete)
    //productToDelete.map((p)=> { p.innerHTML = "" });
    for (let i = 0; i < productToDelete.length; i++) {
        productToDelete[i].innerHTML=""
    }
    bag.map((product) => {
        displayProduct(product)
    })
}

function getProductsFromCart() { 
    const bag = JSON.parse(localStorage.getItem('bag'));
    drowproducts(bag)
}

const createOrder = async () => {
    const cart = json.Parse(localStorage.getItem("cart"));
    const user = JSON.parse(sessionStorage.getItem("user"));
    const order = {
        userID: user.userId,
        orderItem: cart
    }
    const res = await fetch('https://localhost:44398/api/Order', {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    });
}