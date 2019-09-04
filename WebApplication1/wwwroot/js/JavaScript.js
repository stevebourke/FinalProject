//I found some of this method from stackoverflow.com/questions/14407458/webapi-multiple-put-post-parameters
//I wanted to post json put couldn't get it work - all message parameters are sent in the uri
//Time value was appearing in database as 0 - putting in a 'dummy' message ID value seems to fix it - real messageID unaffected


$(document).ready(function () {
    $("#btnPostMessage").click(function () {

        //convert from ms to seconds - taken from electrictoolbox.com
        MessageTime = Math.round(Date.now() / 1000);

        SenderID = document.getElementById("senderMemberID").value;

        RecipientID = document.getElementById("selectedID").value;

        MessageBody = document.getElementById("textMessage").value;

        $.ajax({
            type: 'POST',
            async: true,
            url: "api/Messages?MessageID=1&MessageTime=" + MessageTime + "&SenderID=" + SenderID +
                "&RecipientID=" + RecipientID + "&MessageBody=" + MessageBody,
            success: function (data) {
                alert("Message was Sent")
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
});