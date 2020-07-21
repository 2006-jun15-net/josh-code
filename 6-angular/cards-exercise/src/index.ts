document.addEventListener("DOMContentLoaded", () => {
    let drawButton = document.getElementById("draw-button");
    let cardDiv = document.getElementById("card-div");

    let deckID = "";

    drawButton.addEventListener("click", () => {
        // if(){
            fetch('https://deckofcardsapi.com/api/deck/new/draw/?count=1')
                .then(response => response.json())
                .then(cardData => {
                    console.log(cardData);
                    cardDiv.innerHTML = `Your card: the ${cardData.cards[0].value} of ${cardData.cards[0].suit}`;
                    deckID = cardData.deckId;
                })
                .catch(error => {
                    console.log(error);
                });
        // }
        // else
        // {
        //     fetch(`https://deckofcardsapi.com/api/deck/${deckID}/draw/?count=1`)
        //     .then(response => response.json())
        //     .then(cardData => {
        //         console.log(cardData);
        //         cardDiv.innerHTML = `Your card: the ${cardData.cards[0].value} of ${cardData.cards[0].suit}`;
        //     })
        //     .catch(error => {
        //         console.log(error);
        //     });
        // }
    });
});