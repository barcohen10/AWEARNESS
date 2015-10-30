var input = document.getElementById('txtMessage');
var chat_area = document.getElementById('chat_area');
var send = document.getElementById('arrowChat');

send.addEventListener('click', function () {
    if(input.value.trim() == "") return;

    var message_box = document.createElement('DIV');
    message_box.setAttribute('class','message');
    var content = document.createElement('SPAN');
    var date = document.createElement('SPAN');
    var clear_div = document.createElement('DIV');
	
    var d = new Date();
    content.style.float = 'left';
    date.style.float = 'right';
    date.style.fontSize = "36px";
    date.style.paddingTop = "8px";
    clear_div.style.clear = 'both';
    var txt = document.createTextNode("Caregiver: " + input.value.trim());
    content.appendChild(txt);
    date.textContent = d.toTimeString().substr(0,5);
	
    message_box.appendChild(content);
    message_box.appendChild(date);
    message_box.appendChild(clear_div);
    chat_area.appendChild(message_box);
    input.value = "";	
});