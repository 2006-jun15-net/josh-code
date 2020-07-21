// typescript adds "type annotations" to js
// it will chekc that you've been using variables properly
// according to their types, but only at the stage when typescript is compiled inot javascript.

// from then on, it's just javascript, variables have no types 
function addMessage(message: string): void {
    document.body.innerHTML = message;
}

class Student {
    fullName: string;
    constructor(public firstName: string, public middleInitial: string, public lastName: string){
        this.fullName = firstName + " " + middleInitial + " " + lastName;
    }
}

interface Person {
    firstName: string;
    lastName: string;
}

function greeter(person: Person): string {
    return "Hello, " + person.firstName + " " + person.lastName;
}


document.addEventListener("DOMContentLoaded", () => {
    addMessage("Hello form Typescript");
    //console.log(asdf);

    let user = new Student("Jane", "M.", "User");

    document.body.textContent = greeter(user);
})
