﻿
async function Register() {
    console.log("H");
   const newuser={
       FirstName : document.getElementById("nameRegister").value,
       LastName: document.getElementById("lastNameRegister").value,
       Password: document.getElementById("passwordRegister").value,
       Email: document.getElementById("emailRegister").value
    }
    const res = await fetch("https://localhost:44398/api/user",{
        method: "POST",
        headers: {
            'Content-Type':  'application/json'
        },
        body: JSON.stringify(newuser)
    })

    const status = res.status;
    if (status == 200) {
        alert('user signed up successfully');
    }
    else
        alert("have erorr with status" + status)

}
async function login() {

    const userDetails = {
        Email: document.getElementById("emailLogin").value,
        Password: document.getElementById("passwordLogin").value
    }
    console.log(userDetails)
    const res = await fetch("https://localhost:44398/api/User/Login", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userDetails)
    })

    const status = res.status;
    if (status == 200) {
        alert('user signed In successfully');
        const user = await res.json();
        localStorage.setItem("user", JSON.stringify(user));
        window.location.assign("./Products.html"); 
    }
    else
        alert("have erorr with status" + status)

}
async function cheakStrength() {
    const password = document.getElementById("passwordRegister").value;

    const res = await fetch("https://localhost:44398/api/Password", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    })
    const score = await res.json();
    document.getElementById("passwordStrengh").value = score;

}

function Loud() {
    const user = JSON.parse(localStorage.getItem('user'));
    document.getElementById('name').setAttribute('value', user.name);
    document.getElementById('number').setAttribute('value', user.number);

}
function toRegister() {
    document.getElementById('register').style.display='block';
}



