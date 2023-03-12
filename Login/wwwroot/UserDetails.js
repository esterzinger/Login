function showChange(){
    var formChange = document.getElementById("changeDetails")
    formChange.style.display = 'block';

    const userJson = sessionStorage.getItem('user');
    const user = JSON.parse(userJson);
   
    document.getElementById("emailChange").value = user.email;
    document.getElementById("passwordChange").value=user.password;
    document.getElementById("nameChange").value=user.name;
    document.getElementById("ageChange").value=user.age;
    
}
async function sumbitChange() {

    const userJson = sessionStorage.getItem('user');
    const user = JSON.parse(userJson);
    const id = user.id;

    const changeuser = {
        Name: document.getElementById("nameChange").value,
        Age: document.getElementById("ageChange").value,
        Password: document.getElementById("passwordChange").value,
        Email: document.getElementById("emailChange").value,
        Id: id
    }
    const res = await fetch(`/api/user/${id}`, {
        method: "PUT",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(changeuser)
    })
    const status = res.status;
    if (status == 200) {
        alert('user signed up successfully');
    }
    else
        alert("have erorr with status" + status)

}