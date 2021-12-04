
let employees_work_experience = [];

function AddItemToList() {
    let firstname = document.getElementById('in-first-name').value;
    let lastname = document.getElementById('in-last-name').value;
    let patronymic = document.getElementById('in-patronymic').value;
    let date_str = document.getElementById('in-hire-date').value;

    if (firstname == null || firstname === "",
        lastname == null || lastname === "",
        patronymic == null || patronymic === "",
        date_str == null || date_str === "") {
        alert("Please, fill all required field");
        return false;
    }

    let date = new Date(date_str);
    let currentDate = new Date();
    let difference =
        (currentDate.getFullYear() - date.getFullYear()) * 365 +
        (currentDate.getMonth() - date.getMonth()) * 30 +
        (currentDate.getDay() - date.getDay());

    if (difference <= 0){
        alert("Date is wrong");
        return false;
    }

    console.log(difference);
    employees_work_experience.push(difference);

    let entry = document.createElement('li');
    entry.appendChild(
        document.createTextNode(firstname + ' ' + lastname + ' ' + patronymic + ': ' + date_str));
    document.getElementById("e_list").appendChild(entry);

    let avg_exp = 0;
    employees_work_experience.forEach(function(item, index) {
        avg_exp += item;
    });
    document.getElementById('avg_res').innerHTML = Math.floor( avg_exp /= employees_work_experience.length ).toString();
}