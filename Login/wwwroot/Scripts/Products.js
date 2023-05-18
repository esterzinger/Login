addEventListener("load", async (event) => {

    const products = await gatAllProducts()
    await getAllCategory()
    const count = JSON.parse(localStorage.getItem('bag'));
    console.log(count.length)
    document.getElementById("ItemsCountText").innerText = count.length
});
let count = 0
const gatAllProducts = async (query) => {
    console.log(query)
    //https://localhost:44398/api/Product?minprice=50
       const res = await fetch(`https://localhost:44398/api/Product${query ? query:""}`, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        const products = await res.json()
    designProducts(products)
}

const getAllCategory = async () => {
    const category = await fetch('https://localhost:44398/api/Category')
    const categories = await category.json()
    designCategories()
}

const designCategories = async(categories) => {
    categories.map((p) => {
        var temp = document.querySelector("#temp-category")
        var clone = temp.content.cloneNode(true);
        clone.querySelector(".OptionName").innerText = p.categoryName
        document.getElementById("categoryList").appendChild(clone)
        addEventListener("change", async (event) => {
            filterProducts(event)
        })
    })
}
const designProducts = (products) => {
    document.getElementById("PoductList").innerHTML = "";
    products.map((p) => {
        var temp = document.querySelector("#temp-card")
        var clone = temp.content.cloneNode(true);
        clone.querySelector("img").src = `../Images/food/${p.img}.jpg`
        clone.querySelector("h1").innerText = p.productName;
        clone.querySelector(".price").innerText = p.price;
        clone.querySelector(".description").innerText = p.description;
        clone.querySelector('button').addEventListener('click', () => { addToCart(p) });
        document.getElementById("PoductList").appendChild(clone)
       
    })
}

const clean = () => {  
        document.getElementById("PoductList").innerHTML = "";
   }


const filterProducts = async () => {
    const name = document.getElementById('nameSearch').value
    const minPrice = document.getElementById("minPrice").value 
    const maxPrice = document.getElementById("maxPrice").value
    let categories = []
    const categoriesNodes = document.querySelector("#categoryList").querySelectorAll("div")

    for (let i = 0; i < categoriesNodes.length; i++) {
        if (categoriesNodes[i].querySelector("input").checked)
            categories.push(i+2)
    }
 
    const query=createQueryString(categories,name, minPrice, maxPrice)
    const res2 = await gatAllProducts(query);
   
}

const createQueryString = (categories,name,min, max) => {
    var query = "?"
    let b = false;
    
    if (categories != [])
        for (var i = 0; i < categories.length; i++) {
            if (b == false) { 
                query = query.concat(`categories=${categories[i]}`)
                b=true
            }
            else
                query = query.concat(`&categories=${categories[i]}`)
        }
    if (min != "" && b == false) {
        query = query.concat(`minprice=${min}`);
        b = true
    }
    if (min != "" && b != false)
        query = query.concat(`&&minprice=${min}`);
    if (max != "" && b == false) { 
        query = query.concat(`maxprice=${max}`);
    b = true}
    if (max != "" && b != false)
        query = query.concat(`&&maxprice=${max}`);
    console.log(query)
    if (name && b != false)
        query += `&&name=${name}`
    if (name && b == false)
        query += `name=${name}`
    return query;
}

const addToCart = (product) => {
   
    product.quantity = 1;
    const bag = JSON.parse(localStorage.getItem('bag') || '[]');
    let b=false
    bag.forEach(p => {
        if (p.productId == product.productId)
        { p.quantity++; b = true }
    })
    if (b == false) {
        newBag = [...bag, product];
        localStorage.setItem('bag', JSON.stringify(newBag));
    }

    else {
        localStorage.setItem('bag', JSON.stringify(bag));
    }
    designItemCount()   
}
const designItemCount = () => {
const count = JSON.parse(localStorage.getItem('bag'));
    console.log(count.length)
    document.getElementById("ItemsCountText").innerText = count.length
}


