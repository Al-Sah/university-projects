
function handleChange(myRadio) {
    let content = document.getElementById("content")
    let number1 = document.getElementById("number1")
    let number2 = document.getElementById("number2")
    if(myRadio.value === "cf4"){
        content.style.display = "block"
        number2.required = true;
        number1.required = true;
    } else {
        content.style.display = "none"
        number2.required = false;
        number1.required = false;
    }
}

function handleClick() {
    if(document.querySelector('input[name="clients-filter"]:checked').value !== "cf4"){
        return;
    }

    let res = parseInt(document.getElementById("number1").value);
    if(!isNaN(res)){
        sessionStorage.number1 = res;
    }
    res = parseInt(document.getElementById("number2").value);
    if(!isNaN(res)){
        sessionStorage.number2 = res;
    }
}


if (sessionStorage.getItem("number1") !== null) {
    document.getElementById("number1").value = sessionStorage.number1
}
if (sessionStorage.getItem("number2") !== null) {
    document.getElementById("number2").value = sessionStorage.number2
}