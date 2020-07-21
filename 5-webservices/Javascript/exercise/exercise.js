function newCounter() {
    let i = 0;
    return function (){
        return i += 1;    
    }
}

let counter1 = newCounter();

console.log(counter1());
console.log(counter1());
console.log(counter1());