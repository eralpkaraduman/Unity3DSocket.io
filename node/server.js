var io = require('socket.io').listen(8080);
io.sockets.on('connection', function (socket) {
socket.on('connection', function () {
console.log("connection");
});
socket.on('message', function (d) {
		console.log(d);
		socket.send(d);
	});
});