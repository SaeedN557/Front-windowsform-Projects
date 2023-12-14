function OpenPlayerConfig(event){
    editedPlayer=+event.target.dataset.playerid;
    console.log(editedPlayer);
    configplayerName.style.display="block";
    configplayerNameBack.style.display="block";
}

function CancelPlayerConfig(){
    configplayerName.style.display="none";
    configplayerNameBack.style.display="none";
    formElement.firstElementChild.classList.remove('error');
    formError.textContent="";
}

function ConfirmPlayerName(){
    playerNameChange.value=playerNameChangeBox;
    configplayerName.style.display="none";
    configplayerNameBack.style.display="none";
}

function SavePlayerConfig(event){
    event.preventDefault();
    const formdata=new FormData(event.target);
    const enteredPlayerName=formdata.get('playername').trim();
    const updatedPlayerData=document.getElementById('player-' + editedPlayer + '-data');
    updatedPlayerData.children[1].textContent=enteredPlayerName;
    if(!enteredPlayerName){
        event.target.firstElementChild.classList.add("error");
        formError.textContent="لطفا نام خود را به صورت صحیح وارد کنید";
        return;
    }
    players[editedPlayer-1]=enteredPlayerName;

    

    CancelPlayerConfig();
}

function startGame(){
    if(players[0].name===''||players[1].name===''){
        alert('نام بازیکنان را وارد کنید');
        return;
    }
    playerTurn.textContent=players[activePlayer].name;
    gameArea.style.display="block";
}

function switchPlayer(){
    if(activePlayer==0){
        activePlayer=1;
    }
    else{
        activePlayer=0;
    }
    playerTurn.textContent=players[activePlayer].name;
}
function gameOverChecker(){
    for (let i = 0; i < 3; i++) {
        if (
          gameData[i][0] > 0 &&
          gameData[i][0] === gameData[i][1] &&
          gameData[i][1] === gameData[i][2]
        ) {
          return gameData[i][0];
        }
      }
          for (let i = 0; i < 3; i++) {
        if (
          gameData[0][i] > 0 &&
          gameData[0][i] === gameData[1][i] &&
          gameData[0][i] === gameData[2][i]
        ) {
          return gameData[0][i];
        }
    }
      if (
        gameData[0][0] > 0 &&
        gameData[0][0] === gameData[1][1] &&
        gameData[1][1] === gameData[2][2]
      ) {
        return gameData[0][0];
      }
    
      if (
        gameData[2][0] > 0 &&
        gameData[2][0] === gameData[1][1] &&
        gameData[1][1] === gameData[0][2]
      ) {
        return gameData[2][0];
      }
    
      if (currentRound === 9) {
        return -1;
      }
    
      return 0;
    }
function houseselector(event){
    if (event.target.tagName !== 'LI') {
        return;
      }
    
      const selectedField = event.target;
      const selectedColumn = selectedField.dataset.col - 1;
      const selectedRow = selectedField.dataset.row - 1;
    
      if (gameData[selectedRow][selectedColumn] > 0) {
        alert('لطفا یکی از خانه های خالی را انتخاب کنید');
        return;
      }
      if(activePlayer==0){
        selectedField.innerHTML="X";
      }
      else{
        selectedField.innerHTML="O";
      }
      //selectedField.innerHTML = players[activePlayer].symbol;
      selectedField.classList.add('disabled');
    
      gameData[selectedRow][selectedColumn] = activePlayer + 1;

      const winnerId=gameOverChecker();
      if(winnerId!=0){
        winnerShow(winnerId);
      }
      currentRound++;
      switchPlayer();
      startGame();
} 



    function winnerShow(winnerId){
        gameOverBanner.style.display='block';
        if(winnerId>0){
            gameOverGamer.textContent=players[winnerId-1];
        }
        else{
            gameOverBanner.firstElementChild.textContent="مساوی شد !";
        }
        gameOverBanner.style.cursor='pointer';
        configplayerNameBack.style.display="block";
    }
    function reloadGameFunc(){
        location.reload();
    }
