
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