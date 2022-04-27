let socket = io();

let username = prompt("Please enter your name", "undefined creature");
if (username == null || username === "") {
    document.getElementById("username").innerHTML = "undefined creature"
} else {
    document.getElementById("username").innerHTML = username
}
function uuidv4() {
    return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

let uuid = uuidv4()

let messages = document.getElementById('messages');
let form = document.getElementById('form');
let input = document.getElementById('input');

form.addEventListener('submit', function(e) {
    e.preventDefault();
    if (input.value) {
        socket.emit('new-msg', username, uuid, input.value);
        input.value = '';
    }
});

socket.emit("new-user", username, uuid);

socket.on('new-msg', function(senderName, senderId, msg) {
    let item = document.createElement('li');
    item.textContent = senderName + ":" + msg;
    messages.appendChild(item);
    window.scrollTo(0, document.body.scrollHeight);
});

socket.on("new-user", function (username,id) {
    let item = document.createElement('li');
    item.textContent = username + " " + id + " joined";
    messages.appendChild(item);
    window.scrollTo(0, document.body.scrollHeight);
});

socket.on("user-left", function (username,id) {
    let item = document.createElement('li');
    item.textContent = username + " " + id + " left";
    messages.appendChild(item);
    window.scrollTo(0, document.body.scrollHeight);
});