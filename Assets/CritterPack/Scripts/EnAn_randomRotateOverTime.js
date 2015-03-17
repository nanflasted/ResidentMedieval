


private var right:boolean=true;
private var timeOfChange:float;
private var timeCounter:float;
private var lendulet:float;
var rot:float=1;
var rotTreshold:float=100;
var rotChngTimeMin:float=0;
var rotChngTimeMax:float=3;

function changeDir () {
right=!right;
timeOfChange=Random.Range(rotChngTimeMin, rotChngTimeMax);
timeCounter=0;
}

function Start () 
{
changeDir();

}

function Update () {
timeCounter+=Time.deltaTime;
if (timeCounter>timeOfChange)
{
changeDir();
}

if (right==true)
	{
lendulet-=10*Time.deltaTime*rot;
	}


if (right==false)
	{
lendulet+=10*Time.deltaTime*rot;
	}

if (lendulet>rotTreshold)
{
lendulet=rotTreshold;
right=true;
}

if (lendulet<-rotTreshold)
{
lendulet=-rotTreshold;
right=false;
}
transform.Rotate(0, lendulet*Time.deltaTime*rot, 0);


}