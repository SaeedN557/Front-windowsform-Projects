let editedPlayer=0;
let activePlayer=0;
let currentRound=1;
let IsOver=false;
const players = [
    {
      name: '',
      symbol: 'X'
    },
    {
      name: '',
      symbol: 'O'
    },
  ];

  const gameData=[[0,0,0],[0,0,0],[0,0,0]];

const configplayerName=document.getElementById('config-overlay');
const configplayerNameBack=document.getElementById('backdrop');

const playerOneName=document.getElementById('player-1-change');
const playerTwoName=document.getElementById('player-2-change');

const popupCancel=document.getElementById('name-edit-cancel');
const popupConfirm=document.getElementById('name-edit-confirm');
const playerNameChange=document.getElementById('player-name');
const playerNameChangeBox=document.getElementById('playername');
const formElement=document.querySelector('form')
//const gameBoard=document.querySelectorAll('#game-board li');
const formError=document.getElementById('config-error');
const startnewgamebtn=document.getElementById('start-game-btn');
const gameArea=document.getElementById('active-game');
const gameBoardElement = document.getElementById('game-board');
const gameOverBanner=document.getElementById('game-over');
const gameOverGamer=document.getElementById('winner-player');
const reloadGame=document.getElementById('reload');
const playerTurn=document.getElementById('active-player-name');

playerOneName.addEventListener('click',OpenPlayerConfig);
playerTwoName.addEventListener('click',OpenPlayerConfig);



popupCancel.addEventListener('click',CancelPlayerConfig);
configplayerNameBack.addEventListener('click',CancelPlayerConfig);
popupConfirm.addEventListener('click',ConfirmPlayerName);
formElement.addEventListener('submit',SavePlayerConfig);
startnewgamebtn.addEventListener('click',startGame);
/*for(track of gameBoard){
    track.addEventListener('click',houseselector);
}*/
gameBoardElement.addEventListener('click', houseselector);
reloadGame.addEventListener('click',reloadGameFunc);
