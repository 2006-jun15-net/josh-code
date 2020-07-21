// typescript adds "type annotations" to js
// it will chekc that you've been using variables properly
// according to their types, but only at the stage when typescript is compiled inot javascript.
// from then on, it's just javascript, variables have no types 
function addMessage(message) {
    document.body.innerHTML = message;
}
var asdf = addMessage("Hello form Typescript");
console.log(asdf);
