const express = require('express');
const app = express()

const path = require('path');
const logger = require('morgan');
const port = process.env.PORT || 3000;

const server = require('http').Server(app);
const io = require('socket.io')(server);

const urlencodedParser = express.urlencoded({extended: false});

app.use(logger('dev'));
app.use(express.json());
app.use(express.static(path.join(__dirname, 'public')));

app.post("/", urlencodedParser, function (request, response) {
  if(!request.body) return response.sendStatus(400);
  console.log(request.body);
  response.sendFile(__dirname + '/public/index.html');
});

const users = new Set();

io.on('connection', (socket) => {
  socket.on('new-msg', function (senderName, senderId, msg)  {
    io.sockets.emit("new-msg", senderName, senderId, msg);
  });

  socket.on("new-user", function (name, id) {
    socket.userId = id;
    users.add(id);
    // notify all except joined user
    socket.broadcast.emit("new-user", name, id);
  });

  socket.on("disconnect", () => {
    users.delete(socket.userId);
    io.emit("user-left", socket.userId, ""); //TODO
  });

});



server.listen(port, () => {
  console.log(`Socket.IO server running at http://localhost:${port}/`);
});