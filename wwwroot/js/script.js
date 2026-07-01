const input = document.getElementById("message");

const chat = document.getElementById("chatBox");

const sendButton = document.getElementById("sendButton");

sendButton.addEventListener("click", sendMessage);

input.addEventListener("keypress", function(e){

if(e.key==="Enter"){

e.preventDefault();

sendMessage();

}

});

async function sendMessage(){

const message=input.value.trim();

if(message==="") return;

chat.innerHTML+=`

<div class="user-message">

${message}

</div>

`;

input.value="";

chat.scrollTop=chat.scrollHeight;

const typing=document.createElement("div");

typing.className="bot-message";

typing.id="typing";

typing.innerHTML=`

<div class="typing">

<span></span>

<span></span>

<span></span>

</div>

`;

chat.appendChild(typing);

chat.scrollTop=chat.scrollHeight;

try{

const response=await fetch("/api/chat",{

method:"POST",

headers:{

"Content-Type":"application/json"

},

body:JSON.stringify({

message:message

})

});

const data=await response.json();

document.getElementById("typing").remove();

chat.innerHTML+=`

<div class="bot-message">

${data.reply.replace(/\n/g,"<br>")}

</div>

`;

}

catch{

document.getElementById("typing").remove();

chat.innerHTML+=`

<div class="bot-message">

Server Error

</div>

`;

}

chat.scrollTop=chat.scrollHeight;

input.focus();

}