using UnityEngine;
using System.Collections;

public class animationControl : MonoBehaviour {
	public AnimationClip idleAnimation;
	public AnimationClip walkAnimation;
	public AnimationClip runAnimation;
	public AnimationClip jumpPoseAnimation;
	
	public float walkMaxAnimationSpeed = 0.75f;
	public float trotMaxAnimationSpeed = 1.0f;
	public float runMaxAnimationSpeed = 1.0f;
	public float jumpAnimationSpeed = 1.15f;
	public float landAnimationSpeed = 1.0f;
	bool canJump= true;
	public int currentState=0;
	private Animation _animation;
	// Use this for initialization
	void Awake () {
		_animation = GetComponent<Animation>();
		if(!_animation)
			Debug.Log("The character you would like to control doesn't have animations. Moving her might look weird.");
		if(!idleAnimation) {
			_animation = null;
				
			Debug.Log("No idle animation found. Turning off animations.");
		}
		if(!walkAnimation) {
			_animation = null;
			Debug.Log("No walk animation found. Turning off animations.");
		}
		if(!runAnimation) {
			_animation = null;
			Debug.Log("No run animation found. Turning off animations.");
		}
		if(!jumpPoseAnimation && canJump) {
			_animation = null;
			Debug.Log("No jump animation found and the character has canJump enabled. Turning off animations.");
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		
		HandleAni ();
	}
	void  HandleAni ()
	{
		CharacterController controller = GetComponent<CharacterController>();
		if(currentState==0){
			this.GetComponent<Animation>().Play("idle",PlayMode.StopAll);
			//_animation.CrossFade(idleAnimation.name);
		}
		else if(currentState==1){
			//_animation[walkAnimation.name].speed = Mathf.Clamp(controller.velocity.magnitude, 0.0f, walkMaxAnimationSpeed);
			//_animation.CrossFade(walkAnimation.name);
			this.GetComponent<Animation>().Play("walk",PlayMode.StopAll);
		}
		else if(currentState==2){
			//_animation[runAnimation.name].speed = Mathf.Clamp(controller.velocity.magnitude, 0.0f, runMaxAnimationSpeed);
			//_animation.CrossFade(runAnimation.name);	
			this.GetComponent<Animation>().Play("run",PlayMode.StopAll);
		}
		else if(currentState==3){
			//_animation[jumpPoseAnimation.name].speed = -landAnimationSpeed;
			//_animation[jumpPoseAnimation.name].wrapMode = WrapMode.ClampForever;
			//_animation.CrossFade(jumpPoseAnimation.name);	
			this.GetComponent<Animation>().Play("jump_pose",PlayMode.StopAll);
		}
		else if(currentState==4){
			//_animation[walkAnimation.name].speed = Mathf.Clamp(controller.velocity.magnitude, 0.0f, trotMaxAnimationSpeed);
			//_animation.CrossFade(walkAnimation.name);
			this.GetComponent<Animation>().Play("walk",PlayMode.StopAll);
		}
		else{
			this.GetComponent<Animation>().Play("idle",PlayMode.StopAll);
		}
	}
}
