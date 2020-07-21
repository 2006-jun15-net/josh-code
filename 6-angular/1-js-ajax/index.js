'use strict';

document.addEventListener("DOMContentLoaded", () => {
    //
    const loadButton = document.getElementById("load-button");
    const videoTitleDiv = document.getElementById("video-title");
    const videoDateDiv = document.getElementById("video-date");
    const errorMessageDiv = document.getElementById("error-message");
    
    errorMessageDiv.style.display = "none";

    loadButton.addEventListener("click", () => {
        // getVideoData(videoData => {
        //     videoTitleDiv.innerHTML = videoData[0].title;
        // }, error => {
        //     errorMessageDiv.style.display = "block";
        //     errorMessageDiv.innerHTML = `an error occured: ${xhr.status} ${xhr.statusText}`
        // });
        // the response has a json method which returns a promise of the response body deserialized

        let index = 0;
        fetch("https://www.scorebat.com/video-api/v1/", {headers : { "Accept": "application/json"}})
            .then(response => response.json())
            .then(videoData => {
                videoData.forEach(video => {
                    const newItem = document.createElement("p");
                    videoTitleDiv.append(newItem.videoData.title);
                })
                //console.log(videoData)
                //for(let ele of videoData){
                    //videoTitleDiv.innerHTML = videoData[index++].title;
                    //videoTitleDiv.innerHTML = JSON.stringify(ele.title);
                    //videoDateDiv.innerHTML = videoData[0].date;
                    //console.log("this runs second");
                
            })
            .catch(error => {
                console.log(error);
                errorMessageDiv.style.display = "block";
                errorMessageDiv.innerHTML = error.toString();
            });
});

function getVideoData (onSuccess, onError) {
    // the browser provided an XMLHttpRequest  object/constuctor used for making HTTP requests
    const xhr = new XMLHttpRequest();

    //configure what will happen as the request-response interaction occurs
    xhr.addEventListener("readystatechange", () => {
        console.log(`ready state: ${xhr.readyState}`);

        if(xhr.readyState === 4){
            // if the response if fully downloaded
            if(xhr.status === 200){
                console.log(xhr.responseText);
                // built-in ot the browser is JSON.parse and JSON.serialize
                // onSuccess(JSON.parse(xhr.responseText));
                onSuccess(xhr.response);
            } else {
                onError(xhr.status);
            }
        }
    });

    xhr.open("GET", "https://www.scorebat.com/video-api/v1/");

    xhr.responseType = "json";
    xhr.setRequestHeader("Accept", "application/json");

    xhr.send();
}});
