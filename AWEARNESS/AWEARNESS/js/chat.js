var input = document.getElementsByTagName('input')[0];
var chat_area = document.getElementById('chat_area');
var send = document.getElementsByTagName('img')[0];

send.addEventListener('click', function () {
    if (input.value.trim() == "") return;

    var message_box = document.createElement('DIV');
    message_box.setAttribute('class', 'message');
    var content = document.createElement('SPAN');
    var date = document.createElement('SPAN');
    var clear_div = document.createElement('DIV');

    var d = new Date();
    content.style.float = 'left';
    date.style.float = 'right';
    clear_div.style.clear = 'both';
    content.textContent = input.value.trim();
    date.textContent = d.toTimeString().substr(0, 8);

    message_box.appendChild(content);
    message_box.appendChild(date);
    message_box.appendChild(clear_div);
    chat_area.appendChild(message_box);
    input.value = "";
});