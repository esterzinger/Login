function showChange(){
    var formChange = document.getElementById("changeDetails")
    formChange.style.display = 'block';

    const userJson = localStorage.getItem('user');
    const user = JSON.parse(userJson);
   console.log(user)
    document.getElementById("emailChange").value = user.email;
  /*  document.getElementById("passwordChange").value=user.password;*/
    document.getElementById("firstChange").value=user.firstName;
    document.getElementById("lastChange").value=user.lastName;
    
}
async function sumbitChange() {

    const userJson = localStorage.getItem('user');
    const user = JSON.parse(userJson);
    const id = user.userId;

    const changeuser = {
        firstName: document.getElementById("firstChange").value,
        lastName: document.getElementById("lastChange").value,
        Password: document.getElementById("passwordChange").value,
        email: document.getElementById("emailChange").value,
        userId: id
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
        changeStorege(changeuser)
    }
    else
        alert("have erorr with status" + status)

}
const changeStorege = (changeuser) => {
    localStorage.setItem("user", JSON.stringify(changeuser));
}