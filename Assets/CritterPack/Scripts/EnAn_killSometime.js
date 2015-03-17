var xDeviation:float=5;
var zDeviation:float=5;




private var xStart:float;
private var zStart:float;

function Start () {

xStart=transform.position.x;
zStart=transform.position.z;

}

function Update () {

if (Mathf.Abs(xStart-transform.position.x)>xDeviation || Mathf.Abs(zStart-transform.position.z)>zDeviation)
{
Destroy(gameObject);
}
 

}