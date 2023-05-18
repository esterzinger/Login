addEventListener("load",()=> {
    getProductsFromCart();
    calcItemCount()
    calcTotalAmount()

})

let orderSum
const calcItemCount = () => {
    const bag = JSON.parse(localStorage.getItem('bag'));
    let sum = 0
    bag.forEach(p => { sum += p.quantity * p.price })
    document.getElementById("totalAmount").innerText = sum
}

const calcTotalAmount = () => {
    const bag = JSON.parse(localStorage.getItem('bag'));

    document.getElementById("itemCount").innerText = bag.length
}


const deleteFromCart = (product) => {
    /*console.log(product)*/
    const bag = JSON.parse(localStorage.getItem('bag'));
    bag.forEach(p => { if (p.productId == product.productId) p.quantity-- })
    const newBag = bag.filter(p => p.quantity != 0)
    console.log(newBag)
    localStorage.setItem('bag', JSON.stringify(newBag));
    getProductsFromCart()
    calcItemCount()
    calcTotalAmount()

    
}
const displayProduct = (product) => {
    console.log(`../Images/food/${product.img}.jpg`)
    var temp = document.querySelector("#temp-row")
    var clone = temp.content.cloneNode(true);
    console.log(clone)
    clone.querySelector("img").src = `../Images/food/${product.img}.jpg`
    clone.querySelector(".itemNumber").innerText = product.quantity;
    clone.querySelector(".itemName").innerText = product.productName;
    clone.querySelector('button').addEventListener('click', () => { deleteFromCart(product) });
    document.getElementById("items").appendChild(clone)

}

const drowProducts = (bag) => {
    const productToDelete = document.getElementsByClassName("item-row");
    for (let i = 0; i < productToDelete.length; i++) {
        productToDelete[i].innerHTML=""
    }
    bag.map((product) => {
        displayProduct(product)
    })
}

function getProductsFromCart() { 
    const bag = JSON.parse(localStorage.getItem('bag'));
    drowProducts(bag)
}
const updateShoppingBagPage = () => {
    calcItemCount()
    calcTotalAmount()
    getProductsFromCart()
}
const sendOrder =async (user) => {
    const cart = JSON.parse(localStorage.getItem("bag"));
    const order = {
        userID: user.userId,
        orderItems: cart,
        orderSum: orderSum,
        OrderDate: new Date()

    }
    const res = await fetch('https://localhost:44398/api/Order', {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    });

    const orderWiteId= await res.json()
    console.log(orderWiteId)
    localStorage.setItem('bag', JSON.stringify([]));
    alert(" מספר ההזמנה שלך הוא " + orderWiteId.orderId)
    updateShoppingBagPage()
}

const createOrder = async () => {
   
    const user = JSON.parse(localStorage.getItem("user"));

    if (!user)
        alert("אתה צריך להרשם!!!!!!")    
    else
        sendOrder(user)
    
}

const Getdate = () => {
    const date= new Date()
    let day = date.getDate();
    let month = date.getMonth() + 1;
    let year = date.getFullYear();

    // This arrangement can be altered based on how we want the date's format to appear.
    let currentDate = `${day}-${month}-${year}`;
    return currentDate;
}