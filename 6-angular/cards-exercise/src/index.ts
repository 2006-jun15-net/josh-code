document.addEventListener("DOMContentLoaded", () => {
    let newDeckButton = document.getElementById("new-deck");
    let drawButton = document.getElementById("draw-button");
    let cardDiv = document.getElementById("card-div");
    let cardImg = document.getElementById("card-img");

    let deckID = "";

    newDeckButton.addEventListener("click", () => {
        fetch("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1")
            .then(response => response.json())
            .then(deckData => {
                console.log(deckData);
                deckID = deckData.deck_id;
                console.log(deckData.deck_id);
            })
            .catch(error => {
                console.log(error);
            });
    });

    
        drawButton.addEventListener("click", () => {
            if(deckID !== ""){
                fetch(`https://deckofcardsapi.com/api/deck/${deckID}/draw/?count=1`)
                    .then(response => response.json())
                    .then(cardData => {
                        console.log(cardData);
                        cardDiv.innerHTML = `Your card: the ${cardData.cards[0].value} of ${cardData.cards[0].suit}`;
                        var img = document.createElement("img");
                        img.src = cardData.cards[0].image
                        cardImg.appendChild(img);
                        // cardImg.removeChild(document.getElementById("card-img"));
                    })
                    .catch(error => {
                        console.log(error);
                    });
            }
        });
});