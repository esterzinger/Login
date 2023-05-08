let count=0
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
    
    console.log(products)
    getproducts(products)
}

const getAllCategory = async () => {
    const category = await fetch('https://localhost:44398/api/Category')
    const categories = await category.json()
    console.log(categories)
    categories.map((p) => {
        var temp = document.querySelector("#temp-category")
        var clone = temp.content.cloneNode(true);
        console.log(p)
        clone.querySelector(".OptionName").innerText = p.categoryName
        //clone.querySelector(".Count").innerText = products.filter((e) => p.categoryId == e.categoryId).length
        document.getElementById("categoryList").appendChild(clone)
        addEventListener("change", async (event) => {
            filterProducts(event)

        })
    })
}

addEventListener("load", async (event) => {

    const products= await gatAllProducts()
    await getAllCategory()
    const count = JSON.parse(localStorage.getItem('bag'));
    console.log(count.length)
    document.getElementById("ItemsCountText").innerText = count.length


});
const clean = () => {  
        document.getElementById("PoductList").innerHTML = "";
   }

const getproducts = (products) => {
    document.getElementById("PoductList").innerHTML = "";
    products.map((p) => {
        var temp = document.querySelector("#temp-card")
        var clone = temp.content.cloneNode(true);
        //console.log(p.img)
        clone.querySelector("img").src = `../Images/food/${p.img}.jpg`
        clone.querySelector("h1").innerText = p.productName;
        clone.querySelector(".price").innerText = p.price;
        clone.querySelector(".description").innerText = p.description;
        clone.querySelector('button').addEventListener('click', () => { addToCart(p) });
        document.getElementById("PoductList").appendChild(clone)
       
    })
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
    console.log(categories)
    const res=createQueryString(categories,name, minPrice, maxPrice)
    const res2 = await gatAllProducts(res);
    //const res = await fetch('https://localhost:44398/api/Product', {
    //    method: "GET",
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
    console.log(product)
    const bag = JSON.parse(localStorage.getItem('bag') || '[]');
    newBag = [...bag, product];
    localStorage.setItem('bag', JSON.stringify(newBag));
    const count = JSON.parse(localStorage.getItem('bag'));
    console.log(count.length)
    document.getElementById("ItemsCountText").innerText = count.length
}




