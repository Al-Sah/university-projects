const express = require('express');
const app = express()
const router = express.Router();

const path = require('path');
const logger = require('morgan');
const port = process.env.PORT || 3000;

const server = require('http').Server(app);
const io = require('socket.io')(server);



app.use(logger('dev'));
app.use(express.json());
app.use(express.static(path.join(__dirname, 'public')));


router.get('/', (req, res) => {
  res.sendFile(__dirname + '/public/index.html');
});


io.on('connection', (socket) => {
  socket.on('new-msg', msg => {
    io.emit('new-msg', msg);
  });
});



server.listen(port, () => {
  console.log(`Socket.IO server running at http://localhost:${port}/`);
});