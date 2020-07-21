'use strict';

// in old JS, variables have two possible scopes
//  - global/document
//      global/document - in scope everywhere after the line it's assigned (including in other script files)
//  - function scope
//      in scope anywhere in the function in which it was declared.
//      (including before it was declared and outside the block ({...}) it was declared)
//brfore ES5, we had two ways to define a variable:
x = 5;
var y = 5;

console.log(x);
console.log(y);

function calculate(a) {
    z = 6;
    var a = 7;
}

// even in pre-ES5 JS, accessing an undeclared variable throws a ReferenceError.
//  we can use try-catch with errors in JS (can use try-catch with anything)