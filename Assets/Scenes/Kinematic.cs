using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum steeringBehaviors {
    Seek,Flee,Arrive,Align,Face,LookWhereGoing, None
    }

public class Kinematic : MonoBehaviour
{

    public Vector3 linear;
    public float angular; //In degrees
    public GameObject newTarget;

    public steeringBehaviors choiceOfBehavior;

    // Update is called once per frame
    void Update()
    {
        switch (choiceOfBehavior)
        {
            case steeringBehaviors.None:
                ResetOrientation();
                break;
            default:
                MainSteeringBehaviors();
                break;
        }
    }


    void MainSteeringBehaviors()
    {
        ResetOrientation();

        switch (choiceOfBehavior)
        {
//            case steeringBehaviors.Seek:
//                Seek seek = new Seek();
//                seek.character = this;
//                seek.target= newTarget;
//                SteeringOutput seeking = seek.getSteering();
//                if (seeking != null)
//                {
//                    linear += seeking.linear* Time.deltaTime;
//                    angular += seeking.angular * Time.deltaTime;
//                }
//                break;
//            case steeringBehaviors.Flee:
//                Flee flee = new Flee();
//                flee.character = this;
//                flee.target= newTarget;
//                SteeringOutput fleeing = flee.getSteering();
//                if (fleeing != null)
//                {
//                    linear += fleeing.linear* Time.deltaTime;
//                    angular += fleeing.angular * Time.deltaTime;
//                }
//                break;
//    
            case steeringBehaviors.Align:
                Align align = new Align();
                align.character = this;
                align.target= newTarget;
                SteeringOutput aligning = align.getSteering();
                if (aligning != null)
                {
                    linear += aligning.linear* Time.deltaTime;
                    angular += aligning.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Face:
                Face face = new Face();
                face.character = this;
                face.target= newTarget;
                SteeringOutput facing = face.getSteering();
                if (facing != null)
                {
                    linear += facing.linear* Time.deltaTime;
                    angular += facing.angular * Time.deltaTime;
                }
                break;
            case steeringBehaviors.LookWhereGoing:
                LookWhereGoing look = new LookWhereGoing();
                look.character = this;
                look.target= newTarget;
                SteeringOutput looking = look.getSteering();
                if (looking != null)
                {
                    linear += looking.linear* Time.deltaTime;
                    angular += looking.angular * Time.deltaTime;
                }
                break;
//			case steeringBehaviors.Arrive:
//                Arrive arrive = new Arrive();
//                arrive.character = this;
//                arrive.target= newTarget;
//                SteeringOutput arriving = arrive.getSteering();
//                if (arriving != null)
//                {
//                    linear += arriving.linear* Time.deltaTime;
//                    angular += arriving.angular * Time.deltaTime;
//                }
//                break;
        }

    }

     void ResetOrientation()
    {
        //Update position and rotation
        transform.position += linear * Time.deltaTime;
        Vector3 angularIncrement = new Vector3(0, angular * Time.deltaTime, 0);
        transform.eulerAngles += angularIncrement;
    }

 }