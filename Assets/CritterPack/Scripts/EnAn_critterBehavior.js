private var state:int=1; //0 begin, 1 move, 2 idle, 3 die, 4 idle2
private var stateChangeDone:boolean=false;

private var timeCounter:float=0;
private var behavChangeTime:float=1;

//RANDOM ROT OVER TIME VARIABLES
private var right:boolean=true;
private var timeOfChange:float;
private var rotTimeCounter:float;
private var lendulet:float;

private var rnd:float;



private var xStart:float;
private var zStart:float;


var moveSpeed:float=0.65;
var moveAnimSpeed:float=1;
var rotSpeed:float=1;
var rotTreshold:float=80;

var killTime:float=30;

var move2:boolean=false;
private var useMove2:boolean=false;

private var killTimeCounter:float=0;

function Start () {
behavChangeTime=Random.Range(1, 4);
timeOfChange=Random.Range(0, 3);

xStart=transform.position.x;
zStart=transform.position.z;
	animation["move"].speed = moveAnimSpeed;	
}

function Update () {
timeCounter+=Time.deltaTime;
killTimeCounter+=Time.deltaTime;

	
if (timeCounter>behavChangeTime)
	{
	timeCounter=0;
	if (state==1&&stateChangeDone==false)
		{
		rnd=Random.Range(0, 100);

		
		
		if (rnd<10) state=2;
		if (rnd>10&&rnd<20) state=4;

if (rnd<60) 
{
useMove2=false;
behavChangeTime=Random.Range(1, 4);
} else {
useMove2=true;
behavChangeTime=0.5;
}

		stateChangeDone=true;
		}
	if (state==2&&stateChangeDone==false)
		{
		rnd=Random.Range(0, 100);
		
		if (rnd<50) state=1;
		if (rnd>75) state=4;

		stateChangeDone=true;
		
		}

	if (state==4&&stateChangeDone==false)
		{
		rnd=Random.Range(0, 100);
		
		if (rnd<50) state=1;
		if (rnd>75) state=2;

		stateChangeDone=true;
		
		}





	
	stateChangeDone=false;
	}	


if (killTime<killTimeCounter&&state!=3)
{
Destroy(gameObject, 4);
state=3;
}
 


if (state==1) ///MOVE BEGIN
	{
	//********************* RANDOM ROTATE OVER TIME PART
	rotTimeCounter+=Time.deltaTime;
	if (rotTimeCounter>timeOfChange)
		{
		right=!right;
		timeOfChange=Random.Range(0, 3);
		rotTimeCounter=0;
		}

	if (right==true)
		{
		lendulet-=10*Time.deltaTime*rotSpeed;
		}


	if (right==false)
		{
		lendulet+=10*Time.deltaTime*rotSpeed;
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
	transform.Rotate(0, lendulet*Time.deltaTime*rotSpeed, 0);

	// MOVE PART
	transform.Translate(Vector3(0,0,moveSpeed)*Time.deltaTime);

	// ANIM PART
	if (!animation.IsPlaying("move")&&(move2==false))
		{
 		animation.CrossFade("move", 0.3);
		animation["move"].speed = moveAnimSpeed;	
		}

	if (move2==true)
		{
		if (!animation.IsPlaying("move")&&useMove2==false)
			{
			animation.CrossFade("move", 0.3);
			animation["move"].speed = moveAnimSpeed;		
			}
		
		if (!animation.IsPlaying("move2")&&useMove2==true)
			{
			animation.CrossFade("move2", 0.3);
			animation["move2"].speed = moveAnimSpeed;		
			}



		}

	}

if (state==2)
	{	
	if (!animation.IsPlaying("idle")) animation.CrossFade("idle", 0.3);
	}


if (state==3)
	{	
	if (!animation.IsPlaying("die")) animation.CrossFade("die");

	}


if (state==4)
	{	
	if (!animation.IsPlaying("idle2")) animation.CrossFade("idle2", 0.5);
	}



}