
//This will decorate the canvas on which the surfer cartoon image sits
var canvasObj = document.getElementById("surfCanvas");

var ctxObj = canvasObj.getContext('2d');

var linGradObj = ctxObj.createLinearGradient(0, 0, 0, 200);

linGradObj.addColorStop(0, 'red');
linGradObj.addColorStop(0.2, 'yellow');
linGradObj.addColorStop(0.3, 'white');
linGradObj.addColorStop(0.5, 'aqua');
linGradObj.addColorStop(0.7, 'blue');
linGradObj.addColorStop(1, 'blue');


//This will be filled using the linear gradient colouring above
ctxObj.fillStyle = linGradObj;

ctxObj.fillRect(0, 0, 300, 150);



$(document).ready(function () {


    //When cartoon image is clicked it travels left and decreases in size
    $("#animatedSurfer").click(function () {

        $("#animatedSurfer").animate({
            position: 'absolute', left: '300px', top: '450px',
            height: '150px', width: '175px'
        }, 5000);


    });

    //This hover function is triggered even before clicking the image - hence, it leads to a slight delay
    //before the click action is implemented. It also ensures, however, that the image will return
    //automatically to its original position
    $("#animatedSurfer").hover(function () {

        $("#animatedSurfer").animate({
            position: 'absolute', left: '650px', top: '450px',
            height: '200px', width: '250px'
        }, 2000);

    });
});