

addEventListener("load", async(event) => {
    console.log("kkkkkkkkkk")
    const res = await fetch('https://localhost:44398/api/Product', {
        method: "GET",
        headers: {
            'Content-Type': 'application/json'
        }
    })
    const products = await res.json()
    products.map((p) => {
        var temp = document.querySelector("#temp-card")
        var clone = temp.content.cloneNode(true);
        console.log(p.img)
        clone.querySelector("img").src = `../Images/food/${p.img}.jpg`
        clone.querySelector("h1").innerText = p.productName;
        clone.querySelector(".price").innerText = p.price;
        clone.querySelector(".description").innerText = p.description;
        document.getElementById("PoductList").appendChild(clone)

    })
});
 //<p class="price"></p>
 //           <p class="description"></p>

