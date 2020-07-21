console.log('Hello world');

// JavaScript 
// not truly OO language
// generally called "object-based"
// has a lot of support for functional programming

// weakly/loosely typed
// in JS, variables do not have a type
// values do have types, but any variable can contain any type
//  objects in JS can have properties added or removed during runtime

// JS is interpreted, not compiled
//  individual JS runtimes might internally compile it to something else, but there is logically no "compile-time" part.
//  JS is just executed as it is read by the browser/runtime

// JS historically
//      meant for the browser
//      there's also server-side javascript running in environments
//      detached from a browser/webpage, especially Node.js

//  versions of JS:
//  netscape: JavaScript, IE: JScript
//  standardized as ECMAScript (ES for short)

//  pre-ES5: some weird legacy behavior
//  ES5: added strict mode, opt-in to disabling legacy behavior
//      the baseline for 99.9% of current browser usage
//  ES2015 aka ES6: added LOTS of things, including classes
//  yearly releases: we're up to ES2020

//--------------------------------------------------------

//#---data types in JS---#

// number
// same data type for whole numbers and fractional
//  (basically a double-precision IEEE floating-point number)
// let x = 5;
// x = 4.5;

// console.log(x);
// console.log(typeof x); // typeof returns a string representing the data type
