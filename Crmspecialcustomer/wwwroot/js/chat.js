"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
//    document.getElementById("notification").classList.add("badge");
//    // We can assign user-supplied strings to an element's textContent because it
//    // is not interpreted as markup. If you're assigning in any other way, you 
//    // should be aware of possible script injection concerns.
//});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var Subject = document.getElementById("subject").value;
    var Body = document.getElementById("body").value;
    var ToUsersId = $("#ToUsersId").val();
    console.log(ToUsersId);
    connection.invoke("SendMessage", ToUsersId, Subject, Body).catch(function (err) {
        return console.error(err.toString());
    });
});

connection.invoke("CheckNotification").catch(function (err) {
    return console.error(err.toString());
});
connection.on("ReceiveMessage", function (sendDate, subject) {
    document.getElementById("notification").classList.add("badge");
    var messageDemo = `<li>
                                                        <a href="#">
                                                            <i class="zmdi zmdi-notifications-none"></i>
                                                            <p>${subject}.</p>
                                                            <span>${sendDate}</span>
                                                        </a>
                                                        <button class="delete"><i class="zmdi zmdi-close-circle-o"></i></button>
                                                    </li>`;
    $("#demoMessageList").append(messageDemo)
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
});
