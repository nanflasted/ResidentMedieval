var minSpeed:float=0;
var maxSpeed:float=2;
private var speed:float;

var changeTimeMin:float=0.5;
var changeTimeMax:float=1;
private var changeTime:float;

private var timeCounter:float=0;


function ChangeSpeed () {

speed=Random.Range(minSpeed, maxSpeed);
changeTime=Random.Range(changeTimeMin, changeTimeMax);
timeCounter=0;

}

function Start () {

ChangeSpeed();

}




function Update () {
timeCounter+=Time.deltaTime;

if(timeCounter>changeTime) ChangeSpeed();


transform.Translate(Vector3(0, 0, speed)*Time.deltaTime);


 

}