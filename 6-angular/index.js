'use strict';

//  serialization

//  JSON <========> CLR objects
//  HTML <========> DOM

//  accessing the DOM is typically done via the "document" object
//  (in global scope, on that global window object)
// console.log(document);

//  Every DOM object has a bunch of properties like
//      onclick, onload, onhover, etc.

//  the load event fires on an element when it and all of its children are fully
//      loaded (including images downloaded, etc.)

// Old way to do it
// window.onload = function () {
//     const para = document.getElementById("intro-paragraph");
//     console.log(para);
//     para.onclick = function () {
//         para.innerHTML += "!";
//     };
// };

console.log("this runs first");

window.addEventListener("laod", () => {
    //do it this way ot let many event handlers coexist on the same element/event type
});

document.addEventListener("DOMContentLoaded", () => {
    // this even fires as soon as the whole DOM is created, but not necessarily filled in with downloaded images, etc. this is faster
    const addButton = document.getElementById("add-button");
    const list = document.getElementsByClassName("list")[0];

    list.addEventListener("click", event => {
        printEventDetails(event);
        // event.target will be the specific li element that I click on
        // event.currentTarget will be the list
        if (event.target.tagName === "LI"){
            list.removeChild(event.target);
        }
    });

    let index = 0;

    addButton.addEventListener("click", () => {
        const newItem = document.createElement("li");
        newItem.innerHTML = (index++).toString();
        list.appendChild(newItem);

        newItem.addEventListener("click", printEventDetails);
        // newItem.addEventListener("click", () => {
        //     list.removeChild(newItem)
        // });
    });
    document.body.addEventListener("click", event => {
        if (event.target.tagName === "A") {
            event.preventDefault();
        }
        // the #1 time I might do that is 
        // to stop forms from submitting normally
        // if I want to process / validate the form data manually in JS
    }); 
});

function printEventDetails(event) {
    console.log(event.type);
    //the specific element that is targeted by the event
    console.log(event.target);
    // the element that this event listener was attached to
    console.log(event.currentTarget);
}