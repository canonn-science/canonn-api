
console.log('Hello Worlds!');

let end = false;

setTimeout(() => end = true, 10000);

(function wait() {
	if (!end) {
		console.log('Waiting...');
		setTimeout(wait, 1000);
	} else {
		console.log('End. For realz.');
	}
})();
