using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FezManager : MonoBehaviour {

    private FezMove fezMove;
	public static FacingDirection facingDirection;
	public GameObject Player;
	private float degree = 0;
	public Transform Level;
	public Transform Building;
	public GameObject InvisiCube;
	private List<Transform> InvisiList = new List<Transform>();
	private FacingDirection lastfacing;
	private float lastDepth = 0f;
	public float WorldUnits = 1.000f;

    private static int fight_check;
    public AudioSource audio;

	// Use this for initialization
	void Start () {

		facingDirection = FacingDirection.Front;
		fezMove = Player.GetComponent<FezMove> ();
		UpdateLevelData (true);

	}

	// Update is called once per frame
	void Update () {

        fight_check = Combo.fightable;

		if(!fezMove._jumping)
		{
			bool updateData = false;
			if(OnInvisiblePlatform())
			if(MovePlayerDepthToClosestPlatform())
				updateData = true;
			if(MoveToClosestPlatformToCamera())
				updateData = true;
			if(updateData)
				UpdateLevelData(false);


		}

        if (fight_check == 0)

        {
            /*
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (OnInvisiblePlatform())
                {

                    MovePlayerDepthToClosestPlatform();

                }

                lastfacing = facingDirection;
                facingDirection = RotateDirectionRight();
                degree -= 90f;
                UpdateLevelData(false);
                fezMove.UpdateToFacingDirection(facingDirection, degree);

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (OnInvisiblePlatform())
                {
                    //MoveToClosestPlatform();
                    MovePlayerDepthToClosestPlatform();

                }
                lastfacing = facingDirection;
                facingDirection = RotateDirectionLeft();
                degree += 90f;
                UpdateLevelData(false);
                fezMove.UpdateToFacingDirection(facingDirection, degree);

            }

             */
            //JoystickButton5 || JoystickButton14
            if (Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                //If we rotate while on an invisible platform we must move to a physical platform
                //If we don't, then we could be standing in mid air after the rotation
                if (OnInvisiblePlatform())
                {
                    //MoveToClosestPlatform();
                    MovePlayerDepthToClosestPlatform();

                }
                lastfacing = facingDirection;
                facingDirection = RotateDirectionRight();
                degree -= 90f;
                UpdateLevelData(false);
                fezMove.UpdateToFacingDirection(facingDirection, degree);

                audio.Play();

            }
            //JoystickButton4 || JoystickButton13
            else if (Input.GetKeyDown(KeyCode.Joystick1Button4))
            {
                if (OnInvisiblePlatform())
                {
                    //MoveToClosestPlatform();
                    MovePlayerDepthToClosestPlatform();

                }
                lastfacing = facingDirection;
                facingDirection = RotateDirectionLeft();
                degree += 90f;
                UpdateLevelData(false);
                fezMove.UpdateToFacingDirection(facingDirection, degree);

                audio.Play();

            }
        }

		
	}
	/// <summary>
	/// Destroy current invisible platforms
	/// Create new invisible platforms taking into account the
	/// player's facing direction and the orthographic view of the 
	/// platforms
	/// </summary>
	private void UpdateLevelData(bool forceRebuild)
	{
		//If facing direction and depth havent changed we do not need to rebuild
		if(!forceRebuild)
		if (lastfacing == facingDirection && lastDepth == GetPlayerDepth ())
			return;
		foreach(Transform tr in InvisiList)
		{
			//Move obsolete invisicubes out of the way and delete

			tr.position = Vector3.zero;
			Destroy(tr.gameObject);

		}
		InvisiList.Clear ();
		float newDepth = 0f;

		newDepth = GetPlayerDepth ();
		CreateInvisicubesAtNewDepth (newDepth);


	}
	/// <summary>
	/// Returns true if the player is standing on an invisible platform
	/// </summary>
	private bool OnInvisiblePlatform()
	{
		foreach(Transform item in InvisiList)
		{

			if(Mathf.Abs(item.position.x - fezMove.transform.position.x) < WorldUnits && Mathf.Abs(item.position.z - fezMove.transform.position.z) < WorldUnits)
			if(fezMove.transform.position.y - item.position.y <= WorldUnits + 0.2f && fezMove.transform.position.y - item.position.y >0)
				return true;



		}
		return false;
	}
	/// <summary>
	/// Moves the player to the closest platform with the same height to the camera
	/// Only supports Unity cubes of size (1x1x1)
	/// </summary>
	private bool MoveToClosestPlatformToCamera()
	{
		bool moveCloser = false;
		foreach(Transform item in Level)
		{
			if(facingDirection == FacingDirection.Front || facingDirection == FacingDirection.Back)
			{

				//When facing Front, find cubes that are close enough in the x position and the just below our current y value
				//This would have to be updated if using cubes bigger or smaller than (1,1,1)
				if(Mathf.Abs(item.position.x - fezMove.transform.position.x) < WorldUnits +0.1f)
				{

					if(fezMove.transform.position.y - item.position.y <= WorldUnits + 0.2f && fezMove.transform.position.y - item.position.y >0 && !fezMove._jumping)
					{
						if(facingDirection == FacingDirection.Front && item.position.z < fezMove.transform.position.z)
							moveCloser = true;

						if(facingDirection == FacingDirection.Back && item.position.z > fezMove.transform.position.z)
							moveCloser = true;


						if(moveCloser)
						{

							fezMove.transform.position = new Vector3(fezMove.transform.position.x, fezMove.transform.position.y, item.position.z);
							return true;
						}
					}

				}

			}
			else{
				if(Mathf.Abs(item.position.z - fezMove.transform.position.z) < WorldUnits + 0.1f)
				{
					if(fezMove.transform.position.y - item.position.y <= WorldUnits + 0.2f && fezMove.transform.position.y - item.position.y >0 && !fezMove._jumping)
					{
						if(facingDirection == FacingDirection.Right && item.position.x > fezMove.transform.position.x)
							moveCloser = true;

						if(facingDirection == FacingDirection.Left && item.position.x < fezMove.transform.position.x)
							moveCloser = true;

						if(moveCloser)
						{
							fezMove.transform.position = new Vector3(item.position.x, fezMove.transform.position.y, fezMove.transform.position.z);
							return true;
						}

					}

				}
			}


		}
		return false;
	}


	/// <summary>
	/// Looks for an invisicube in InvisiList at position 'cube'
	/// </summary>
	/// <returns><c>true</c>, if transform invisi list was found, <c>false</c> otherwise.</returns>
	/// <param name="cube">Cube position.
	private bool FindTransformInvisiList(Vector3 cube)
	{
		foreach(Transform item in InvisiList)
		{
			if(item.position == cube)
				return true;
		}
		return false;

	}
	/// <summary>
	/// Looks for a physical (visible) cube in our level data at position 'cube'
	/// </summary>
	/// <returns><c>true</c>, if transform level was found, <c>false</c> otherwise.</returns>
	/// <param name="cube">Cube.
	private bool FindTransformLevel(Vector3 cube)
	{
		foreach(Transform item in Level)
		{
			if(item.position == cube)
				return true;

		}
		return false;

	}
	/// <summary>
	/// Determines if any building cubes are between the "cube"
	/// and the camera
	/// </summary>
	/// <returns><c>true</c>, if transform building was found, <c>false</c> otherwise.</returns>
	/// <param name="cube">Cube.
	private bool FindTransformBuilding(Vector3 cube)
	{
		foreach(Transform item in Building)
		{
			if(facingDirection == FacingDirection.Front )
			{
				if(item.position.x == cube.x && item.position.y == cube.y && item.position.z < cube.z)
					return true;
			}
			else if(facingDirection == FacingDirection.Back )
			{
				if(item.position.x == cube.x && item.position.y == cube.y && item.position.z > cube.z)
					return true;
			}
			else if(facingDirection == FacingDirection.Right )
			{
				if(item.position.z == cube.z && item.position.y == cube.y && item.position.x > cube.x)
					return true;

			}
			else
			{
				if(item.position.z == cube.z && item.position.y == cube.y && item.position.x < cube.x)
					return true;

			}
		}
		return false;

	}

	/// <summary>
	/// Moves player to closest platform with the same height
	/// Intended to be used when player jumps onto an invisible platform
	/// </summary>
	private bool MovePlayerDepthToClosestPlatform()
	{
		foreach(Transform item in Level)
		{

			if(facingDirection == FacingDirection.Front || facingDirection == FacingDirection.Back)
			{
				if(Mathf.Abs(item.position.x - fezMove.transform.position.x) < WorldUnits + 0.1f)
				if(fezMove.transform.position.y - item.position.y <= WorldUnits + 0.2f && fezMove.transform.position.y - item.position.y >0)
				{

					fezMove.transform.position = new Vector3(fezMove.transform.position.x, fezMove.transform.position.y, item.position.z);
					return true;

				}
			}
			else
			{
				if(Mathf.Abs(item.position.z - fezMove.transform.position.z) < WorldUnits + 0.1f)
				if(fezMove.transform.position.y - item.position.y <= WorldUnits + 0.2f && fezMove.transform.position.y - item.position.y >0)
				{

					fezMove.transform.position = new Vector3(item.position.x, fezMove.transform.position.y, fezMove.transform.position.z);
					return true;
				}
			}
		}
		return false;

	}
	/// <summary>
	/// Creates an invisible cube at position
	/// Invisicubes are used as a place to land because our current 
	/// depth level in 3 dimensions may not be aligned with a physical platform
	/// </summary>
	/// <returns>The invisicube.</returns>
	/// <param name="position">Position.
	private Transform CreateInvisicube(Vector3 position)
	{
		GameObject go = Instantiate (InvisiCube) as GameObject;

		go.transform.position = position;

		return go.transform;

	}
	/// <summary>
	/// Creates invisible cubes for the player to move on
	/// if the physical cubes that make up a platform
	/// are on a different depth
	/// </summary>
	/// <param name="newDepth">New depth.
	private void CreateInvisicubesAtNewDepth(float newDepth)
	{

		Vector3 tempCube = Vector3.zero;
		foreach(Transform child in Level)
		{

			if(facingDirection == FacingDirection.Front || facingDirection == FacingDirection.Back)
			{
				tempCube = new Vector3(child.position.x, child.position.y, newDepth);
				if(!FindTransformInvisiList(tempCube) && !FindTransformLevel(tempCube) && !FindTransformBuilding(child.position))
				{

					Transform go = CreateInvisicube(tempCube);
					InvisiList.Add(go);
				}

			}
			//z and y must match a level cube
			else if(facingDirection == FacingDirection.Right || facingDirection == FacingDirection.Left)
			{
				tempCube = new Vector3(newDepth, child.position.y, child.position.z);
				if(!FindTransformInvisiList(tempCube) && !FindTransformLevel(tempCube) && !FindTransformBuilding(child.position))
				{

					Transform go = CreateInvisicube(tempCube);
					InvisiList.Add(go);
				}

			}


		}


	}
	/// <summary>
	/// Any actions required if player returns to start
	/// </summary>
	public void ReturnToStart()
	{

		UpdateLevelData (true);
	}
	/// <summary>
	/// Returns the player depth. Depth is how far from or close you are to the camera
	/// If we're facing Front or Back, this is Z
	/// If we're facing Right or Left it is X
	/// </summary>
	/// <returns>The player depth.</returns>
	private float GetPlayerDepth()
	{
		float ClosestPoint = 0f;

		if(facingDirection == FacingDirection.Front || facingDirection == FacingDirection.Back)
		{
			ClosestPoint = fezMove.transform.position.z;

		}
		else if(facingDirection == FacingDirection.Right || facingDirection == FacingDirection.Left)
		{
			ClosestPoint = fezMove.transform.position.x;
		}


		return Mathf.Round(ClosestPoint);

	}


	/// <summary>
	/// Determines the facing direction after we rotate to the right
	/// </summary>
	/// <returns>The direction right.</returns>
	private FacingDirection RotateDirectionRight()
	{
		int change = (int)(facingDirection);
		change++;
		//Our FacingDirection enum only has 4 states, if we go past the last state, loop to the first
		if (change > 3)
			change = 0;
		return (FacingDirection) (change);
	}
	/// <summary>
	/// Determines the facing direction after we rotate to the left
	/// </summary>
	/// <returns>The direction left.</returns>
	private FacingDirection RotateDirectionLeft()
	{
		int change = (int)(facingDirection);
		change--;
		//Our FacingDirection enum only has 4 states, if we go below the first, go to the last state
		if (change < 0)
			change = 3;
		return (FacingDirection) (change);
	}

}
//Used frequently to keep track of the orientation of our player and camera
public enum FacingDirection
{
	Front = 0,
	Right = 1,
	Back = 2,
	Left = 3

}